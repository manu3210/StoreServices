﻿using MediatR;
using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using StoreServices.RabbitMQ.Bus.BusRabbit;
using StoreServices.RabbitMQ.Bus.Commands;
using StoreServices.RabbitMQ.Bus.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace StoreServices.RabbitMQ.Bus.Implement
{
    public class RabbitEventBus : IRabbitEventBus
    {
        private readonly IMediator _mediator;
        private readonly Dictionary<string, List<Type>> _handlers;
        private readonly List<Type> _eventTypes;

        public RabbitEventBus(IMediator mediator)
        {
            _mediator = mediator;
            _handlers = new Dictionary<string, List<Type>>();
            _eventTypes = new List<Type>();
        }

        
        public void Publish<T>(T pEvent) where T : EventClass
        {
            var factory = new ConnectionFactory() { HostName = "rabbit-ema-web" };

            using(var connection = factory.CreateConnection())
                using(var channel = connection.CreateModel())
            {
                var eventName = pEvent.GetType().Name;
                channel.QueueDeclare(eventName, false, false, false, null);

                var message = JsonConvert.SerializeObject(pEvent);
                var body = Encoding.UTF8.GetBytes(message);

                channel.BasicPublish("", eventName, null, body);
            }
        }

        public Task SendCommand<T>(T command) where T : Command
        {
            return _mediator.Send(command);
        }

        public void Subscribe<T, TH>()
            where T : EventClass
            where TH : IEventHandler<T>
        {
            var eventName = typeof(T).Name;
            var handlerType = typeof(TH);

            if(!_eventTypes.Contains(typeof(T)))
            {
                _eventTypes.Add(typeof(T));
            }

            if(!_handlers.ContainsKey(eventName))
            {
                _handlers.Add(eventName, new List<Type>());
            }

            if (_handlers[eventName].Any(x => x.GetType() == handlerType))
            {
                throw new ArgumentException($"Handler {handlerType}, is already registred by {eventName}");
            }

            _handlers[eventName].Add(handlerType);

            var factory = new ConnectionFactory() { HostName = "rabbit-ema-web", DispatchConsumersAsync = true };
            var connection = factory.CreateConnection();
            var channel = connection.CreateModel();

            channel.QueueDeclare(eventName, false, false, false, null);

            var consumer = new AsyncEventingBasicConsumer(channel);
            consumer.Received += Consumer_Delegate;

            channel.BasicConsume(eventName, true, consumer);

        }

        private async Task Consumer_Delegate(object sender, BasicDeliverEventArgs e)
        {
            var eventName = e.RoutingKey;
            var message = Encoding.UTF8.GetString(e.Body.ToArray());

            try
            {
                if(_handlers.ContainsKey(eventName))
                {
                    var subscriptions = _handlers[eventName];

                    foreach(var sb in subscriptions)
                    {
                        var handler = Activator.CreateInstance(sb);
                        if (handler == null) continue;

                        var eventType = _eventTypes.SingleOrDefault(x => x.Name == eventName);
                        var eventoDS = JsonConvert.DeserializeObject(message, eventType);

                        var concreteType = typeof(IEventHandler<>).MakeGenericType(eventType);

                        await (Task)concreteType.GetMethod("Handle").Invoke(handler, new object[] { eventoDS });
                    }
                }
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}

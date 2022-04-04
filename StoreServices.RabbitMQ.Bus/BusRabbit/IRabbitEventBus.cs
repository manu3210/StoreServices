using StoreServices.RabbitMQ.Bus.Commands;
using StoreServices.RabbitMQ.Bus.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreServices.RabbitMQ.Bus.BusRabbit
{
    public interface IRabbitEventBus
    {
        Task SendCommand<T> (T command) where T : Command;
        void Publish<T>(T pEvent) where T : EventClass;
        void Subscribe<T, TH>() where T : EventClass where TH : IEventHandler<T>;
    }
}

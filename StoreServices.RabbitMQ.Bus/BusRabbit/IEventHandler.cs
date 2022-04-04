using StoreServices.RabbitMQ.Bus.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreServices.RabbitMQ.Bus.BusRabbit
{
    public interface IEventHandler<in TEvent> : IEventHandler where TEvent : EventClass
    {
        Task Handle(TEvent pEvent);
    }

    public interface IEventHandler
    {

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreServices.RabbitMQ.Bus.Events
{
    public abstract class EventClass
    {
        public DateTime TimeStamp { get; protected set; }

        protected EventClass()
        {
            TimeStamp = DateTime.Now;   
        }
    }
}

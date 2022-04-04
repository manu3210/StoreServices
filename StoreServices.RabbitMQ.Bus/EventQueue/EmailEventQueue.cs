using StoreServices.RabbitMQ.Bus.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreServices.RabbitMQ.Bus.EventQueue
{
    public class EmailEventQueue : EventClass
    {
        public string Receiver { get; set; }
        public string Tittle { get; set; }
        public string Content { get; set; }
        public EmailEventQueue(string receiver, string tittle, string content)
        {
            Receiver = receiver;
            Tittle = tittle;
            Content = content;
        }
    }
}

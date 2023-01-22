using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Integration
{
    public interface IIntegrationSendEvent : IIntegrationEvent
    {
        public string QueueName { get; set; }

        public object EventData { get; set; }
    }
}

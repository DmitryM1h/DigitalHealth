using System;
using System.Collections.Generic;
using System.Text;

namespace Kafka.Messaging
{
    public class KafkaSettings
    {
        public string BootstrapService { get; set; }
        public string Topic { get; set; }
        public string GroupId { get; set;  }


    }
}

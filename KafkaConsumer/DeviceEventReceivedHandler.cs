using System;
using System.Collections.Generic;
using System.Text;

namespace Kafka.Messaging
{
    public record DeviceEvent(int id);
    public class DeviceEventReceivedHandler : IMessageHandler<DeviceEvent>
    {
        public Task HandleAsync(DeviceEvent message, CancellationToken cancellationToken)
        {
            Console.WriteLine("получили!");
            return Task.CompletedTask;

        }
    }
}

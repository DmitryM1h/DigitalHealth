using System;
using System.Collections.Generic;
using System.Text;

namespace Kafka.Messaging
{
    public interface IMessageHandler<in TMessage>
    {
        Task HandleAsync(TMessage message, CancellationToken cancellationToken);
    }
}

using DigitalHealth.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalHealth.Application.DomainEvents
{
    public class DomainEvent<T> : INotification where T : IDomainEvent
    {
        public T _domainEvent;

        public DomainEvent(T domainEvent)
        {
            _domainEvent = domainEvent;
        }
    }
}

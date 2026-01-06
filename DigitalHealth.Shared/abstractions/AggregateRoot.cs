using DigitalHealth.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalHealth.Abstractions.abstractions;

public abstract class AggregateRoot<TIdType>
{
    private readonly List<IDomainEvent> _domainEvents = new();

    protected void RaiseDomainEvent(IDomainEvent domainEvent)
    {
        _domainEvents.Add(domainEvent); 
    }
          
    
}

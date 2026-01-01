using DigitalHealth.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalHealth.Domain.DomainEvents
{
    public record UserRegistredDomainEvent(Guid UserId) : IDomainEvent;
    
    
}

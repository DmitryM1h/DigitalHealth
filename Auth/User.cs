
using DigitalHealth.Auth.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace Auth;

public class User : IdentityUser<Guid>
{
    public int Age { get;set; }
    public string? City { get; set; }
    public DateTime BirthDay { get;set; }

    private readonly List<IDomainEvent> _domainEvents = new();
    public IReadOnlyCollection<IDomainEvent> DomainEvents => _domainEvents.AsReadOnly();

    public void RaiseDomainEvent(IDomainEvent domainEvent)
    {
        _domainEvents.Add(domainEvent); 
    }
}

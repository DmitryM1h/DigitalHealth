
using Core.Interfaces;

namespace Core.Entities;

public abstract class User : IEntity
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public int Age { get;set; }
    public string City { get;set; }
     
}


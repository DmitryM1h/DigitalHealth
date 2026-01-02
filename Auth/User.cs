
using Microsoft.AspNetCore.Identity;

namespace Auth;

public class User : IdentityUser<Guid>
{
    public int Age { get;set; }
    public string? City { get; set; }
    public DateTime BirthDay { get;set; }

}

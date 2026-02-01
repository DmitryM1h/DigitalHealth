using Auth;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;


namespace Infrastructure.Data;

public class UserContext : IdentityDbContext<
    User,
    IdentityRole<Guid>,
    Guid,
    IdentityUserClaim<Guid>,
    IdentityUserRole<Guid>,
    IdentityUserLogin<Guid>,
    IdentityRoleClaim<Guid>,
    IdentityUserToken<Guid>>
{
    public UserContext(DbContextOptions<UserContext> options)
       : base(options) {}

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.Entity<User>()
            .HasIndex(t => t.NormalizedEmail)
            .IsUnique();

        builder.Entity<User>()
          .HasIndex(t => t.NormalizedUserName)
          .IsUnique(false);

        //builder.Entity<User>()
        //    .Property(t => t.UserName)
        //    .


        builder.HasDefaultSchema("Auth");
    }
 

    public override DbSet<User> Users { get; set; } = null!;
}

using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Ebiscon.CloudCart.Domain.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace Ebiscon.CloudCart.DataAccess;

public class ApplicationDbContext : IdentityDbContext<ApplicationUser, IdentityRole<string>, string>
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public DbSet<Order> Orders { get; set; }
    public DbSet<Payment> Payments { get; set; }
    public DbSet<Product> Products { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.Entity<Order>()
               .HasOne(o => o.User)
               .WithMany(u => u.Orders)
               .HasForeignKey(o => o.UserId);

        builder.Entity<Payment>()
               .HasOne(p => p.User)
               .WithMany(u => u.Payments)
               .HasForeignKey(p => p.UserId);
    }
}

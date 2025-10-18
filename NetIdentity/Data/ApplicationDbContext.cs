using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using NetIdentity.Models;

namespace NetIdentity.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            
            // Ensure default value for 'genero' at database level (for new rows without explicit value)
            builder.Entity<ApplicationUser>()
                   .Property(u => u.genero)
                   .HasDefaultValue("No especificado");
            base.OnModelCreating(builder);
        }
    }

}

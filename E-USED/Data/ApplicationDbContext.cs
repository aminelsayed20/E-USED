using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SellingUsedThings.Models.Entity;

namespace E_USED.Data
{
    public class ApplicationDbContext : IdentityDbContext <AppUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<AppUser> users { get; set; }
        public DbSet<Product> products { get; set; }
        public DbSet<Chat> chats { get; set; }
    }
}

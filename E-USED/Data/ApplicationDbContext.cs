using E_USED.Models.Entity;
using E_USED.Models.Entity.Chat;
using E_USED.Models.Entity.Product;
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

        public DbSet<AppUser> Users { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Chat> Chats { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<ConnectionUser> ConnectionUsers { get; set; }
        public DbSet<UserMessage> userMessages { get; set; }

        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


			/*
						modelBuilder.Entity<Chat>()
							.HasOne(c => c.User1)
							.WithMany()
							.HasForeignKey(c => c.User1Id)
							.OnDelete(DeleteBehavior.Restrict);

						modelBuilder.Entity<Chat>()
							.HasOne(c => c.User2)
							.WithMany()
							.HasForeignKey(c => c.User2Id)
							.OnDelete(DeleteBehavior.Restrict);*/

		}
    }
}

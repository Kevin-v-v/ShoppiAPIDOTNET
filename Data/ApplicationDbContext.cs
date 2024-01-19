using Microsoft.EntityFrameworkCore;
using ShoppiAPIDOTNET.Data.Models;

namespace ShoppiAPIDOTNET.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
            
        }

        public DbSet<UserAccount> UserAccounts { get; set; }
        public DbSet<UserProfile> UserProfiles { get; set; }
        public DbSet<UserType> UserTypes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserType>().HasData(
                new UserType {Id = -1, Name = "Admin", Description = "Administrador del sistema" },
                new UserType {Id = -2, Name = "Seller", Description = "Usuario con permiso de publicar anuncios"}
                );
            modelBuilder.Entity<UserProfile>().HasData(
                new UserProfile { Id = -1, Name = "Kevin", LastName = "Villalobos", PhoneNumber = "+5212323121212" },
                new UserProfile { Id = -2, Name = "Luis", LastName = "Fonsi", PhoneNumber = "+5212312341234" }
                );
            modelBuilder.Entity<UserAccount>().HasData(
                new UserAccount { Id = Guid.NewGuid(), UserName = "KevinV", Email = "kevinv@example.com", UserProfileId = -1, CreatedAt = DateTime.Now, LastUpdatedAt = DateTime.Now, PasswordHash = "$2a$11$QGbqhRgG5xwaxMk2i8xb4edMQAYVYkMuyfAPapCDnpDsrsOd5V1sW", UserTypeId = -1},
                new UserAccount { Id = Guid.NewGuid(), UserName = "LuisF", Email = "luisd@example.com", UserProfileId = -2, CreatedAt = DateTime.Now, LastUpdatedAt = DateTime.Now, PasswordHash = "$2a$11$GLY5Baw4A1lYtuPL.wS1c.vRoAJ6V.hIL9DNwD1tbOSWF2tQjfMg6", UserTypeId = -2 }
                );

            base.OnModelCreating(modelBuilder);
        }

        protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
        {   
            configurationBuilder.Properties<string>().AreUnicode(false);
            base.ConfigureConventions(configurationBuilder);
        }


    }
}

using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TCM.IdentityServer.Core.Domain;
using Microsoft.EntityFrameworkCore;

namespace TCM.IdentityServer.Data
{
    public class IdentityServerContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<UserClaim> Claims { get; set; }
        public DbSet<UserLogin> Logins { get; set; }
        public DbSet<UserSecret> Secrets { get; set; }

        public IdentityServerContext(DbContextOptions<IdentityServerContext> options) : base(options)
        { }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>().HasIndex(u => u.Subject).IsUnique();

            modelBuilder.Entity<User>().HasIndex(u => u.UserName).IsUnique();

            modelBuilder.Entity<User>().HasData(
                new User()
                {
                    Id = new Guid("2715f962-dec3-46a3-95a1-d50a2ffc4e1e"),
                    Password = "admin",
                    Subject = "1204d34f-3590-4a96-ade5-678a2108e9e4",
                    UserName = "admin",
                    Active = true
                },
                new User()
                {
                    Id = new Guid("67b855a3-f30f-4023-bb51-ab14c5b48811"),
                    Password = "testuser",
                    Subject = "484ae583-5188-421f-8ea4-68c5f8287b85",
                    UserName = "testuser",
                    Active = true
                }
            );

            modelBuilder.Entity<UserClaim>().HasData(
                new UserClaim()
                    {
                        Id = Guid.NewGuid(),
                        UserId = new Guid("2715f962-dec3-46a3-95a1-d50a2ffc4e1e"),
                        Type = "roles",
                        Value = "global_admin"
                    },
                
                new UserClaim()
                {
                    Id = Guid.NewGuid(),
                    UserId = new Guid("2715f962-dec3-46a3-95a1-d50a2ffc4e1e"),
                    Type = "given_name",
                    Value = "Administrador"
                },
                
                new UserClaim()
                {
                    Id = Guid.NewGuid(),
                    UserId = new Guid("67b855a3-f30f-4023-bb51-ab14c5b48811"),
                    Type = "roles",
                    Value = "general_user"
                },
                
                new UserClaim()
                {
                    Id = Guid.NewGuid(),
                    UserId = new Guid("67b855a3-f30f-4023-bb51-ab14c5b48811"),
                    Type = "given_name",
                    Value = "Test User"
                }
            );

        }


        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            // get updated entries
            var updatedConcurrencyAwareEntries = ChangeTracker.Entries()
                .Where(e => e.State == EntityState.Modified)
                .OfType<IConcurrencyAware>();

            foreach (var entry in updatedConcurrencyAwareEntries)
            {
                entry.ConcurrencyStamp = Guid.NewGuid().ToString();
            }

            return base.SaveChangesAsync(cancellationToken);
        }

    }
}
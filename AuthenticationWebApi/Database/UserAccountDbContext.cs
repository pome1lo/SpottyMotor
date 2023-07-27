using JWTAuthenticationManager.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;

namespace AuthenticationWebApi.Database
{
    public class UserAccountDbContext : DbContext
    {
        public DbSet<UserAccount> Users { get; set; } = null!;
        public DbSet<UserRole> UserRoles { get; set; } = null!;

        public UserAccountDbContext(DbContextOptions<UserAccountDbContext> dbContextOptions) : base(dbContextOptions)
        {
            try
            {
                var databaseCreator = Database.GetService<IDatabaseCreator>() as RelationalDatabaseCreator;
                if (databaseCreator is not null)
                {
                    if (!databaseCreator.CanConnect()) databaseCreator.Create();
                    if (!databaseCreator.HasTables())
                    {
                        databaseCreator.CreateTables();
                        UserRoles.Add(new UserRole() { RoleName = "Administrator" });
                        UserRoles.Add(new UserRole() { RoleName = "User" });
                        SaveChanges();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}

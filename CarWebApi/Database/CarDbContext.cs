using CarWebApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;

namespace CarWebApi.Database
{
    public class CarDbContext : DbContext
    {
        public DbSet<CarBody> CarBodies { get; set; } = null!;
        public DbSet<Category> Categories { get; set; } = null!;
        public DbSet<Transmission> Transmissions { get; set; } = null!;
        public DbSet<Characteristics> Characteristics { get; set; } = null!;
        public DbSet<Car> Cars { get; set; } = null!;

        public CarDbContext(DbContextOptions<CarDbContext> dbContextOptions) : base(dbContextOptions)
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

                        Transmissions.AddRange(
                            new Transmission() { TransmissionName = "Automatic " },
                            new Transmission() { TransmissionName = "Mechanics " },
                            new Transmission() { TransmissionName = "Robot " }
                        );

                        CarBodies.AddRange(
                            new CarBody() { CarBodyName = "CUV" },
                            new CarBody() { CarBodyName = "Coupe" },
                            new CarBody() { CarBodyName = "Sedan" },
                            new CarBody() { CarBodyName = "Roadster" },
                            new CarBody() { CarBodyName = "Supercar" },
                            new CarBody() { CarBodyName = "Hatchback" },
                            new CarBody() { CarBodyName = "Cabriolet" }
                        );

                        Categories.AddRange(
                            new Category() { CategoryName = "Hybrid" },
                            new Category() { CategoryName = "Petrol" },
                            new Category() { CategoryName = "Electric" }
                        );

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
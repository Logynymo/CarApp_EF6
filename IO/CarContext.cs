using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using REPO;

namespace IO
{
    /// <summary>
    /// Entity Framework context class, inherits from DbContext
    /// </summary>
    public class CarContext : DbContext
    {
        /// <summary>
        /// Constructor.
        /// base is responsible to get connectionString from a .config file
        /// Seeds default data to the database.
        /// </summary>
        public CarContext() : base("EntityCarDB")
        {
            Database.SetInitializer(new CarContextSeedInitializer());
        }

        // DbSets representing the tables of the database.
        public DbSet<Car> Cars { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Propellant> Propellants { get; set; }

        /// <summary>
        /// Overridden method.
        /// Adds configurations to the Entities.
        /// </summary>
        /// <param name="modelBuilder">DbModelBuilder</param>
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.AddFromAssembly(typeof(CarContext).Assembly);
        }
    }
}
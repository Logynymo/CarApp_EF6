using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using REPO;

namespace IO
{
    /// <summary>
    /// Responsible for setting a default data seed to database when
    /// initialized.
    /// </summary>
    public class CarContextSeedInitializer : DropCreateDatabaseIfModelChanges<CarContext>
    {
        // Adding seed data to Lists
        IList<Brand> defaultBrands = new List<Brand>
        {
            new Brand { BrandName = "Toyota" },
            new Brand { BrandName = "Honda" },
            new Brand { BrandName = "Ford" },
            new Brand { BrandName = "Volkswagen" },
            new Brand { BrandName = "Nissan" },
            new Brand { BrandName = "Chevrolet" },
            new Brand { BrandName = "Hyundai" },
            new Brand { BrandName = "Kia" },
            new Brand { BrandName = "Mini" },
            new Brand { BrandName = "Vauxhall" }
        };

        IList<Propellant> defaultPropellants = new List<Propellant>
        {
            new Propellant { PropellantName = "Benzin" },
            new Propellant { PropellantName = "Diesel" },
            new Propellant { PropellantName = "Hybrid" },
            new Propellant { PropellantName = "Elektrisk" },
            new Propellant { PropellantName = "Heste" }
        };

        /// <summary>
        /// Default constructor
        /// </summary>
        public CarContextSeedInitializer()
        {

        }

        /// <summary>
        /// Overridden method.
        /// Loops through the List<T>s and adds them to the context class and
        /// saves changes.
        /// </summary>
        /// <param name="context">AnimalContext</param>
        protected override void Seed(CarContext context)
        {
            foreach (Brand brand in defaultBrands)
            {
                context.Brands.Add(brand);
            }

            foreach (Propellant propellant in defaultPropellants)
            {
                context.Propellants.Add(propellant);
            }

            context.SaveChanges();
        }
    }
}

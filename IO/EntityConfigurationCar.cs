using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using REPO;

namespace IO
{
    public class EntityConfigurationCar : EntityTypeConfiguration<Car>
    {
        public EntityConfigurationCar()
        {
            this.ToTable("Cars");

            this.HasKey<int>(c => c.CarId);


        }
    }
}

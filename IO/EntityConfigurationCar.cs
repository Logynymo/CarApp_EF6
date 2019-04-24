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

            this.Property(c => c.Model)
                .HasMaxLength(50)
                .IsRequired();

            this.Property(c => c.LicensePlate)
                .HasMaxLength(20)
                .IsRequired();

            this.Property(c => c.BrandId)
                .IsRequired();

            this.Property(c => c.PropellantId)
                .IsRequired();
        }
    }
}

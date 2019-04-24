using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using REPO;

namespace IO
{
    public class EntityConfigurationBrand : EntityTypeConfiguration<Brand>
    {
        public EntityConfigurationBrand()
        {
            this.ToTable("Brands");

            this.HasKey<int>(b => b.BrandId);

            this.Property(b => b.BrandName)
                .HasMaxLength(20)
                .IsRequired();
        }
    }
}

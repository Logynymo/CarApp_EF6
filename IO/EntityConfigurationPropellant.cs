using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using REPO;

namespace IO
{
    public class EntityConfigurationPropellant : EntityTypeConfiguration<Propellant>
    {
        public EntityConfigurationPropellant()
        {
            this.ToTable("Propellants");

            this.HasKey<int>(p => p.PropellantId);

            this.Property(p => p.PropellantName)
                .HasMaxLength(20)
                .IsRequired();
        }
    }
}

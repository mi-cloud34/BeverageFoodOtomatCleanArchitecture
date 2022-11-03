using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.EntityConfigurations
{
    public class FoodAqueousAnhydrousTypeConfiguration : IEntityTypeConfiguration<FoodAqueousAnhydrousType>
    {
        public void Configure(EntityTypeBuilder<FoodAqueousAnhydrousType> builder)
        {
            builder.ToTable("FoodAqueousAnhydrousTypes").HasKey(k => k.Id);
            builder.Property(p => p.Id).HasColumnName("Id");
            builder.Property(p => p.FoodAqueousAnhydrousTypeName).HasColumnName("FoodAqueousAnhydrousTypeName");
            //builder.HasIndex(p => p.FoodAqueousAnhydrousTypeName, "UK_FoodAqueousAnhydrousType_Name").IsUnique();
           

            FoodAqueousAnhydrousType[] foodAqueousAnhydrousTypeSeeds = { new(1, "Sulu"), new(2, "Susuz") };
            builder.HasData(foodAqueousAnhydrousTypeSeeds);
        }
    }
}
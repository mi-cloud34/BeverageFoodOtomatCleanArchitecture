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
    public class FoodConfiguration : IEntityTypeConfiguration<Food>
    {
        public void Configure(EntityTypeBuilder<Food> builder)
        {
            builder.ToTable("Foods").HasKey(k => k.Id);
            builder.Property(p => p.Id).HasColumnName("Id");
            builder.Property(p => p.FoodName).HasColumnName("FoodName");
            builder.Property(p => p.FoodAqueousAnhydrousTypeId).HasColumnName("FoodAqueousAnhydrousTypeId");
            builder.Property(p=>p.PlotNumber).HasColumnName("PlotNumber");
            builder.HasOne(p=>p.FoodAqueousAnhydrousType);
            //builder.HasIndex(p => p.CustomerName, "UK_Customer_Name").IsUnique();
           

            Food[]foodSeeds = { new(1, "Meyve suyu",1,1), new(2, "Cola",2,2) };
            builder.HasData(foodSeeds);
        }
    }
}
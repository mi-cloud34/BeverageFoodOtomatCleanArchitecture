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
    public class BeverageConfiguration : IEntityTypeConfiguration<Beverage>
    {
        public void Configure(EntityTypeBuilder<Beverage> builder)
        {
            builder.ToTable("Beverages").HasKey(k => k.Id);
            builder.Property(p => p.Id).HasColumnName("Id");
            builder.Property(p => p.BeverageName).HasColumnName("BeverageName");
            builder.Property(p => p.BeverageHotColdTypeId).HasColumnName("BeverageHotColdTypeId");
            builder.Property(p=>p.BeverageSugarFreeTypeId).HasColumnName("BeverageSugarFreeTypeId");
            builder.Property(p=>p.PlotNumber).HasColumnName("PlotNumber");
            builder.HasOne(p=>p.BeverageHotColdType);
            builder.HasOne(p=>p.BeverageSugarFreeType);

            //builder.HasIndex(p => p.BeverageName, "UK_Beverage_Name").IsUnique();
           

            Beverage[] beverageSeeds = { new(1, "Meyve suyu",1,1,3), new(2, "Cola",2,2,6) };
            builder.HasData(beverageSeeds);
        }
    }
}
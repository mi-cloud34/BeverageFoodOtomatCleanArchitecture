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
    public class BeverageHotColdTypeConfiguration : IEntityTypeConfiguration<BeverageHotColdType>
    {
        public void Configure(EntityTypeBuilder<BeverageHotColdType> builder)
        {
            builder.ToTable("BeverageHotColdTypes").HasKey(k => k.Id);
            builder.Property(p => p.Id).HasColumnName("Id");
            builder.Property(p => p.BeverageHotColdTypeName).HasColumnName("BeverageHotColdTypeName");
            //builder.HasIndex(p => p.BeverageHotColdTypeName, "UK_BeverageHotColdType_Name").IsUnique();
           

            BeverageHotColdType[] beverageHotColdTypeSeeds = { new(1, "sıcak"), new(2, "soguk") };
            builder.HasData(beverageHotColdTypeSeeds);
        }
    }
}
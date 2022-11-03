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
    public class BeverageSugarFreeTypeConfiguration : IEntityTypeConfiguration<BeverageSugarFreeType>
    {
        public void Configure(EntityTypeBuilder<BeverageSugarFreeType> builder)
        {
            builder.ToTable("BeverageSugarFreeTypes").HasKey(k => k.Id);
            builder.Property(p => p.Id).HasColumnName("Id");
            builder.Property(p => p.BeverageSugarFreeTypeName).HasColumnName("BeverageSugarFreeTypeName");
            //builder.HasIndex(p => p.BeverageSugarFreeTypeName, "UK_BeverageSugarFreeType_Name").IsUnique();
           

            BeverageSugarFreeType[] BeverageSugarFreeTypeSeeds = { new(1, "Şekerli"), new(2, "Şekersiz") };
            builder.HasData(BeverageSugarFreeTypeSeeds);
        }
    }
}
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
    public class PaymentTypeConfiguration : IEntityTypeConfiguration<PaymentType>
    {
        public void Configure(EntityTypeBuilder<PaymentType> builder)
        {
            builder.ToTable("PaymentTypes").HasKey(k => k.Id);
            builder.Property(p => p.Id).HasColumnName("Id");
            builder.Property(p => p.PaymentTypeName).HasColumnName("PaymentTypeName");
            //builder.HasIndex(p => p.PaymentTypeName, "UK_PaymentType_Name").IsUnique();
           

            PaymentType[] paymentTypeSeeds = { new(1, "Cash"), new(2, "Credi") };
            builder.HasData(paymentTypeSeeds);
        }
    }
}
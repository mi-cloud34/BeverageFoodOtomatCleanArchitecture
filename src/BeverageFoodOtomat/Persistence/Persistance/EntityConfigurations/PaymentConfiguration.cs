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
    public class PaymentConfiguration : IEntityTypeConfiguration<Payment>
    {
        public void Configure(EntityTypeBuilder<Payment> builder)
        {
            builder.ToTable("Payments").HasKey(k => k.Id);
            builder.Property(p => p.Id).HasColumnName("Id");
            builder.Property(p => p.PaymentTotal).HasColumnName("PaymentTotal");
            builder.Property(p => p.PaymentTypeId).HasColumnName("PaymentTypeId");
            builder.Property(p => p.CustomerId).HasColumnName("CustomerId");
            builder.Property(p => p.BeverageId).HasColumnName("BeverageId");
            builder.Property(p => p.FoodId).HasColumnName("FoodId");
            builder.HasOne(p=>p.PaymentType);
            builder.HasOne(p=>p.Customer);
            builder.HasOne(p=>p.Beverage);
            builder.HasOne(p=>p.Food);

            //builder.HasIndex(p => p.PaymentName, "UK_Payment_Name").IsUnique();


            Payment[] paymentSeeds = { new(1,20,1,1,2,1), new(2,30,1,2,2,1) };
            builder.HasData(paymentSeeds);
        }
    }
}
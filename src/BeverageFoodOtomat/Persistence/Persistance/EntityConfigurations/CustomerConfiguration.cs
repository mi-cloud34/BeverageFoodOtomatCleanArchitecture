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
    public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.ToTable("Customers").HasKey(k => k.Id);
            builder.Property(p => p.Id).HasColumnName("Id");
            builder.Property(p => p.CustomerName).HasColumnName("CustomerName");
            //builder.HasIndex(p => p.CustomerName, "UK_Customer_Name").IsUnique();
           

            Customer[] customerSeeds = { new(1, "Mesut"), new(2, "Emre") };
            builder.HasData(customerSeeds);
        }
    }
}
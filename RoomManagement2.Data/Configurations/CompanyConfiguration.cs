using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RoomManagement2.Core.Models;

namespace RoomManagement2.Data.Configurations
{
    public class CompanyConfiguration : IEntityTypeConfiguration<Company>
    { 
        public void Configure(EntityTypeBuilder<Company> builder)
        {
            builder
                .HasKey(a => a.Id);

            builder
                .Property(m => m.Id)
                .UseIdentityColumn();

            builder
                .Property(m => m.Name)
                .IsRequired()
                .HasMaxLength(50);

            builder
            .Property(m => m.Description)
            .IsRequired()
            .HasMaxLength(500); 

            builder
                .Property(m => m.Email)
                .IsRequired()
                .HasMaxLength(100); 

            builder
                .Property(m => m.Status)
                .IsRequired()
                .HasMaxLength(20);

            builder
                .ToTable("Companies");
        }
    }
}

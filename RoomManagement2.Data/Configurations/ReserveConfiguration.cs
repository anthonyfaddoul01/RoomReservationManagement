using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using RoomManagement2.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoomManagement2.Data.Configurations
{
    public class ReserveConfiguration : IEntityTypeConfiguration<Reservation>
    {
        public void Configure(EntityTypeBuilder<Reservation> builder)
        {
            builder
                .HasKey(m => m.Id);

            builder
                .Property(m => m.UserId) 
                .IsRequired();

            builder
                .Property(m => m.RoomId) 
                .IsRequired();

            builder
                .Property(m => m.MeetingDate)
                .IsRequired();

            builder
                .Property(m => m.StartTime)
                .IsRequired();

            builder
                .Property(m => m.EndTime)
                .IsRequired();

            builder
                .ToTable("Reservations"); 
        }
    }
}

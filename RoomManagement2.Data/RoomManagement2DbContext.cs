using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RoomManagement2.Core.Models;
using RoomManagement2.Core.Models.Auth;
using RoomManagement2.Data.Configurations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace RoomManagement2.Data
{
    public class RoomManagement2DbContext : IdentityDbContext<UserX, Role, Guid>
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Reservation> Reservations { get; set; }

        public RoomManagement2DbContext(DbContextOptions<RoomManagement2DbContext> options)
            : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder
                .ApplyConfiguration(new UserConfiguration());

            builder
                .ApplyConfiguration(new CompanyConfiguration());

            builder
                .ApplyConfiguration(new RoomConfiguration());

            builder
                .ApplyConfiguration(new ReserveConfiguration());
        }
    }
}

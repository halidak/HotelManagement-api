using HotelManagement.Data.Models;
using HotelManagement_data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagement_data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasOne(u => u.Role)
                .WithMany(u => u.Users)
                .HasForeignKey(u => u.RoleId);


                 modelBuilder.Entity<AccommodationUnit>()
                .HasOne(u => u.Minibar)
                .WithMany(u => u.AccommodationUnits)
                .HasForeignKey(u => u.MinibarId);

            modelBuilder.Entity<Price>()
                .HasOne(u => u.AccommodationUnit)
                .WithMany(u => u.Prices)
                .HasForeignKey(u => u.AccommodationUnitId);

            modelBuilder.Entity<Minibar_Item>()
                .HasOne(m => m.Minibar)
                .WithMany(m => m.Minibar_Items)
                .HasForeignKey(m => m.MinibarId);

            modelBuilder.Entity<Minibar_Item>()
                .HasOne(m => m.Item)
                .WithMany(m => m.Minibar_Items)
                .HasForeignKey(m => m.ItemId);

            modelBuilder.Entity<Reservation>()
                .HasOne(r => r.AccommodationUnit)
                .WithMany(r => r.Reservations)
                .HasForeignKey(r => r.AccommodationUnitId);

            modelBuilder.Entity<Reservation>()
                .HasOne(r => r.User)
                .WithMany(r => r.Reservations)
                .HasForeignKey(r => r.UserId);

            modelBuilder.Entity<Services_Reservation>()
                .HasOne(s => s.Reservation)
                .WithMany(s => s.Services_Reservations)
                .HasForeignKey(s => s.ReservationId);

            modelBuilder.Entity<Services_Reservation>()
                .HasOne(s => s.Service)
                .WithMany(s => s.Services_Reservations)
                .HasForeignKey(s => s.ServiceId);

            modelBuilder.Entity<Receipt>()
                .HasOne(r => r.Reservation)
                .WithMany(r => r.Receipts)
                .HasForeignKey(r => r.ReservationId);

            modelBuilder.Entity<Minibar_Reservation>()
                .HasOne(m => m.Reservation)
                .WithMany(m => m.Minibar_Reservations)
                .HasForeignKey(m => m.ReservationId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Minibar_Reservation>()
                .HasOne(m => m.Item)
                .WithMany(m => m.Minibar_Reservations)
                .HasForeignKey(m => m.ItemId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<AUnit_Characteristics>()
                .HasOne(a => a.AccommodationUnit)
                .WithMany(a => a.AUnit_Characteristics)
                .HasForeignKey(a => a.AccommodationUnitId);

            modelBuilder.Entity<AUnit_Characteristics>()
                .HasOne(a => a.Characteristics)
                .WithMany(a => a.AUnit_Characteristics)
                .HasForeignKey(a => a.CharacteristicsId);

            var decimalProps = modelBuilder.Model
            .GetEntityTypes()
            .SelectMany(t => t.GetProperties())
            .Where(p => (System.Nullable.GetUnderlyingType(p.ClrType) ?? p.ClrType) == typeof(decimal));

            foreach (var property in decimalProps)
            {
                property.SetPrecision(18);
                property.SetScale(2);
            }
        }

        public DbSet<Role> Roles { get; set; }
        public DbSet<AccommodationUnit> AccommodationUnits { get; set; }
        public DbSet<Price> Prices { get; set; }
        public DbSet<Characteristics> Characteristics { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<Minibar> Minibars { get; set; }
        public DbSet<Minibar_Item> Minibar_Items { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<Services_Reservation> Services_Reservations { get; set; }
        public DbSet<Receipt> Receipts { get; set; }
        public DbSet<Minibar_Reservation> Minibar_Reservations { get; set; }
        public DbSet<AUnit_Characteristics> AUnit_Characteristics { get; set; }
    }
}

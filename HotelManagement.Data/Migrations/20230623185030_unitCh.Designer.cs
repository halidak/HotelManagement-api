﻿// <auto-generated />
using System;
using HotelManagement_data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace HotelManagement.Data.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20230623185030_unitCh")]
    partial class unitCh
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("HotelManagement.Data.Models.AUnit_Characteristics", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("AccommodationUnitId")
                        .HasColumnType("int");

                    b.Property<int>("CharacteristicsId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AccommodationUnitId");

                    b.HasIndex("CharacteristicsId");

                    b.ToTable("AUnit_Characteristics");
                });

            modelBuilder.Entity("HotelManagement.Data.Models.AccommodationUnit", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Capacity")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Floor")
                        .HasColumnType("int");

                    b.Property<string>("Image")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("MinibarId")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("MinibarId");

                    b.ToTable("AccommodationUnits");
                });

            modelBuilder.Entity("HotelManagement.Data.Models.Characteristics", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Characteristics");
                });

            modelBuilder.Entity("HotelManagement.Data.Models.Item", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.ToTable("Items");
                });

            modelBuilder.Entity("HotelManagement.Data.Models.Minibar", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Minibars");
                });

            modelBuilder.Entity("HotelManagement.Data.Models.Minibar_Item", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Amount")
                        .HasColumnType("int");

                    b.Property<int>("ItemId")
                        .HasColumnType("int");

                    b.Property<int>("MinibarId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ItemId");

                    b.HasIndex("MinibarId");

                    b.ToTable("Minibar_Items");
                });

            modelBuilder.Entity("HotelManagement.Data.Models.Minibar_Reservation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("MinibarId")
                        .HasColumnType("int");

                    b.Property<int>("ReservationId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("MinibarId");

                    b.HasIndex("ReservationId");

                    b.ToTable("Minibar_Reservations");
                });

            modelBuilder.Entity("HotelManagement.Data.Models.Price", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("AccommodationUnitId")
                        .HasColumnType("int");

                    b.Property<DateTime>("PeriodOf")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("PeriodTo")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("PricePerNight")
                        .HasPrecision(18, 2)
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("PricePerPerson")
                        .HasPrecision(18, 2)
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("AccommodationUnitId");

                    b.ToTable("Prices");
                });

            modelBuilder.Entity("HotelManagement.Data.Models.Receipt", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("ReservationId")
                        .HasColumnType("int");

                    b.Property<int>("TotalPrice")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ReservationId");

                    b.ToTable("Receipts");
                });

            modelBuilder.Entity("HotelManagement.Data.Models.Reservation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("AccommodationUnitId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CheckIn")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("CheckOut")
                        .HasColumnType("datetime2");

                    b.Property<int>("NumberOfPeople")
                        .HasColumnType("int");

                    b.Property<bool>("Status")
                        .HasColumnType("bit");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("AccommodationUnitId");

                    b.HasIndex("UserId");

                    b.ToTable("Reservations");
                });

            modelBuilder.Entity("HotelManagement.Data.Models.Services", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasPrecision(18, 2)
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.ToTable("Services");
                });

            modelBuilder.Entity("HotelManagement.Data.Models.Services_Reservation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("ReservationId")
                        .HasColumnType("int");

                    b.Property<int>("ServiceId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ReservationId");

                    b.HasIndex("ServiceId");

                    b.ToTable("Services_Reservations");
                });

            modelBuilder.Entity("HotelManagement_data.Models.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("HotelManagement_data.Models.User", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Image")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NormalizedUserName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<int?>("RoleId")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("User");
                });

            modelBuilder.Entity("HotelManagement.Data.Models.AUnit_Characteristics", b =>
                {
                    b.HasOne("HotelManagement.Data.Models.AccommodationUnit", "AccommodationUnit")
                        .WithMany("AUnit_Characteristics")
                        .HasForeignKey("AccommodationUnitId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HotelManagement.Data.Models.Characteristics", "Characteristics")
                        .WithMany("AUnit_Characteristics")
                        .HasForeignKey("CharacteristicsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AccommodationUnit");

                    b.Navigation("Characteristics");
                });

            modelBuilder.Entity("HotelManagement.Data.Models.AccommodationUnit", b =>
                {
                    b.HasOne("HotelManagement.Data.Models.Minibar", "Minibar")
                        .WithMany("AccommodationUnits")
                        .HasForeignKey("MinibarId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Minibar");
                });

            modelBuilder.Entity("HotelManagement.Data.Models.Minibar_Item", b =>
                {
                    b.HasOne("HotelManagement.Data.Models.Item", "Item")
                        .WithMany("Minibar_Items")
                        .HasForeignKey("ItemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HotelManagement.Data.Models.Minibar", "Minibar")
                        .WithMany("Minibar_Items")
                        .HasForeignKey("MinibarId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Item");

                    b.Navigation("Minibar");
                });

            modelBuilder.Entity("HotelManagement.Data.Models.Minibar_Reservation", b =>
                {
                    b.HasOne("HotelManagement.Data.Models.Minibar", "Minibar")
                        .WithMany("Minibar_Reservations")
                        .HasForeignKey("MinibarId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("HotelManagement.Data.Models.Reservation", "Reservation")
                        .WithMany("Minibar_Reservations")
                        .HasForeignKey("ReservationId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Minibar");

                    b.Navigation("Reservation");
                });

            modelBuilder.Entity("HotelManagement.Data.Models.Price", b =>
                {
                    b.HasOne("HotelManagement.Data.Models.AccommodationUnit", "AccommodationUnit")
                        .WithMany("Prices")
                        .HasForeignKey("AccommodationUnitId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AccommodationUnit");
                });

            modelBuilder.Entity("HotelManagement.Data.Models.Receipt", b =>
                {
                    b.HasOne("HotelManagement.Data.Models.Reservation", "Reservation")
                        .WithMany("Receipts")
                        .HasForeignKey("ReservationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Reservation");
                });

            modelBuilder.Entity("HotelManagement.Data.Models.Reservation", b =>
                {
                    b.HasOne("HotelManagement.Data.Models.AccommodationUnit", "AccommodationUnit")
                        .WithMany("Reservations")
                        .HasForeignKey("AccommodationUnitId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HotelManagement_data.Models.User", "User")
                        .WithMany("Reservations")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AccommodationUnit");

                    b.Navigation("User");
                });

            modelBuilder.Entity("HotelManagement.Data.Models.Services_Reservation", b =>
                {
                    b.HasOne("HotelManagement.Data.Models.Reservation", "Reservation")
                        .WithMany("Services_Reservations")
                        .HasForeignKey("ReservationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HotelManagement.Data.Models.Services", "Service")
                        .WithMany("Services_Reservations")
                        .HasForeignKey("ServiceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Reservation");

                    b.Navigation("Service");
                });

            modelBuilder.Entity("HotelManagement_data.Models.User", b =>
                {
                    b.HasOne("HotelManagement_data.Models.Role", "Role")
                        .WithMany("Users")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Role");
                });

            modelBuilder.Entity("HotelManagement.Data.Models.AccommodationUnit", b =>
                {
                    b.Navigation("AUnit_Characteristics");

                    b.Navigation("Prices");

                    b.Navigation("Reservations");
                });

            modelBuilder.Entity("HotelManagement.Data.Models.Characteristics", b =>
                {
                    b.Navigation("AUnit_Characteristics");
                });

            modelBuilder.Entity("HotelManagement.Data.Models.Item", b =>
                {
                    b.Navigation("Minibar_Items");
                });

            modelBuilder.Entity("HotelManagement.Data.Models.Minibar", b =>
                {
                    b.Navigation("AccommodationUnits");

                    b.Navigation("Minibar_Items");

                    b.Navigation("Minibar_Reservations");
                });

            modelBuilder.Entity("HotelManagement.Data.Models.Reservation", b =>
                {
                    b.Navigation("Minibar_Reservations");

                    b.Navigation("Receipts");

                    b.Navigation("Services_Reservations");
                });

            modelBuilder.Entity("HotelManagement.Data.Models.Services", b =>
                {
                    b.Navigation("Services_Reservations");
                });

            modelBuilder.Entity("HotelManagement_data.Models.Role", b =>
                {
                    b.Navigation("Users");
                });

            modelBuilder.Entity("HotelManagement_data.Models.User", b =>
                {
                    b.Navigation("Reservations");
                });
#pragma warning restore 612, 618
        }
    }
}

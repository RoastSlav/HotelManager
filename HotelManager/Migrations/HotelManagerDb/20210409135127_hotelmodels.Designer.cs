﻿// <auto-generated />
using System;
using HotelManager.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace HotelManager.Migrations.HotelManagerDb
{
    [DbContext(typeof(HotelManagerDbContext))]
    [Migration("20210409135127_hotelmodels")]
    partial class hotelmodels
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("HotelManager.Models.Client", b =>
                {
                    b.Property<int>("clientId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Adult")
                        .HasColumnType("bit");

                    b.Property<int>("CurrentReservatonId")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PhoneNumber")
                        .HasColumnType("int");

                    b.HasKey("clientId");

                    b.HasIndex("CurrentReservatonId");

                    b.ToTable("Clients");
                });

            modelBuilder.Entity("HotelManager.Models.Reservation", b =>
                {
                    b.Property<int>("reservationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("AllInclusive")
                        .HasColumnType("bit");

                    b.Property<bool>("IncludedBreakfast")
                        .HasColumnType("bit");

                    b.Property<DateTime>("LeavingDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("ReservationDate")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("TotalPrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("creatingUserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("reservationId");

                    b.ToTable("Reservations");
                });

            modelBuilder.Entity("HotelManager.Models.Room", b =>
                {
                    b.Property<int>("RoomId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Capacity")
                        .HasColumnType("int");

                    b.Property<int>("CurrentReservatonId")
                        .HasColumnType("int");

                    b.Property<decimal>("PriceForAdult")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("PriceForNonAdult")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("RoomNumber")
                        .HasColumnType("int");

                    b.Property<string>("RoomType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Vacant")
                        .HasColumnType("bit");

                    b.HasKey("RoomId");

                    b.HasIndex("CurrentReservatonId")
                        .IsUnique();

                    b.ToTable("Rooms");
                });

            modelBuilder.Entity("HotelManager.Models.Client", b =>
                {
                    b.HasOne("HotelManager.Models.Reservation", "Reservation")
                        .WithMany("Guests")
                        .HasForeignKey("CurrentReservatonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("HotelManager.Models.Room", b =>
                {
                    b.HasOne("HotelManager.Models.Reservation", "Reservation")
                        .WithOne("Room")
                        .HasForeignKey("HotelManager.Models.Room", "CurrentReservatonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}

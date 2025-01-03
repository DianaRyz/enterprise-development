﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TaxiCompany.Domain;

#nullable disable

namespace TaxiCompany.Domain.Migrations
{
    [DbContext(typeof(TaxiCompanyContext))]
    [Migration("20241224122914_Initial")]
    partial class Initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            MySqlModelBuilderExtensions.AutoIncrementColumns(modelBuilder);

            modelBuilder.Entity("TaxiCompany.Domain.Models.Car", b =>
                {
                    b.Property<int>("CarId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("CarID");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("CarId"));

                    b.Property<int>("AssignedDriverId")
                        .HasColumnType("int")
                        .HasColumnName("DriverID");

                    b.Property<string>("Colour")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("Colour");

                    b.Property<string>("Model")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("Model");

                    b.Property<string>("StateNumber")
                        .IsRequired()
                        .HasMaxLength(6)
                        .HasColumnType("varchar(6)")
                        .HasColumnName("StateNumber");

                    b.HasKey("CarId");

                    b.HasIndex("AssignedDriverId");

                    b.HasIndex("StateNumber")
                        .IsUnique();

                    b.ToTable("Cars");
                });

            modelBuilder.Entity("TaxiCompany.Domain.Models.Driver", b =>
                {
                    b.Property<int>("DriverId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("DriverID");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("DriverId"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)")
                        .HasColumnName("Address");

                    b.Property<int>("AssignedCarId")
                        .HasColumnType("int")
                        .HasColumnName("CarID");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)")
                        .HasColumnName("FullName");

                    b.Property<string>("Passport")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("varchar(10)")
                        .HasColumnName("Passport");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasMaxLength(12)
                        .HasColumnType("varchar(12)")
                        .HasColumnName("PhoneNumber");

                    b.HasKey("DriverId");

                    b.HasIndex("AssignedCarId");

                    b.HasIndex("Passport")
                        .IsUnique();

                    b.ToTable("Drivers");
                });

            modelBuilder.Entity("TaxiCompany.Domain.Models.Trip", b =>
                {
                    b.Property<int>("TripId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("TripID");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("TripId"));

                    b.Property<int>("AssignedCarId")
                        .HasColumnType("int")
                        .HasColumnName("CarID");

                    b.Property<int>("AssignedUserId")
                        .HasColumnType("int")
                        .HasColumnName("UserID");

                    b.Property<decimal>("Cost")
                        .HasColumnType("decimal(65,30)")
                        .HasColumnName("Cost");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("Date");

                    b.Property<string>("Departure")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)")
                        .HasColumnName("Departure");

                    b.Property<string>("Destination")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)")
                        .HasColumnName("Destination");

                    b.Property<TimeOnly>("DrivingTime")
                        .HasColumnType("time(6)")
                        .HasColumnName("DrivingTime");

                    b.HasKey("TripId");

                    b.HasIndex("AssignedCarId");

                    b.HasIndex("AssignedUserId");

                    b.ToTable("Trips");
                });

            modelBuilder.Entity("TaxiCompany.Domain.Models.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("UserID");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("UserId"));

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)")
                        .HasColumnName("FullName");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasMaxLength(12)
                        .HasColumnType("varchar(12)")
                        .HasColumnName("PhoneNumber");

                    b.HasKey("UserId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("TaxiCompany.Domain.Models.Car", b =>
                {
                    b.HasOne("TaxiCompany.Domain.Models.Driver", null)
                        .WithMany()
                        .HasForeignKey("AssignedDriverId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });

            modelBuilder.Entity("TaxiCompany.Domain.Models.Driver", b =>
                {
                    b.HasOne("TaxiCompany.Domain.Models.Car", null)
                        .WithMany()
                        .HasForeignKey("AssignedCarId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });

            modelBuilder.Entity("TaxiCompany.Domain.Models.Trip", b =>
                {
                    b.HasOne("TaxiCompany.Domain.Models.Car", null)
                        .WithMany()
                        .HasForeignKey("AssignedCarId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("TaxiCompany.Domain.Models.User", null)
                        .WithMany()
                        .HasForeignKey("AssignedUserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}

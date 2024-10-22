﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SW4BADAssignment2.Data;

#nullable disable

namespace SW4BADAssignment2.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("SW4BADAssignment2.Models.Cook", b =>
                {
                    b.Property<int>("CookId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CookId"));

                    b.Property<bool>("FoodSafetyCertified")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("CookId");

                    b.ToTable("Cooks");
                });

            modelBuilder.Entity("SW4BADAssignment2.Models.CookDishKitchen", b =>
                {
                    b.Property<int>("CookId")
                        .HasColumnType("int");

                    b.Property<int>("DishId")
                        .HasColumnType("int");

                    b.Property<int>("KitchenId")
                        .HasColumnType("int");

                    b.HasKey("CookId", "DishId", "KitchenId");

                    b.HasIndex("DishId");

                    b.HasIndex("KitchenId");

                    b.ToTable("CookDishKitchens");
                });

            modelBuilder.Entity("SW4BADAssignment2.Models.Customer", b =>
                {
                    b.Property<int>("CustomerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CustomerId"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("CardInfo")
                        .IsRequired()
                        .HasMaxLength(16)
                        .HasColumnType("nvarchar(16)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("PaymentOption")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("CustomerId");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("SW4BADAssignment2.Models.Cyclist", b =>
                {
                    b.Property<int>("CyclistId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CyclistId"));

                    b.Property<string>("BikeType")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<decimal>("HourlyRate")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("CyclistId");

                    b.ToTable("Cyclists");
                });

            modelBuilder.Entity("SW4BADAssignment2.Models.Dish", b =>
                {
                    b.Property<int>("DishId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DishId"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("Price")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<DateTime>("TimeEnd")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("TimeStart")
                        .HasColumnType("datetime2");

                    b.HasKey("DishId");

                    b.ToTable("Dishes");
                });

            modelBuilder.Entity("SW4BADAssignment2.Models.DishOrder", b =>
                {
                    b.Property<int>("DishId")
                        .HasColumnType("int");

                    b.Property<int>("OrderId")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("DishId", "OrderId");

                    b.HasIndex("OrderId");

                    b.ToTable("DishOrders");
                });

            modelBuilder.Entity("SW4BADAssignment2.Models.Kitchen", b =>
                {
                    b.Property<int>("KitchenId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("KitchenId"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("KitchenId");

                    b.ToTable("Kitchens");
                });

            modelBuilder.Entity("SW4BADAssignment2.Models.Leg", b =>
                {
                    b.Property<int>("LegId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("LegId"));

                    b.Property<DateTime>("DateTime")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("Time")
                        .HasColumnType("datetime2");

                    b.Property<int>("TripId")
                        .HasColumnType("int");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("LegId");

                    b.HasIndex("TripId");

                    b.ToTable("Legs");
                });

            modelBuilder.Entity("SW4BADAssignment2.Models.Order", b =>
                {
                    b.Property<int>("OrderId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("OrderId"));

                    b.Property<int>("CookRating")
                        .HasColumnType("int");

                    b.Property<int>("CustomerId")
                        .HasColumnType("int");

                    b.Property<int>("CyclistRating")
                        .HasColumnType("int");

                    b.HasKey("OrderId");

                    b.HasIndex("CustomerId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("SW4BADAssignment2.Models.Trip", b =>
                {
                    b.Property<int>("TripId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TripId"));

                    b.Property<int>("CyclistId")
                        .HasColumnType("int");

                    b.Property<int>("OrderId")
                        .HasColumnType("int");

                    b.HasKey("TripId");

                    b.HasIndex("CyclistId");

                    b.HasIndex("OrderId")
                        .IsUnique();

                    b.ToTable("Trips");
                });

            modelBuilder.Entity("SW4BADAssignment2.Models.CookDishKitchen", b =>
                {
                    b.HasOne("SW4BADAssignment2.Models.Cook", "Cook")
                        .WithMany("CookDishKitchen")
                        .HasForeignKey("CookId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SW4BADAssignment2.Models.Dish", "Dish")
                        .WithMany("CookDishKitchen")
                        .HasForeignKey("DishId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SW4BADAssignment2.Models.Kitchen", "Kitchen")
                        .WithMany("CookDishKitchen")
                        .HasForeignKey("KitchenId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cook");

                    b.Navigation("Dish");

                    b.Navigation("Kitchen");
                });

            modelBuilder.Entity("SW4BADAssignment2.Models.DishOrder", b =>
                {
                    b.HasOne("SW4BADAssignment2.Models.Dish", "Dish")
                        .WithMany("DishOrder")
                        .HasForeignKey("DishId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SW4BADAssignment2.Models.Order", "Order")
                        .WithMany("DishOrder")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Dish");

                    b.Navigation("Order");
                });

            modelBuilder.Entity("SW4BADAssignment2.Models.Leg", b =>
                {
                    b.HasOne("SW4BADAssignment2.Models.Trip", "Trip")
                        .WithMany("Legs")
                        .HasForeignKey("TripId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Trip");
                });

            modelBuilder.Entity("SW4BADAssignment2.Models.Order", b =>
                {
                    b.HasOne("SW4BADAssignment2.Models.Customer", "Customer")
                        .WithMany("Orders")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Customer");
                });

            modelBuilder.Entity("SW4BADAssignment2.Models.Trip", b =>
                {
                    b.HasOne("SW4BADAssignment2.Models.Cyclist", "Cyclist")
                        .WithMany("Trips")
                        .HasForeignKey("CyclistId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SW4BADAssignment2.Models.Order", "Order")
                        .WithOne("Trip")
                        .HasForeignKey("SW4BADAssignment2.Models.Trip", "OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cyclist");

                    b.Navigation("Order");
                });

            modelBuilder.Entity("SW4BADAssignment2.Models.Cook", b =>
                {
                    b.Navigation("CookDishKitchen");
                });

            modelBuilder.Entity("SW4BADAssignment2.Models.Customer", b =>
                {
                    b.Navigation("Orders");
                });

            modelBuilder.Entity("SW4BADAssignment2.Models.Cyclist", b =>
                {
                    b.Navigation("Trips");
                });

            modelBuilder.Entity("SW4BADAssignment2.Models.Dish", b =>
                {
                    b.Navigation("CookDishKitchen");

                    b.Navigation("DishOrder");
                });

            modelBuilder.Entity("SW4BADAssignment2.Models.Kitchen", b =>
                {
                    b.Navigation("CookDishKitchen");
                });

            modelBuilder.Entity("SW4BADAssignment2.Models.Order", b =>
                {
                    b.Navigation("DishOrder");

                    b.Navigation("Trip");
                });

            modelBuilder.Entity("SW4BADAssignment2.Models.Trip", b =>
                {
                    b.Navigation("Legs");
                });
#pragma warning restore 612, 618
        }
    }
}

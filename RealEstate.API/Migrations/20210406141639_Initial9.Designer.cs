﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RealEstate.API;

namespace RealEstate.API.Migrations
{
    [DbContext(typeof(RealEstateDbContext))]
    [Migration("20210406141639_Initial9")]
    partial class Initial9
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.4")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("RealEstate.API.Persistence.RealEstate", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("Area")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("BuildingType")
                        .HasColumnType("int");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal?>("PricePerMeter")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int?>("YearBuilt")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("RealEstates");
                });

            modelBuilder.Entity("RealEstate.API.Persistence.RealEstateNote", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<int>("RealEstateId")
                        .HasColumnType("int");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.HasKey("Id");

                    b.HasIndex("RealEstateId");

                    b.ToTable("RealEstateNote");
                });

            modelBuilder.Entity("RealEstate.API.Persistence.RealEstate", b =>
                {
                    b.OwnsOne("RealEstate.API.Persistence.RealEstateAddress", "RealEstateAddress", b1 =>
                        {
                            b1.Property<int>("RealEstateId")
                                .HasColumnType("int");

                            b1.Property<int?>("ApartmentNumber")
                                .HasColumnType("int");

                            b1.Property<int>("BuildingNumber")
                                .HasColumnType("int");

                            b1.Property<string>("PostalCode")
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("StreetName")
                                .HasColumnType("nvarchar(max)");

                            b1.HasKey("RealEstateId");

                            b1.ToTable("RealEstateAddresses");

                            b1.WithOwner()
                                .HasForeignKey("RealEstateId");
                        });

                    b.Navigation("RealEstateAddress");
                });

            modelBuilder.Entity("RealEstate.API.Persistence.RealEstateNote", b =>
                {
                    b.HasOne("RealEstate.API.Persistence.RealEstate", null)
                        .WithMany("RealEstateNotes")
                        .HasForeignKey("RealEstateId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("RealEstate.API.Persistence.RealEstate", b =>
                {
                    b.Navigation("RealEstateNotes");
                });
#pragma warning restore 612, 618
        }
    }
}

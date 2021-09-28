﻿// <auto-generated />
using System;
using Logixboard.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Logixboard.Database.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.10")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Logixboard.Models.Node", b =>
                {
                    b.Property<string>("NodeId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ShipmentReferenceId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("Unit")
                        .HasColumnType("int");

                    b.Property<decimal>("Weight")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("NodeId");

                    b.HasIndex("ShipmentReferenceId");

                    b.ToTable("Nodes");
                });

            modelBuilder.Entity("Logixboard.Models.Organization", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Code")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Organizations");
                });

            modelBuilder.Entity("Logixboard.Models.Shipment", b =>
                {
                    b.Property<string>("ReferenceId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime?>("EstimatedTimeArrival")
                        .HasColumnType("datetime2");

                    b.HasKey("ReferenceId");

                    b.ToTable("Shipments");
                });

            modelBuilder.Entity("OrganizationShipment", b =>
                {
                    b.Property<string>("OrganizationsId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ShipmentsReferenceId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("OrganizationsId", "ShipmentsReferenceId");

                    b.HasIndex("ShipmentsReferenceId");

                    b.ToTable("OrganizationShipment");
                });

            modelBuilder.Entity("Logixboard.Models.Node", b =>
                {
                    b.HasOne("Logixboard.Models.Shipment", "Shipment")
                        .WithMany("TransportPacks")
                        .HasForeignKey("ShipmentReferenceId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.Navigation("Shipment");
                });

            modelBuilder.Entity("OrganizationShipment", b =>
                {
                    b.HasOne("Logixboard.Models.Organization", null)
                        .WithMany()
                        .HasForeignKey("OrganizationsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Logixboard.Models.Shipment", null)
                        .WithMany()
                        .HasForeignKey("ShipmentsReferenceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Logixboard.Models.Shipment", b =>
                {
                    b.Navigation("TransportPacks");
                });
#pragma warning restore 612, 618
        }
    }
}

﻿// <auto-generated />
using System;
using BusTicketSystem.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BusTicketSystem.Migrations
{
    [DbContext(typeof(TicketSystemContext))]
    [Migration("20240704110259_PublicPropertiesRouteStop")]
    partial class PublicPropertiesRouteStop
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.6");

            modelBuilder.Entity("BusTicketSystem.Models.Bus", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("Capacity")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Model")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Buses");
                });

            modelBuilder.Entity("BusTicketSystem.Models.Edge", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("NextStopId")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("PreviousStopId")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("RouteId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("NextStopId");

                    b.HasIndex("PreviousStopId");

                    b.HasIndex("RouteId");

                    b.ToTable("Edge");
                });

            modelBuilder.Entity("BusTicketSystem.Models.Route", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("BusId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("BusId");

                    b.ToTable("Routes");
                });

            modelBuilder.Entity("BusTicketSystem.Models.Stop", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<double>("Latitude")
                        .HasColumnType("REAL");

                    b.Property<double>("Longitude")
                        .HasColumnType("REAL");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<int?>("RouteId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("RouteId");

                    b.ToTable("Stops");
                });

            modelBuilder.Entity("BusTicketSystem.Models.Edge", b =>
                {
                    b.HasOne("BusTicketSystem.Models.Stop", "NextStop")
                        .WithMany()
                        .HasForeignKey("NextStopId");

                    b.HasOne("BusTicketSystem.Models.Stop", "PreviousStop")
                        .WithMany()
                        .HasForeignKey("PreviousStopId");

                    b.HasOne("BusTicketSystem.Models.Route", null)
                        .WithMany("Edges")
                        .HasForeignKey("RouteId");

                    b.Navigation("NextStop");

                    b.Navigation("PreviousStop");
                });

            modelBuilder.Entity("BusTicketSystem.Models.Route", b =>
                {
                    b.HasOne("BusTicketSystem.Models.Bus", null)
                        .WithMany("Routes")
                        .HasForeignKey("BusId");
                });

            modelBuilder.Entity("BusTicketSystem.Models.Stop", b =>
                {
                    b.HasOne("BusTicketSystem.Models.Route", null)
                        .WithMany("Stops")
                        .HasForeignKey("RouteId");
                });

            modelBuilder.Entity("BusTicketSystem.Models.Bus", b =>
                {
                    b.Navigation("Routes");
                });

            modelBuilder.Entity("BusTicketSystem.Models.Route", b =>
                {
                    b.Navigation("Edges");

                    b.Navigation("Stops");
                });
#pragma warning restore 612, 618
        }
    }
}

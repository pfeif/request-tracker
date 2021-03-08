﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RequestTracker.Data;

namespace RequestTracker.Migrations
{
    [DbContext(typeof(RequestTrackerContext))]
    partial class RequestTrackerContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.3");

            modelBuilder.Entity("RequestTracker.Models.Client", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasMaxLength(20);

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasMaxLength(30);

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("ID");

                    b.ToTable("Client");
                });

            modelBuilder.Entity("RequestTracker.Models.ServiceRequest", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("ClientID")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime?>("CloseDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasMaxLength(500);

                    b.Property<DateTime>("OpenDate")
                        .HasColumnType("TEXT");

                    b.Property<int>("Status")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("TechnicianID")
                        .HasColumnType("INTEGER");

                    b.HasKey("ID");

                    b.HasIndex("ClientID");

                    b.HasIndex("TechnicianID");

                    b.ToTable("ServiceRequest");
                });

            modelBuilder.Entity("RequestTracker.Models.TechNote", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("Date")
                        .HasColumnType("TEXT");

                    b.Property<string>("Note")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasMaxLength(500);

                    b.Property<int>("ServiceRequestID")
                        .HasColumnType("INTEGER");

                    b.Property<int>("TechnicianID")
                        .HasColumnType("INTEGER");

                    b.HasKey("ID");

                    b.HasIndex("ServiceRequestID");

                    b.HasIndex("TechnicianID");

                    b.ToTable("TechNote");
                });

            modelBuilder.Entity("RequestTracker.Models.Technician", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasMaxLength(20);

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasMaxLength(30);

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("ID");

                    b.ToTable("Technician");
                });

            modelBuilder.Entity("RequestTracker.Models.ServiceRequest", b =>
                {
                    b.HasOne("RequestTracker.Models.Client", "Client")
                        .WithMany()
                        .HasForeignKey("ClientID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RequestTracker.Models.Technician", "Technician")
                        .WithMany()
                        .HasForeignKey("TechnicianID");
                });

            modelBuilder.Entity("RequestTracker.Models.TechNote", b =>
                {
                    b.HasOne("RequestTracker.Models.ServiceRequest", "ServiceRequest")
                        .WithMany("TechNotes")
                        .HasForeignKey("ServiceRequestID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RequestTracker.Models.Technician", "Technician")
                        .WithMany()
                        .HasForeignKey("TechnicianID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}

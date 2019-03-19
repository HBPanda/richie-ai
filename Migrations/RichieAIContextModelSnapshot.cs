﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RichieAI.Models;

namespace RichieAI.Migrations
{
    [DbContext(typeof(RichieAIContext))]
    partial class RichieAIContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.3-servicing-35854")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("RichieAI.Models.Cab", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Availability");

                    b.Property<string>("FirstName");

                    b.Property<string>("LastName");

                    b.Property<int>("RequestId");

                    b.Property<string>("TRN");

                    b.HasKey("Id");

                    b.ToTable("Cab");
                });

            modelBuilder.Entity("RichieAI.Models.CabManager", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("FirstName");

                    b.Property<string>("LastName");

                    b.HasKey("Id");

                    b.ToTable("CabManager");
                });

            modelBuilder.Entity("RichieAI.Models.Experience", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("ExperienceNavigationId");

                    b.Property<int>("RequestId");

                    b.Property<string>("comment");

                    b.Property<int>("rating");

                    b.HasKey("Id");

                    b.HasIndex("ExperienceNavigationId");

                    b.ToTable("Experience");
                });

            modelBuilder.Entity("RichieAI.Models.Passenger", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("FirstName");

                    b.Property<string>("LastName");

                    b.Property<int>("RequestId");

                    b.HasKey("Id");

                    b.ToTable("Passenger");
                });

            modelBuilder.Entity("RichieAI.Models.Request", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CabId");

                    b.Property<bool>("Confirmation");

                    b.Property<string>("Destination");

                    b.Property<int>("ExperienceId");

                    b.Property<string>("From");

                    b.Property<int>("PassengerId");

                    b.Property<DateTime>("RequestDate");

                    b.Property<int?>("RequestNavigationId");

                    b.HasKey("Id");

                    b.HasIndex("CabId")
                        .IsUnique();

                    b.HasIndex("ExperienceId")
                        .IsUnique();

                    b.HasIndex("PassengerId")
                        .IsUnique();

                    b.HasIndex("RequestNavigationId");

                    b.ToTable("Request");
                });

            modelBuilder.Entity("RichieAI.Models.UnavailableReport", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CabId");

                    b.Property<DateTime>("RequestDate");

                    b.Property<int?>("UnavailableReportNavigationId");

                    b.HasKey("Id");

                    b.HasIndex("CabId");

                    b.HasIndex("UnavailableReportNavigationId");

                    b.ToTable("UnavailableReport");
                });

            modelBuilder.Entity("RichieAI.Models.Experience", b =>
                {
                    b.HasOne("RichieAI.Models.CabManager", "ExperienceNavigation")
                        .WithMany("Experiences")
                        .HasForeignKey("ExperienceNavigationId");
                });

            modelBuilder.Entity("RichieAI.Models.Request", b =>
                {
                    b.HasOne("RichieAI.Models.Cab", "Cab")
                        .WithOne("RequestIdNavigation")
                        .HasForeignKey("RichieAI.Models.Request", "CabId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("RichieAI.Models.Experience", "Experience")
                        .WithOne("Request")
                        .HasForeignKey("RichieAI.Models.Request", "ExperienceId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("RichieAI.Models.Passenger", "Passenger")
                        .WithOne("RequestIdNavigation")
                        .HasForeignKey("RichieAI.Models.Request", "PassengerId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("RichieAI.Models.CabManager", "RequestNavigation")
                        .WithMany("Requests")
                        .HasForeignKey("RequestNavigationId");
                });

            modelBuilder.Entity("RichieAI.Models.UnavailableReport", b =>
                {
                    b.HasOne("RichieAI.Models.Cab", "Cab")
                        .WithMany("UnavailableReports")
                        .HasForeignKey("CabId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("RichieAI.Models.CabManager", "UnavailableReportNavigation")
                        .WithMany("UnavailableReports")
                        .HasForeignKey("UnavailableReportNavigationId");
                });
#pragma warning restore 612, 618
        }
    }
}

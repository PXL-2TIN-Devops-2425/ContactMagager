﻿// <auto-generated />
using System;
using HealthHub.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace HealthHub.Infrastructure.Migrations
{
    [DbContext(typeof(HealthHubDbContext))]
    [Migration("20241229094143_initial")]
    partial class initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("HealthHub.Domain.Appointment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("AppointmentDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("DoctorId")
                        .HasColumnType("int");

                    b.Property<string>("PatientNationalNumber")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Reason")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.HasKey("Id");

                    b.HasIndex("DoctorId");

                    b.ToTable("Appointments");

                    b.HasData(
                        new
                        {
                            Id = 9999,
                            AppointmentDate = new DateTime(2024, 12, 29, 0, 0, 0, 0, DateTimeKind.Local),
                            DoctorId = 1,
                            PatientNationalNumber = "111111",
                            Reason = "reason"
                        });
                });

            modelBuilder.Entity("HealthHub.Domain.Doctor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("SpecialtyId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("SpecialtyId");

                    b.ToTable("Doctors");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Email = "dr.sophie.vandamme@example.com",
                            FirstName = "Sophie",
                            LastName = "Van Damme",
                            Phone = "+32 479 12 34 56",
                            SpecialtyId = 1
                        },
                        new
                        {
                            Id = 2,
                            Email = "dr.Thomas.Devox@example.com",
                            FirstName = "Thomas",
                            LastName = "De Vos",
                            Phone = "+32 473 98 76 54",
                            SpecialtyId = 1
                        },
                        new
                        {
                            Id = 3,
                            Email = "dr.Marie.Dubois@example.com",
                            FirstName = "Marie",
                            LastName = "Dubois",
                            Phone = "+32 488 11 11 11",
                            SpecialtyId = 2
                        },
                        new
                        {
                            Id = 4,
                            Email = "dr.Axl.Moreau@example.be",
                            FirstName = "Axl",
                            LastName = "Moreau",
                            Phone = "+32 488 22 22 22",
                            SpecialtyId = 3
                        },
                        new
                        {
                            Id = 5,
                            Email = "dr.Peter.Mchealer@example.be",
                            FirstName = "Peter",
                            LastName = "McHealer",
                            Phone = "+32 499 33 33 33",
                            SpecialtyId = 3
                        },
                        new
                        {
                            Id = 6,
                            Email = "dr.Kate.Grant@example.be",
                            FirstName = "Kate",
                            LastName = "Grant",
                            Phone = "+32 473 55 55 55",
                            SpecialtyId = 3
                        },
                        new
                        {
                            Id = 7,
                            Email = "dr.Simon.DeJong@example.be",
                            FirstName = "Simon",
                            LastName = "De Jong",
                            Phone = "+32 474 66 66 22",
                            SpecialtyId = 4
                        },
                        new
                        {
                            Id = 8,
                            Email = "dr.Bryan.Devries@example.be",
                            FirstName = "Bryan",
                            LastName = "De Vries",
                            Phone = "+32 475 77 77 77",
                            SpecialtyId = 5
                        });
                });

            modelBuilder.Entity("HealthHub.Domain.Specialty", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Specialties");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Cardiology"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Dermatology"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Orthopedics"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Neurology"
                        },
                        new
                        {
                            Id = 5,
                            Name = "Pediatrics"
                        });
                });

            modelBuilder.Entity("HealthHub.Domain.Appointment", b =>
                {
                    b.HasOne("HealthHub.Domain.Doctor", "Doctor")
                        .WithMany()
                        .HasForeignKey("DoctorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Doctor");
                });

            modelBuilder.Entity("HealthHub.Domain.Doctor", b =>
                {
                    b.HasOne("HealthHub.Domain.Specialty", null)
                        .WithMany("Doctors")
                        .HasForeignKey("SpecialtyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("HealthHub.Domain.Specialty", b =>
                {
                    b.Navigation("Doctors");
                });
#pragma warning restore 612, 618
        }
    }
}

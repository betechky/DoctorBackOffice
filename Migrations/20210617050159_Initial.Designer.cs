﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DoctorOffice.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20210617050159_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 64)
                .HasAnnotation("ProductVersion", "6.0.0-preview.5.21301.9");

            modelBuilder.Entity("Doctor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Doctors");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Dr. Jason Rivera"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Dr. Michelle Tayson"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Dr. Leonor Rodrigo"
                        });
                });

            modelBuilder.Entity("IntakeForm", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Ailment")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("varchar(500)");

                    b.Property<int>("DoctorId")
                        .HasColumnType("int");

                    b.Property<int>("PatientId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("DoctorId");

                    b.HasIndex("PatientId");

                    b.ToTable("IntakeForms");
                });

            modelBuilder.Entity("Patient", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Address")
                        .HasColumnType("longtext");

                    b.Property<DateTime>("DateofBirth")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("HealthNumber")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("longtext");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Patients");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Address = "154, Ambertrail Winnipeg",
                            DateofBirth = new DateTime(1997, 2, 12, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            HealthNumber = 12301,
                            Name = "Marjorie Bautosa",
                            PhoneNumber = "204 223-4567"
                        },
                        new
                        {
                            Id = 2,
                            Address = "11, Ambertrail Winnipeg",
                            DateofBirth = new DateTime(2009, 9, 9, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            HealthNumber = 12402,
                            Name = "Stephanie Letter",
                            PhoneNumber = "204 999999"
                        });
                });

            modelBuilder.Entity("IntakeForm", b =>
                {
                    b.HasOne("Doctor", "Doctor")
                        .WithMany()
                        .HasForeignKey("DoctorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Patient", "Patient")
                        .WithMany()
                        .HasForeignKey("PatientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Doctor");

                    b.Navigation("Patient");
                });
#pragma warning restore 612, 618
        }
    }
}

﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ShiftSchedulerApi.Data;

namespace ShiftSchedulerApi.Migrations
{
    [DbContext(typeof(ShiftSchedulerDbContext))]
    partial class ShiftSchedulerDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.11-servicing-32099")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ShiftSchedulerApi.Models.Shift", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CreatedByUserId");

                    b.Property<string>("Description");

                    b.Property<DateTime>("End");

                    b.Property<DateTime>("Start");

                    b.Property<long?>("TeamId");

                    b.HasKey("Id");

                    b.HasIndex("TeamId");

                    b.ToTable("Shifts");
                });

            modelBuilder.Entity("ShiftSchedulerApi.Models.ShiftUser", b =>
                {
                    b.Property<long>("ShiftId");

                    b.Property<long>("UserId");

                    b.HasKey("ShiftId", "UserId");

                    b.HasIndex("UserId");

                    b.ToTable("ShiftUser");
                });

            modelBuilder.Entity("ShiftSchedulerApi.Models.Team", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long>("AdminUserId");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Team");
                });

            modelBuilder.Entity("ShiftSchedulerApi.Models.User", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email");

                    b.Property<string>("Name");

                    b.Property<string>("PhoneNumber");

                    b.Property<long?>("TeamId");

                    b.HasKey("Id");

                    b.HasIndex("TeamId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("ShiftSchedulerApi.Models.Shift", b =>
                {
                    b.HasOne("ShiftSchedulerApi.Models.Team")
                        .WithMany("Shifts")
                        .HasForeignKey("TeamId");
                });

            modelBuilder.Entity("ShiftSchedulerApi.Models.ShiftUser", b =>
                {
                    b.HasOne("ShiftSchedulerApi.Models.Shift", "Shift")
                        .WithMany("Attendees")
                        .HasForeignKey("ShiftId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("ShiftSchedulerApi.Models.User", "User")
                        .WithMany("Shifts")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ShiftSchedulerApi.Models.User", b =>
                {
                    b.HasOne("ShiftSchedulerApi.Models.Team")
                        .WithMany("Users")
                        .HasForeignKey("TeamId");
                });
#pragma warning restore 612, 618
        }
    }
}

﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TaskManagementService.DBContext;

namespace TaskManagementService.Migrations
{
    [DbContext(typeof(TaskContext))]
    [Migration("20200413104106_Main")]
    partial class Main
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("TaskManagementService.DBContext.Entities.ServiceSubtask", b =>
                {
                    b.Property<int>("SubTaskId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("FinishDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("State")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("TaskId")
                        .HasColumnType("int");

                    b.HasKey("SubTaskId");

                    b.HasIndex("TaskId");

                    b.ToTable("SubTasks");

                    b.HasData(
                        new
                        {
                            SubTaskId = 1,
                            Description = "d Package",
                            FinishDate = new DateTime(2020, 4, 13, 11, 41, 6, 245, DateTimeKind.Local).AddTicks(6934),
                            Name = "d",
                            StartDate = new DateTime(2020, 4, 13, 11, 41, 6, 245, DateTimeKind.Local).AddTicks(6913),
                            State = "Planned",
                            TaskId = 1
                        },
                        new
                        {
                            SubTaskId = 2,
                            Description = "c Package",
                            FinishDate = new DateTime(2020, 4, 13, 11, 41, 6, 245, DateTimeKind.Local).AddTicks(7845),
                            Name = "c",
                            StartDate = new DateTime(2020, 4, 13, 11, 41, 6, 245, DateTimeKind.Local).AddTicks(7832),
                            State = "inProgress",
                            TaskId = 1
                        },
                        new
                        {
                            SubTaskId = 3,
                            Description = "a Package",
                            FinishDate = new DateTime(2020, 4, 13, 11, 41, 6, 245, DateTimeKind.Local).AddTicks(7867),
                            Name = "a",
                            StartDate = new DateTime(2020, 4, 13, 11, 41, 6, 245, DateTimeKind.Local).AddTicks(7864),
                            State = "Planned",
                            TaskId = 2
                        },
                        new
                        {
                            SubTaskId = 4,
                            Description = "b Package",
                            FinishDate = new DateTime(2020, 4, 13, 11, 41, 6, 245, DateTimeKind.Local).AddTicks(7872),
                            Name = "b",
                            StartDate = new DateTime(2020, 4, 13, 11, 41, 6, 245, DateTimeKind.Local).AddTicks(7870),
                            State = "Planned",
                            TaskId = 2
                        });
                });

            modelBuilder.Entity("TaskManagementService.DBContext.Entities.ServiceTask", b =>
                {
                    b.Property<int>("TaskId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("FinishDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("State")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("TaskId");

                    b.ToTable("Tasks");

                    b.HasData(
                        new
                        {
                            TaskId = 1,
                            Description = "Clothes Package",
                            FinishDate = new DateTime(2020, 4, 13, 11, 41, 6, 244, DateTimeKind.Local).AddTicks(4070),
                            Name = "Clothing",
                            StartDate = new DateTime(2020, 4, 13, 11, 41, 6, 241, DateTimeKind.Local).AddTicks(2311),
                            State = "inProgress"
                        },
                        new
                        {
                            TaskId = 2,
                            Description = "Bride Dress",
                            FinishDate = new DateTime(2020, 4, 13, 11, 41, 6, 244, DateTimeKind.Local).AddTicks(5496),
                            Name = "Dresses",
                            StartDate = new DateTime(2020, 4, 13, 11, 41, 6, 244, DateTimeKind.Local).AddTicks(5475),
                            State = "inProgress"
                        });
                });

            modelBuilder.Entity("TaskManagementService.DBContext.Entities.ServiceSubtask", b =>
                {
                    b.HasOne("TaskManagementService.DBContext.Entities.ServiceTask", "ServiceTask")
                        .WithMany("ServiceSubtask")
                        .HasForeignKey("TaskId");
                });
#pragma warning restore 612, 618
        }
    }
}
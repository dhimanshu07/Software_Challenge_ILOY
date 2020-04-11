﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TaskManagementService.DBContext;

namespace TaskManagementService.Migrations
{
    [DbContext(typeof(TaskContext))]
    partial class TaskContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
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
                            FinishDate = new DateTime(2020, 4, 10, 14, 33, 1, 393, DateTimeKind.Local).AddTicks(8682),
                            Name = "d",
                            StartDate = new DateTime(2020, 4, 10, 14, 33, 1, 393, DateTimeKind.Local).AddTicks(8647),
                            State = "in_progress",
                            TaskId = 1
                        },
                        new
                        {
                            SubTaskId = 2,
                            Description = "c Package",
                            FinishDate = new DateTime(2020, 4, 10, 14, 33, 1, 394, DateTimeKind.Local).AddTicks(103),
                            Name = "c",
                            StartDate = new DateTime(2020, 4, 10, 14, 33, 1, 394, DateTimeKind.Local).AddTicks(74),
                            State = "in_progress",
                            TaskId = 1
                        },
                        new
                        {
                            SubTaskId = 3,
                            Description = "a Package",
                            FinishDate = new DateTime(2020, 4, 10, 14, 33, 1, 394, DateTimeKind.Local).AddTicks(134),
                            Name = "a",
                            StartDate = new DateTime(2020, 4, 10, 14, 33, 1, 394, DateTimeKind.Local).AddTicks(130),
                            State = "in_progress",
                            TaskId = 2
                        },
                        new
                        {
                            SubTaskId = 4,
                            Description = "b Package",
                            FinishDate = new DateTime(2020, 4, 10, 14, 33, 1, 394, DateTimeKind.Local).AddTicks(142),
                            Name = "b",
                            StartDate = new DateTime(2020, 4, 10, 14, 33, 1, 394, DateTimeKind.Local).AddTicks(138),
                            State = "in_progress",
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
                            FinishDate = new DateTime(2020, 4, 10, 14, 33, 1, 391, DateTimeKind.Local).AddTicks(6492),
                            Name = "Clothing",
                            StartDate = new DateTime(2020, 4, 10, 14, 33, 1, 387, DateTimeKind.Local).AddTicks(6057),
                            State = "in_progress"
                        },
                        new
                        {
                            TaskId = 2,
                            Description = "Bride Dress",
                            FinishDate = new DateTime(2020, 4, 10, 14, 33, 1, 392, DateTimeKind.Local).AddTicks(104),
                            Name = "Dresses",
                            StartDate = new DateTime(2020, 4, 10, 14, 33, 1, 392, DateTimeKind.Local).AddTicks(72),
                            State = "in_progress"
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

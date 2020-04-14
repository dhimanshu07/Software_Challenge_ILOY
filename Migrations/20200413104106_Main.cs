using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TaskManagementService.Migrations
{
    public partial class Main : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Tasks",
                columns: table => new
                {
                    TaskId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    StartDate = table.Column<DateTime>(nullable: false),
                    FinishDate = table.Column<DateTime>(nullable: false),
                    State = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tasks", x => x.TaskId);
                });

            migrationBuilder.CreateTable(
                name: "SubTasks",
                columns: table => new
                {
                    SubTaskId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TaskId = table.Column<int>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    StartDate = table.Column<DateTime>(nullable: false),
                    FinishDate = table.Column<DateTime>(nullable: false),
                    State = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubTasks", x => x.SubTaskId);
                    table.ForeignKey(
                        name: "FK_SubTasks_Tasks_TaskId",
                        column: x => x.TaskId,
                        principalTable: "Tasks",
                        principalColumn: "TaskId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Tasks",
                columns: new[] { "TaskId", "Description", "FinishDate", "Name", "StartDate", "State" },
                values: new object[] { 1, "Clothes Package", new DateTime(2020, 4, 13, 11, 41, 6, 244, DateTimeKind.Local).AddTicks(4070), "Clothing", new DateTime(2020, 4, 13, 11, 41, 6, 241, DateTimeKind.Local).AddTicks(2311), "inProgress" });

            migrationBuilder.InsertData(
                table: "Tasks",
                columns: new[] { "TaskId", "Description", "FinishDate", "Name", "StartDate", "State" },
                values: new object[] { 2, "Bride Dress", new DateTime(2020, 4, 13, 11, 41, 6, 244, DateTimeKind.Local).AddTicks(5496), "Dresses", new DateTime(2020, 4, 13, 11, 41, 6, 244, DateTimeKind.Local).AddTicks(5475), "inProgress" });

            migrationBuilder.InsertData(
                table: "SubTasks",
                columns: new[] { "SubTaskId", "Description", "FinishDate", "Name", "StartDate", "State", "TaskId" },
                values: new object[,]
                {
                    { 1, "d Package", new DateTime(2020, 4, 13, 11, 41, 6, 245, DateTimeKind.Local).AddTicks(6934), "d", new DateTime(2020, 4, 13, 11, 41, 6, 245, DateTimeKind.Local).AddTicks(6913), "Planned", 1 },
                    { 2, "c Package", new DateTime(2020, 4, 13, 11, 41, 6, 245, DateTimeKind.Local).AddTicks(7845), "c", new DateTime(2020, 4, 13, 11, 41, 6, 245, DateTimeKind.Local).AddTicks(7832), "inProgress", 1 },
                    { 3, "a Package", new DateTime(2020, 4, 13, 11, 41, 6, 245, DateTimeKind.Local).AddTicks(7867), "a", new DateTime(2020, 4, 13, 11, 41, 6, 245, DateTimeKind.Local).AddTicks(7864), "Planned", 2 },
                    { 4, "b Package", new DateTime(2020, 4, 13, 11, 41, 6, 245, DateTimeKind.Local).AddTicks(7872), "b", new DateTime(2020, 4, 13, 11, 41, 6, 245, DateTimeKind.Local).AddTicks(7870), "Planned", 2 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_SubTasks_TaskId",
                table: "SubTasks",
                column: "TaskId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SubTasks");

            migrationBuilder.DropTable(
                name: "Tasks");
        }
    }
}

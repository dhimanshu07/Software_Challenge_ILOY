using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TaskManagementService.Migrations
{
    public partial class Initial : Migration
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
                values: new object[] { 1, "Clothes Package", new DateTime(2020, 4, 12, 10, 51, 44, 921, DateTimeKind.Local).AddTicks(505), "Clothing", new DateTime(2020, 4, 12, 10, 51, 44, 915, DateTimeKind.Local).AddTicks(7741), "inProgress" });

            migrationBuilder.InsertData(
                table: "Tasks",
                columns: new[] { "TaskId", "Description", "FinishDate", "Name", "StartDate", "State" },
                values: new object[] { 2, "Bride Dress", new DateTime(2020, 4, 12, 10, 51, 44, 921, DateTimeKind.Local).AddTicks(2580), "Dresses", new DateTime(2020, 4, 12, 10, 51, 44, 921, DateTimeKind.Local).AddTicks(2549), "inProgress" });

            migrationBuilder.InsertData(
                table: "SubTasks",
                columns: new[] { "SubTaskId", "Description", "FinishDate", "Name", "StartDate", "State", "TaskId" },
                values: new object[,]
                {
                    { 1, "d Package", new DateTime(2020, 4, 12, 10, 51, 44, 923, DateTimeKind.Local).AddTicks(757), "d", new DateTime(2020, 4, 12, 10, 51, 44, 923, DateTimeKind.Local).AddTicks(712), "Planned", 1 },
                    { 2, "c Package", new DateTime(2020, 4, 12, 10, 51, 44, 923, DateTimeKind.Local).AddTicks(2315), "c", new DateTime(2020, 4, 12, 10, 51, 44, 923, DateTimeKind.Local).AddTicks(2290), "inProgress", 1 },
                    { 3, "a Package", new DateTime(2020, 4, 12, 10, 51, 44, 923, DateTimeKind.Local).AddTicks(2348), "a", new DateTime(2020, 4, 12, 10, 51, 44, 923, DateTimeKind.Local).AddTicks(2345), "Planned", 2 },
                    { 4, "b Package", new DateTime(2020, 4, 12, 10, 51, 44, 923, DateTimeKind.Local).AddTicks(2357), "b", new DateTime(2020, 4, 12, 10, 51, 44, 923, DateTimeKind.Local).AddTicks(2353), "Planned", 2 }
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

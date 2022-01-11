using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace aspnetserver.NewFolder.Migrations
{
    public partial class FirstMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Plants",
                columns: table => new
                {
                    plantId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    Content = table.Column<string>(type: "TEXT", maxLength: 100000, nullable: false),
                    WateringStatus = table.Column<bool>(type: "INTEGER", nullable: false),
                    lastWatered = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Plants", x => x.plantId);
                });

            migrationBuilder.InsertData(
                table: "Plants",
                columns: new[] { "plantId", "Content", "Name", "WateringStatus", "lastWatered" },
                values: new object[] { 1, "This is plant 1 and it has some very interesting traits.", "Rose", false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "Plants",
                columns: new[] { "plantId", "Content", "Name", "WateringStatus", "lastWatered" },
                values: new object[] { 2, "This is plant 2 and it has some very interesting traits.", "Habiscus", false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "Plants",
                columns: new[] { "plantId", "Content", "Name", "WateringStatus", "lastWatered" },
                values: new object[] { 3, "This is plant 3 and it has some very interesting traits.", "Jasmine", false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "Plants",
                columns: new[] { "plantId", "Content", "Name", "WateringStatus", "lastWatered" },
                values: new object[] { 4, "This is plant 4 and it has some very interesting traits.", "Sunflower", false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "Plants",
                columns: new[] { "plantId", "Content", "Name", "WateringStatus", "lastWatered" },
                values: new object[] { 5, "This is plant 5 and it has some very interesting traits.", "Yellow Tulip", false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Plants");
        }
    }
}

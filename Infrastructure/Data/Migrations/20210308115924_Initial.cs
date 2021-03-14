using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Data.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Positions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Positions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PersonalId = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    Gender = table.Column<string>(type: "nvarchar(10)", nullable: false),
                    BirthDate = table.Column<DateTime>(type: "date", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    DateReleased = table.Column<DateTime>(type: "date", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(9)", maxLength: 9, nullable: false),
                    PositionId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Employees_Positions_PositionId",
                        column: x => x.PositionId,
                        principalTable: "Positions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Positions",
                columns: new[] { "Id", "Name" },
                values: new object[] { 1, "Developer" });

            migrationBuilder.InsertData(
                table: "Positions",
                columns: new[] { "Id", "Name" },
                values: new object[] { 2, "HR" });

            migrationBuilder.InsertData(
                table: "Positions",
                columns: new[] { "Id", "Name" },
                values: new object[] { 3, "Designer" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "BirthDate", "DateReleased", "FirstName", "Gender", "LastName", "PersonalId", "PhoneNumber", "PositionId", "Status" },
                values: new object[,]
                {
                    { 1, new DateTime(1990, 4, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "John", "Male", "Doe", "19001304662", "941293812", 1, "Regular" },
                    { 3, new DateTime(1690, 9, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 3, 8, 0, 0, 0, 0, DateTimeKind.Local), "Badri", "Male", "Shubladze", "18071304662", "941293312", 1, "Released" },
                    { 5, new DateTime(2008, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "C", "Male", "Sharp", "18071304102", "941294312", 1, "Regular" },
                    { 2, new DateTime(1890, 2, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Grisha", "Male", "Oniani", "18001304662", "911293812", 3, "NonRegular" },
                    { 4, new DateTime(2018, 11, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 3, 8, 0, 0, 0, 0, DateTimeKind.Local), "Greta", "Female", "Thunberg", "18071304772", "941290312", 3, "Released" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Employees_PersonalId",
                table: "Employees",
                column: "PersonalId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Employees_PhoneNumber",
                table: "Employees",
                column: "PhoneNumber",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Employees_PositionId",
                table: "Employees",
                column: "PositionId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "Positions");
        }
    }
}

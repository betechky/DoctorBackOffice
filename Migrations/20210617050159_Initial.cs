using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DoctorOffice.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Doctors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "longtext", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Doctors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Patients",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "longtext", nullable: true),
                    DateofBirth = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    HealthNumber = table.Column<int>(type: "int", nullable: false),
                    Address = table.Column<string>(type: "longtext", nullable: true),
                    PhoneNumber = table.Column<string>(type: "longtext", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Patients", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "IntakeForms",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Ailment = table.Column<string>(type: "varchar(500)", maxLength: 500, nullable: false),
                    DoctorId = table.Column<int>(type: "int", nullable: false),
                    PatientId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IntakeForms", x => x.Id);
                    table.ForeignKey(
                        name: "FK_IntakeForms_Doctors_DoctorId",
                        column: x => x.DoctorId,
                        principalTable: "Doctors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_IntakeForms_Patients_PatientId",
                        column: x => x.PatientId,
                        principalTable: "Patients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Doctors",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Dr. Jason Rivera" },
                    { 2, "Dr. Michelle Tayson" },
                    { 3, "Dr. Leonor Rodrigo" }
                });

            migrationBuilder.InsertData(
                table: "Patients",
                columns: new[] { "Id", "Address", "DateofBirth", "HealthNumber", "Name", "PhoneNumber" },
                values: new object[,]
                {
                    { 1, "154, Ambertrail Winnipeg", new DateTime(1997, 2, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 12301, "Marjorie Bautosa", "204 223-4567" },
                    { 2, "11, Ambertrail Winnipeg", new DateTime(2009, 9, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), 12402, "Stephanie Letter", "204 999999" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_IntakeForms_DoctorId",
                table: "IntakeForms",
                column: "DoctorId");

            migrationBuilder.CreateIndex(
                name: "IX_IntakeForms_PatientId",
                table: "IntakeForms",
                column: "PatientId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "IntakeForms");

            migrationBuilder.DropTable(
                name: "Doctors");

            migrationBuilder.DropTable(
                name: "Patients");
        }
    }
}

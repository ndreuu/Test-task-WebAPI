using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TestTaskSolution.Migrations
{
    /// <inheritdoc />
    public partial class Aboba : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Results",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FileName = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    DeltaTime = table.Column<decimal>(type: "decimal(20,0)", nullable: false),
                    DateFirstOperation = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AvarageTime = table.Column<double>(type: "float", nullable: false),
                    AvarageIndex = table.Column<double>(type: "float", nullable: false),
                    MedianIndex = table.Column<double>(type: "float", nullable: false),
                    MaxIndex = table.Column<double>(type: "float", nullable: false),
                    MinIndex = table.Column<double>(type: "float", nullable: false),
                    CountOfRecords = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Results", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Values",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FileName = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Time = table.Column<decimal>(type: "decimal(20,0)", nullable: false),
                    Index = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Values", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Results_AvarageIndex",
                table: "Results",
                column: "AvarageIndex");

            migrationBuilder.CreateIndex(
                name: "IX_Results_AvarageTime",
                table: "Results",
                column: "AvarageTime");

            migrationBuilder.CreateIndex(
                name: "IX_Results_DateFirstOperation",
                table: "Results",
                column: "DateFirstOperation");

            migrationBuilder.CreateIndex(
                name: "IX_Results_FileName",
                table: "Results",
                column: "FileName");

            migrationBuilder.CreateIndex(
                name: "IX_Values_FileName",
                table: "Values",
                column: "FileName");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Results");

            migrationBuilder.DropTable(
                name: "Values");
        }
    }
}

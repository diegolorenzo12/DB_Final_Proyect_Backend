using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace projecto_bases_de_datos_api.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Buildings",
                columns: table => new
                {
                    BuildingID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Location = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Buildings", x => x.BuildingID);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Role = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    BuildingID = table.Column<int>(type: "int", nullable: false),
                    Email = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Phone = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserID);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ParkingSpots",
                columns: table => new
                {
                    ParkingSpotID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Location = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IsOccupied = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    Type = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    BuildingID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ParkingSpots", x => x.ParkingSpotID);
                    table.ForeignKey(
                        name: "FK_ParkingSpots_Buildings_BuildingID",
                        column: x => x.BuildingID,
                        principalTable: "Buildings",
                        principalColumn: "BuildingID",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Vehicles",
                columns: table => new
                {
                    VehicleID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Type = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Model = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Color = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    LicensePlate = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    UserID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vehicles", x => x.VehicleID);
                    table.ForeignKey(
                        name: "FK_Vehicles_Users_UserID",
                        column: x => x.UserID,
                        principalTable: "Users",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ParkingSpotAssignments",
                columns: table => new
                {
                    ParkingSpotID = table.Column<int>(type: "int", nullable: false),
                    UserID = table.Column<int>(type: "int", nullable: false),
                    ParkingSpotAssignmentID = table.Column<int>(type: "int", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ParkingSpotAssignments", x => new { x.ParkingSpotID, x.UserID });
                    table.ForeignKey(
                        name: "FK_ParkingSpotAssignments_ParkingSpots_ParkingSpotID",
                        column: x => x.ParkingSpotID,
                        principalTable: "ParkingSpots",
                        principalColumn: "ParkingSpotID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ParkingSpotAssignments_Users_UserID",
                        column: x => x.UserID,
                        principalTable: "Users",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ParkingRecords",
                columns: table => new
                {
                    ParkingRecordID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ParkingSpotID = table.Column<int>(type: "int", nullable: false),
                    UserID = table.Column<int>(type: "int", nullable: false),
                    VehicleID = table.Column<int>(type: "int", nullable: false),
                    EntryTime = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    ExitTime = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ParkingRecords", x => x.ParkingRecordID);
                    table.ForeignKey(
                        name: "FK_ParkingRecords_ParkingSpots_ParkingSpotID",
                        column: x => x.ParkingSpotID,
                        principalTable: "ParkingSpots",
                        principalColumn: "ParkingSpotID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ParkingRecords_Users_UserID",
                        column: x => x.UserID,
                        principalTable: "Users",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ParkingRecords_Vehicles_VehicleID",
                        column: x => x.VehicleID,
                        principalTable: "Vehicles",
                        principalColumn: "VehicleID",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_ParkingRecords_ParkingSpotID",
                table: "ParkingRecords",
                column: "ParkingSpotID");

            migrationBuilder.CreateIndex(
                name: "IX_ParkingRecords_UserID",
                table: "ParkingRecords",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_ParkingRecords_VehicleID",
                table: "ParkingRecords",
                column: "VehicleID");

            migrationBuilder.CreateIndex(
                name: "IX_ParkingSpotAssignments_UserID",
                table: "ParkingSpotAssignments",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_ParkingSpots_BuildingID",
                table: "ParkingSpots",
                column: "BuildingID");

            migrationBuilder.CreateIndex(
                name: "IX_Vehicles_UserID",
                table: "Vehicles",
                column: "UserID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ParkingRecords");

            migrationBuilder.DropTable(
                name: "ParkingSpotAssignments");

            migrationBuilder.DropTable(
                name: "Vehicles");

            migrationBuilder.DropTable(
                name: "ParkingSpots");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Buildings");
        }
    }
}

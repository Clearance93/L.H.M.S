using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ClinicalApp.Migrations
{
    public partial class Threemoretables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Meds",
                columns: table => new
                {
                    MedicineId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NameOfMedication = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Discription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TypOfMedication = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TypeOfChronic = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Meds", x => x.MedicineId);
                });

            migrationBuilder.CreateTable(
                name: "MedssToBeCollected",
                columns: table => new
                {
                    MedicId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PatientId = table.Column<int>(type: "int", nullable: false),
                    Total = table.Column<double>(type: "float", nullable: false),
                    PickUpTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MedsStatus = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FullNames = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ContactNumber = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedssToBeCollected", x => x.MedicId);
                    table.ForeignKey(
                        name: "FK_MedssToBeCollected_Patients_PatientId",
                        column: x => x.PatientId,
                        principalTable: "Patients",
                        principalColumn: "PatientId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MedsCollectionDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MedicId = table.Column<int>(type: "int", nullable: false),
                    CollectionDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MedicineId = table.Column<int>(type: "int", nullable: false),
                    Count = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false),
                    FullNames = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ContacNumber = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedsCollectionDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MedsCollectionDetails_Meds_MedicineId",
                        column: x => x.MedicineId,
                        principalTable: "Meds",
                        principalColumn: "MedicineId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MedsCollectionDetails_MedssToBeCollected_MedicId",
                        column: x => x.MedicId,
                        principalTable: "MedssToBeCollected",
                        principalColumn: "MedicId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MedsCollectionDetails_MedicId",
                table: "MedsCollectionDetails",
                column: "MedicId");

            migrationBuilder.CreateIndex(
                name: "IX_MedsCollectionDetails_MedicineId",
                table: "MedsCollectionDetails",
                column: "MedicineId");

            migrationBuilder.CreateIndex(
                name: "IX_MedssToBeCollected_PatientId",
                table: "MedssToBeCollected",
                column: "PatientId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MedsCollectionDetails");

            migrationBuilder.DropTable(
                name: "Meds");

            migrationBuilder.DropTable(
                name: "MedssToBeCollected");
        }
    }
}

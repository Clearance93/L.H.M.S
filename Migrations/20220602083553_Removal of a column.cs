using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ClinicalApp.Migrations
{
    public partial class Removalofacolumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Gender",
                table: "Patients");

            migrationBuilder.DropColumn(
                name: "Gender",
                table: "Patient_Of_Hospital");

            migrationBuilder.DropColumn(
                name: "Gender",
                table: "Patient_In_Hospital");

            migrationBuilder.DropColumn(
                name: "Gender",
                table: "MetinityWards");

            migrationBuilder.DropColumn(
                name: "Gender",
                table: "ManWards");

            migrationBuilder.DropColumn(
                name: "Gender",
                table: "FemaleWards");

            migrationBuilder.DropColumn(
                name: "Gender",
                table: "ChildrenWards");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Gender",
                table: "Patients",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Gender",
                table: "Patient_Of_Hospital",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Gender",
                table: "Patient_In_Hospital",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Gender",
                table: "MetinityWards",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Gender",
                table: "ManWards",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Gender",
                table: "FemaleWards",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Gender",
                table: "ChildrenWards",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}

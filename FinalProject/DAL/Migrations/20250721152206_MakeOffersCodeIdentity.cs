using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    public partial class MakeOffersCodeIdentity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK__JobOffer__F4BD6BD8585C6A1F",
                table: "JobOffer");

            migrationBuilder.DropColumn(
                name: "OffersCode",
                table: "JobOffer");

            migrationBuilder.AddColumn<int>(
                name: "OffersCode",
                table: "JobOffer",
                type: "int",
                nullable: false)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK__JobOffer__F4BD6BD8585C6A1F",
                table: "JobOffer",
                column: "OffersCode");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ApplicationDate",
                table: "JobOffer",
                type: "datetime",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK__JobOffer__F4BD6BD8585C6A1F",
                table: "JobOffer");

            migrationBuilder.DropColumn(
                name: "OffersCode",
                table: "JobOffer");

            migrationBuilder.AddColumn<int>(
                name: "OffersCode",
                table: "JobOffer",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK__JobOffer__F4BD6BD8585C6A1F",
                table: "JobOffer",
                column: "OffersCode");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ApplicationDate",
                table: "JobOffer",
                type: "datetime",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldNullable: true);
        }
    }
}
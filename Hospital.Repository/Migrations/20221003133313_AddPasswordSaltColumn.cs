using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Hospital.Repositories.Migrations
{
    public partial class AddPasswordSaltColumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Password",
                table: "Patients");

            migrationBuilder.DropColumn(
                name: "Password",
                table: "Doctors");

            migrationBuilder.AddColumn<byte[]>(
                name: "PasswordHash",
                table: "Patients",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "PasswordSalt",
                table: "Patients",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "PasswordHash",
                table: "Doctors",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "PasswordSalt",
                table: "Doctors",
                type: "varbinary(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PasswordHash",
                table: "Patients");

            migrationBuilder.DropColumn(
                name: "PasswordSalt",
                table: "Patients");

            migrationBuilder.DropColumn(
                name: "PasswordHash",
                table: "Doctors");

            migrationBuilder.DropColumn(
                name: "PasswordSalt",
                table: "Doctors");

            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "Patients",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "Doctors",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace DataLayer.Migrations
{
    public partial class LengthChange : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Photo",
                table: "Portfolio",
                maxLength: 200,
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Photo",
                table: "Portfolio",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 200,
                oldNullable: true);
        }
    }
}

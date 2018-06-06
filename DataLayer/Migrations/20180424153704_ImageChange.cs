using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace DataLayer.Migrations
{
    public partial class ImageChange : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Photo",
                table: "Portfolio",
                nullable: true,
                oldClrType: typeof(byte[]),
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<byte[]>(
                name: "Photo",
                table: "Portfolio",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}

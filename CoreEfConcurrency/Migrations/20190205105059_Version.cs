using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CoreEfConcurrency.Migrations
{
    public partial class Version : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte[]>(
                name: "Version",
                table: "Blogs",
                rowVersion: true,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Version",
                table: "Blogs");
        }
    }
}

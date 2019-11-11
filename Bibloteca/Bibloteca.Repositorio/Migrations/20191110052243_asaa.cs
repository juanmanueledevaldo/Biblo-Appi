using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Bibloteca.Repositorio.Migrations
{
    public partial class asaa : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DetId",
                table: "Prestamo",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UsuId",
                table: "Prestamo",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DetId",
                table: "Prestamo");

            migrationBuilder.DropColumn(
                name: "UsuId",
                table: "Prestamo");
        }
    }
}

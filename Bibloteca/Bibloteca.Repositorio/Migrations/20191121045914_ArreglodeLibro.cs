using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Bibloteca.Repositorio.Migrations
{
    public partial class ArreglodeLibro : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Año",
                table: "Libro",
                newName: "Anio");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Anio",
                table: "Libro",
                newName: "Año");
        }
    }
}

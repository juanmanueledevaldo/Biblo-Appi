using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Bibloteca.Repositorio.Migrations
{
    public partial class a : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Libro",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Autor = table.Column<string>(maxLength: 50, nullable: false),
                    Año = table.Column<string>(nullable: false),
                    Borrado = table.Column<bool>(nullable: false),
                    Editorial = table.Column<string>(nullable: false),
                    Estante = table.Column<string>(maxLength: 30, nullable: false),
                    Folio = table.Column<string>(nullable: false),
                    Genero = table.Column<string>(maxLength: 50, nullable: false),
                    Imagen = table.Column<string>(nullable: false),
                    Nombre = table.Column<string>(maxLength: 100, nullable: false),
                    Paginas = table.Column<int>(nullable: false),
                    Stock = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Libro", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Usuario",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Activo = table.Column<bool>(nullable: false),
                    Apellido = table.Column<string>(maxLength: 100, nullable: false),
                    Borrado = table.Column<bool>(nullable: false),
                    Contraseña = table.Column<string>(maxLength: 10, nullable: false),
                    Mote = table.Column<string>(maxLength: 25, nullable: false),
                    Nombre = table.Column<string>(maxLength: 100, nullable: false),
                    Tipo = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuario", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Prestamo",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Devolucion = table.Column<DateTime>(nullable: false),
                    Estado = table.Column<string>(nullable: false),
                    Fecha = table.Column<DateTime>(nullable: false),
                    Folio = table.Column<string>(nullable: false),
                    UsuarioId = table.Column<int>(nullable: true),
                    Usuarioi = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prestamo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Prestamo_Usuario_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Detalle",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    LibroId = table.Column<int>(nullable: true),
                    Libroi = table.Column<int>(nullable: true),
                    PrestamoId = table.Column<int>(nullable: true),
                    Prestamoi = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Detalle", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Detalle_Libro_LibroId",
                        column: x => x.LibroId,
                        principalTable: "Libro",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Detalle_Prestamo_PrestamoId",
                        column: x => x.PrestamoId,
                        principalTable: "Prestamo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Detalle_LibroId",
                table: "Detalle",
                column: "LibroId");

            migrationBuilder.CreateIndex(
                name: "IX_Detalle_PrestamoId",
                table: "Detalle",
                column: "PrestamoId");

            migrationBuilder.CreateIndex(
                name: "IX_Prestamo_UsuarioId",
                table: "Prestamo",
                column: "UsuarioId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Detalle");

            migrationBuilder.DropTable(
                name: "Libro");

            migrationBuilder.DropTable(
                name: "Prestamo");

            migrationBuilder.DropTable(
                name: "Usuario");
        }
    }
}

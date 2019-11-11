using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Bibloteca.Repositorio.Migrations
{
    public partial class a : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Detalle_Libro_LibroId",
                table: "Detalle");

            migrationBuilder.DropForeignKey(
                name: "FK_Prestamo_Detalle_DetalleId",
                table: "Prestamo");

            migrationBuilder.DropForeignKey(
                name: "FK_Prestamo_Usuario_UsuarioUser",
                table: "Prestamo");

            migrationBuilder.RenameColumn(
                name: "UsuarioUser",
                table: "Prestamo",
                newName: "Usu");

            migrationBuilder.RenameColumn(
                name: "DetalleId",
                table: "Prestamo",
                newName: "Det");

            migrationBuilder.RenameIndex(
                name: "IX_Prestamo_UsuarioUser",
                table: "Prestamo",
                newName: "IX_Prestamo_Usu");

            migrationBuilder.RenameIndex(
                name: "IX_Prestamo_DetalleId",
                table: "Prestamo",
                newName: "IX_Prestamo_Det");

            migrationBuilder.RenameColumn(
                name: "LibroId",
                table: "Detalle",
                newName: "Lib");

            migrationBuilder.RenameIndex(
                name: "IX_Detalle_LibroId",
                table: "Detalle",
                newName: "IX_Detalle_Lib");

            migrationBuilder.AddForeignKey(
                name: "FK_Detalle_Libro_Lib",
                table: "Detalle",
                column: "Lib",
                principalTable: "Libro",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Prestamo_Detalle_Det",
                table: "Prestamo",
                column: "Det",
                principalTable: "Detalle",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Prestamo_Usuario_Usu",
                table: "Prestamo",
                column: "Usu",
                principalTable: "Usuario",
                principalColumn: "User",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Detalle_Libro_Lib",
                table: "Detalle");

            migrationBuilder.DropForeignKey(
                name: "FK_Prestamo_Detalle_Det",
                table: "Prestamo");

            migrationBuilder.DropForeignKey(
                name: "FK_Prestamo_Usuario_Usu",
                table: "Prestamo");

            migrationBuilder.RenameColumn(
                name: "Usu",
                table: "Prestamo",
                newName: "UsuarioUser");

            migrationBuilder.RenameColumn(
                name: "Det",
                table: "Prestamo",
                newName: "DetalleId");

            migrationBuilder.RenameIndex(
                name: "IX_Prestamo_Usu",
                table: "Prestamo",
                newName: "IX_Prestamo_UsuarioUser");

            migrationBuilder.RenameIndex(
                name: "IX_Prestamo_Det",
                table: "Prestamo",
                newName: "IX_Prestamo_DetalleId");

            migrationBuilder.RenameColumn(
                name: "Lib",
                table: "Detalle",
                newName: "LibroId");

            migrationBuilder.RenameIndex(
                name: "IX_Detalle_Lib",
                table: "Detalle",
                newName: "IX_Detalle_LibroId");

            migrationBuilder.AddForeignKey(
                name: "FK_Detalle_Libro_LibroId",
                table: "Detalle",
                column: "LibroId",
                principalTable: "Libro",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Prestamo_Detalle_DetalleId",
                table: "Prestamo",
                column: "DetalleId",
                principalTable: "Detalle",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Prestamo_Usuario_UsuarioUser",
                table: "Prestamo",
                column: "UsuarioUser",
                principalTable: "Usuario",
                principalColumn: "User",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

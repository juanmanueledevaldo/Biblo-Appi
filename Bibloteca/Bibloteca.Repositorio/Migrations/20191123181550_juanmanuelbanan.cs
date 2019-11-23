using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Bibloteca.Repositorio.Migrations
{
    public partial class juanmanuelbanan : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Carrera",
                table: "Usuario",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Cuatrimestre",
                table: "Usuario",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Usuario",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Grupo",
                table: "Usuario",
                maxLength: 20,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Matricula",
                table: "Usuario",
                maxLength: 10,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Telefono",
                table: "Usuario",
                maxLength: 20,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "Usuario",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Carrera",
                table: "Usuario");

            migrationBuilder.DropColumn(
                name: "Cuatrimestre",
                table: "Usuario");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Usuario");

            migrationBuilder.DropColumn(
                name: "Grupo",
                table: "Usuario");

            migrationBuilder.DropColumn(
                name: "Matricula",
                table: "Usuario");

            migrationBuilder.DropColumn(
                name: "Telefono",
                table: "Usuario");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "Usuario");
        }
    }
}

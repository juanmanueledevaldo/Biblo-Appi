﻿// <auto-generated />
using Bibloteca.Repositorio.Datos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;

namespace Bibloteca.Repositorio.Migrations
{
    [DbContext(typeof(DatosDbContext))]
    [Migration("20191110042745_bib")]
    partial class bib
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.3-rtm-10026")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Bibloteca.Modelo.Modelo.Detalle", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("LibroId");

                    b.HasKey("Id");

                    b.HasIndex("LibroId");

                    b.ToTable("Detalle");
                });

            modelBuilder.Entity("Bibloteca.Modelo.Modelo.Libro", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Autor")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("Año")
                        .IsRequired();

                    b.Property<bool>("Borrado");

                    b.Property<string>("Editorial")
                        .IsRequired();

                    b.Property<string>("Estante")
                        .IsRequired()
                        .HasMaxLength(30);

                    b.Property<string>("Genero")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("Imagen")
                        .IsRequired();

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<int>("Paginas");

                    b.Property<int>("Stock");

                    b.HasKey("Id");

                    b.ToTable("Libro");
                });

            modelBuilder.Entity("Bibloteca.Modelo.Modelo.Prestamo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("DetalleId");

                    b.Property<DateTime>("Devolucion");

                    b.Property<string>("Estado")
                        .IsRequired();

                    b.Property<DateTime>("Fecha");

                    b.Property<string>("UsuarioUser");

                    b.HasKey("Id");

                    b.HasIndex("DetalleId");

                    b.HasIndex("UsuarioUser");

                    b.ToTable("Prestamo");
                });

            modelBuilder.Entity("Bibloteca.Modelo.Modelo.Usuario", b =>
                {
                    b.Property<string>("User")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(25);

                    b.Property<bool>("Activo");

                    b.Property<string>("Apellido")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<bool>("Borrado");

                    b.Property<string>("Contraseña")
                        .IsRequired()
                        .HasMaxLength(10);

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<string>("Tipo")
                        .IsRequired();

                    b.HasKey("User");

                    b.ToTable("Usuario");
                });

            modelBuilder.Entity("Bibloteca.Modelo.Modelo.Detalle", b =>
                {
                    b.HasOne("Bibloteca.Modelo.Modelo.Libro", "Libro")
                        .WithMany()
                        .HasForeignKey("LibroId");
                });

            modelBuilder.Entity("Bibloteca.Modelo.Modelo.Prestamo", b =>
                {
                    b.HasOne("Bibloteca.Modelo.Modelo.Detalle", "Detalle")
                        .WithMany()
                        .HasForeignKey("DetalleId");

                    b.HasOne("Bibloteca.Modelo.Modelo.Usuario", "Usuario")
                        .WithMany()
                        .HasForeignKey("UsuarioUser");
                });
#pragma warning restore 612, 618
        }
    }
}
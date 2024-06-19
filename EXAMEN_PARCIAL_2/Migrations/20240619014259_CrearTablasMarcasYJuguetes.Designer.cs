﻿// <auto-generated />
using System;
using EXAMEN_PARCIAL_2;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace EXAMEN_PARCIAL_2.Migrations
{
    [DbContext(typeof(AplicationDbContext))]
    [Migration("20240619014259_CrearTablasMarcasYJuguetes")]
    partial class CrearTablasMarcasYJuguetes
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("EXAMEN_PARCIAL_2.Entities.Juguete", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("Activo")
                        .HasColumnType("bit");

                    b.Property<int>("Codigo")
                        .HasColumnType("int");

                    b.Property<Guid?>("JugueteId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Precio")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime?>("Vigencia")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("JugueteId");

                    b.ToTable("juguetes");
                });

            modelBuilder.Entity("EXAMEN_PARCIAL_2.Entities.Marca", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("Activo")
                        .HasColumnType("bit");

                    b.Property<int>("Codigo")
                        .HasColumnType("int");

                    b.Property<Guid?>("MarcaId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("MarcaId");

                    b.ToTable("marca");
                });

            modelBuilder.Entity("EXAMEN_PARCIAL_2.Entities.Juguete", b =>
                {
                    b.HasOne("EXAMEN_PARCIAL_2.Entities.Juguete", null)
                        .WithMany("ListadoDeJuguetes")
                        .HasForeignKey("JugueteId");
                });

            modelBuilder.Entity("EXAMEN_PARCIAL_2.Entities.Marca", b =>
                {
                    b.HasOne("EXAMEN_PARCIAL_2.Entities.Marca", null)
                        .WithMany("ListadoDeMarcas")
                        .HasForeignKey("MarcaId");
                });

            modelBuilder.Entity("EXAMEN_PARCIAL_2.Entities.Juguete", b =>
                {
                    b.Navigation("ListadoDeJuguetes");
                });

            modelBuilder.Entity("EXAMEN_PARCIAL_2.Entities.Marca", b =>
                {
                    b.Navigation("ListadoDeMarcas");
                });
#pragma warning restore 612, 618
        }
    }
}

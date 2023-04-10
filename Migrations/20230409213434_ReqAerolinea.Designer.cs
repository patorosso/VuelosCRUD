﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using VuelosCRUD.Models;

#nullable disable

namespace VuelosCRUD.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20230409213434_ReqAerolinea")]
    partial class ReqAerolinea
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("VuelosCRUD.Models.Aerolinea", b =>
                {
                    b.Property<short>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("smallint");

                    b.Property<string>("Iata")
                        .HasMaxLength(15)
                        .HasColumnType("varchar(15)");

                    b.Property<string>("Icao")
                        .HasMaxLength(15)
                        .HasColumnType("varchar(15)");

                    b.Property<string>("Nombre")
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Aerolineas");
                });

            modelBuilder.Entity("VuelosCRUD.Models.Vuelo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<short>("AerolineaId")
                        .HasColumnType("smallint");

                    b.Property<bool>("Demorado")
                        .HasColumnType("tinyint(1)");

                    b.Property<DateTime?>("Horario")
                        .IsRequired()
                        .HasColumnType("datetime(6)");

                    b.Property<string>("NumeroDeVuelo")
                        .IsRequired()
                        .HasMaxLength(12)
                        .HasColumnType("varchar(12)");

                    b.HasKey("Id");

                    b.HasIndex("AerolineaId");

                    b.ToTable("Vuelos");
                });

            modelBuilder.Entity("VuelosCRUD.Models.Vuelo", b =>
                {
                    b.HasOne("VuelosCRUD.Models.Aerolinea", "Aerolinea")
                        .WithMany()
                        .HasForeignKey("AerolineaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Aerolinea");
                });
#pragma warning restore 612, 618
        }
    }
}

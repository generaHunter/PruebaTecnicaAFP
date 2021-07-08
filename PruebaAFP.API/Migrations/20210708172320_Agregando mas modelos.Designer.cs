﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PruebaAFP.API.Data;

namespace PruebaAFP.API.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20210708172320_Agregando mas modelos")]
    partial class Agregandomasmodelos
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("PruebaAFP.API.Models.Cliente", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("Id");

                    b.ToTable("Clientes");
                });

            modelBuilder.Entity("PruebaAFP.API.Models.Factura", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("ClienteId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("datetime2");

                    b.Property<int>("TipoTramiteId")
                        .HasColumnType("int");

                    b.Property<double>("Total")
                        .HasColumnType("float");

                    b.Property<int>("VehiculoId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ClienteId");

                    b.HasIndex("TipoTramiteId");

                    b.HasIndex("VehiculoId");

                    b.ToTable("Facturas");
                });

            modelBuilder.Entity("PruebaAFP.API.Models.TipoTramite", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Tipo")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("TipoTramites");
                });

            modelBuilder.Entity("PruebaAFP.API.Models.Vehiculo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Marca")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("PrecioTramite")
                        .HasColumnType("float");

                    b.Property<int>("TipoTramiteId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TipoTramiteId");

                    b.ToTable("Vehiculos");
                });

            modelBuilder.Entity("PruebaAFP.API.Models.Factura", b =>
                {
                    b.HasOne("PruebaAFP.API.Models.Cliente", "Cliente")
                        .WithMany("Facturas")
                        .HasForeignKey("ClienteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PruebaAFP.API.Models.TipoTramite", "TipoTramite")
                        .WithMany()
                        .HasForeignKey("TipoTramiteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PruebaAFP.API.Models.Vehiculo", "Vehiculo")
                        .WithMany("Facturas")
                        .HasForeignKey("VehiculoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cliente");

                    b.Navigation("TipoTramite");

                    b.Navigation("Vehiculo");
                });

            modelBuilder.Entity("PruebaAFP.API.Models.Vehiculo", b =>
                {
                    b.HasOne("PruebaAFP.API.Models.TipoTramite", "TipoTramite")
                        .WithMany()
                        .HasForeignKey("TipoTramiteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("TipoTramite");
                });

            modelBuilder.Entity("PruebaAFP.API.Models.Cliente", b =>
                {
                    b.Navigation("Facturas");
                });

            modelBuilder.Entity("PruebaAFP.API.Models.Vehiculo", b =>
                {
                    b.Navigation("Facturas");
                });
#pragma warning restore 612, 618
        }
    }
}
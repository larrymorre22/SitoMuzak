﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ProgettoComplessoID.Data;

#nullable disable

namespace ProgettoComplessoID.Migrations
{
    [DbContext(typeof(ProgettoComplessoIDContext))]
    [Migration("20240423112234_migrazione3")]
    partial class migrazione3
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.17")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ProgettoComplessoID.Models.Acquisto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Cliente")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DataAcquisto")
                        .HasColumnType("datetime2");

                    b.Property<string>("NomeTipo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Prezzo")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.ToTable("Acquisto");
                });

            modelBuilder.Entity("ProgettoComplessoID.Models.Album", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Band")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Genre")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImageData")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsLive")
                        .HasColumnType("bit");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18, 2)");

                    b.Property<DateTime>("ReleaseDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Album");
                });

            modelBuilder.Entity("ProgettoComplessoID.Models.Buono", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Codice")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DataScadenza")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("Valore")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.ToTable("Buono");
                });

            modelBuilder.Entity("ProgettoComplessoID.Models.DVD", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Anno")
                        .HasColumnType("int");

                    b.Property<string>("Artista")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Genere")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NomeTipo")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("DVD");
                });

            modelBuilder.Entity("ProgettoComplessoID.Models.Documento", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("Data")
                        .HasColumnType("datetime2");

                    b.Property<string>("FilePDF")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NomeTipo")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Documento");
                });

            modelBuilder.Entity("ProgettoComplessoID.Models.Gadget", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Descrizione")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nome")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Prezzo")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.ToTable("Gadget");
                });

            modelBuilder.Entity("ProgettoComplessoID.Models.Vendita", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Cliente")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DataVendita")
                        .HasColumnType("datetime2");

                    b.Property<string>("NomeTipo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("PrezzoVendita")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("ProdottoId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Vendita");
                });
#pragma warning restore 612, 618
        }
    }
}
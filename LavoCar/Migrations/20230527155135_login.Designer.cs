﻿// <auto-generated />
using System;
using LavoCar.Conexao;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace LavoCar.Migrations
{
    [DbContext(typeof(IESContext))]
    [Migration("20230527155135_login")]
    partial class login
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("LavoCar.Controllers.Carro", b =>
                {
                    b.Property<long?>("CarroID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .UseIdentityColumn();

                    b.Property<int>("Ano")
                        .HasColumnType("int");

                    b.Property<long?>("ClienteID")
                        .HasColumnType("bigint");

                    b.Property<string>("Marca")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Modelo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Placa")
                        .HasMaxLength(7)
                        .HasColumnType("nvarchar(7)");

                    b.HasKey("CarroID");

                    b.HasIndex("ClienteID");

                    b.ToTable("Carros");
                });

            modelBuilder.Entity("LavoCar.Controllers.Lavagem", b =>
                {
                    b.Property<long?>("LavID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .UseIdentityColumn();

                    b.Property<DateTime>("DataLav")
                        .HasColumnType("datetime2");

                    b.Property<int>("ValorLav")
                        .HasColumnType("int");

                    b.HasKey("LavID");

                    b.ToTable("Lavagens");
                });

            modelBuilder.Entity("LavoCar.Controllers.TipoLavagem", b =>
                {
                    b.Property<long?>("TipoLavID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .UseIdentityColumn();

                    b.Property<string>("DescTipoLav")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long?>("LavagemLavID")
                        .HasColumnType("bigint");

                    b.Property<int>("PrecoTipoLav")
                        .HasColumnType("int");

                    b.HasKey("TipoLavID");

                    b.HasIndex("LavagemLavID");

                    b.ToTable("TipoLavagens");
                });

            modelBuilder.Entity("LavoCar.Models.Cliente", b =>
                {
                    b.Property<long?>("ClienteID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .UseIdentityColumn();

                    b.Property<string>("EndCliente")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("FoneCliente")
                        .HasMaxLength(11)
                        .HasColumnType("nvarchar(11)");

                    b.Property<string>("NomeCliente")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ClienteID");

                    b.ToTable("Clientes");
                });

            modelBuilder.Entity("LavoCar.Controllers.Carro", b =>
                {
                    b.HasOne("LavoCar.Models.Cliente", "Cliente")
                        .WithMany("Carros")
                        .HasForeignKey("ClienteID");

                    b.Navigation("Cliente");
                });

            modelBuilder.Entity("LavoCar.Controllers.TipoLavagem", b =>
                {
                    b.HasOne("LavoCar.Controllers.Lavagem", null)
                        .WithMany("TipoLavagens")
                        .HasForeignKey("LavagemLavID");
                });

            modelBuilder.Entity("LavoCar.Controllers.Lavagem", b =>
                {
                    b.Navigation("TipoLavagens");
                });

            modelBuilder.Entity("LavoCar.Models.Cliente", b =>
                {
                    b.Navigation("Carros");
                });
#pragma warning restore 612, 618
        }
    }
}

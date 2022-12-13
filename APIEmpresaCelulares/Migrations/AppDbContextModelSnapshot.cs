﻿// <auto-generated />
using System;
using APIEmpresaCelulares.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace APIEmpresaCelulares.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("APIEmpresaCelulares.Model.Cliente", b =>
                {
                    b.Property<int>("ClienteId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ClienteId"));

                    b.Property<string>("Genero")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("MensagemId")
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Regiao")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ClienteId");

                    b.HasIndex("MensagemId");

                    b.ToTable("Clientes");
                });

            modelBuilder.Entity("APIEmpresaCelulares.Model.Mensagem", b =>
                {
                    b.Property<int>("MensagemId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MensagemId"));

                    b.Property<DateTime>("Data")
                        .HasColumnType("datetime2");

                    b.Property<string>("Texto")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("MensagemId");

                    b.ToTable("Mensagens");
                });

            modelBuilder.Entity("APIEmpresaCelulares.Model.Cliente", b =>
                {
                    b.HasOne("APIEmpresaCelulares.Model.Mensagem", null)
                        .WithMany("Cliente")
                        .HasForeignKey("MensagemId");
                });

            modelBuilder.Entity("APIEmpresaCelulares.Model.Mensagem", b =>
                {
                    b.Navigation("Cliente");
                });
#pragma warning restore 612, 618
        }
    }
}

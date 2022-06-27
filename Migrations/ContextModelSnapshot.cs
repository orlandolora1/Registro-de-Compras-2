﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RegistroCompras.DAL;

#nullable disable

namespace RegistroCompras.Migrations
{
    [DbContext(typeof(Context))]
    partial class ContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.6");

            modelBuilder.Entity("RegistroCompras.Models.Categorias", b =>
            {
                b.Property<int>("CategoriaId")
                    .ValueGeneratedOnAdd()
                    .HasColumnType("INTEGER");

                b.Property<string>("Descripcion")
                    .HasColumnType("TEXT");

                b.HasKey("CategoriaId");

                b.ToTable("Categorias");

                b.HasData(
                    new
                    {
                        CategoriaId = 1,
                        Descripcion = "Alimentos"
                    },
                    new
                    {
                        CategoriaId = 2,
                        Descripcion = "Abarrotes"
                    });
            });

            modelBuilder.Entity("RegistroCompras.Models.Compras", b =>
            {
                b.Property<int>("CompraId")
                    .ValueGeneratedOnAdd()
                    .HasColumnType("INTEGER");

                b.Property<DateTime>("Fecha")
                    .HasColumnType("TEXT");

                b.Property<double>("Total")
                    .HasColumnType("REAL");

                b.HasKey("CompraId");

                b.ToTable("Compras");
            });

            modelBuilder.Entity("RegistroCompras.Models.ComprasDetalle", b =>
            {
                b.Property<int>("CompraDetalleId")
                    .ValueGeneratedOnAdd()
                    .HasColumnType("INTEGER");

                b.Property<double>("Cantidad")
                    .HasColumnType("REAL");

                b.Property<int>("CompraId")
                    .HasColumnType("INTEGER");

                b.Property<double>("Costo")
                    .HasColumnType("REAL");

                b.Property<int>("ProductoId")
                    .HasColumnType("INTEGER");

                b.HasKey("CompraDetalleId");

                b.HasIndex("CompraId");

                b.HasIndex("ProductoId");

                b.ToTable("ComprasDetalle");
            });

            modelBuilder.Entity("RegistroCompras.Models.Productos", b =>
            {
                b.Property<int>("ProductoId")
                    .ValueGeneratedOnAdd()
                    .HasColumnType("INTEGER");

                b.Property<int>("CategoriaId")
                    .HasColumnType("INTEGER");

                b.Property<double>("Costo")
                    .HasColumnType("REAL");

                b.Property<string>("Descripcion")
                    .HasColumnType("TEXT");

                b.Property<double>("Existencia")
                    .HasColumnType("REAL");

                b.Property<double>("Precio")
                    .HasColumnType("REAL");

                b.HasKey("ProductoId");

                b.HasIndex("CategoriaId");

                b.ToTable("Productos");

                b.HasData(
                    new
                    {
                        ProductoId = 1,
                        CategoriaId = 1,
                        Costo = 5.0,
                        Descripcion = "Huevos",
                        Existencia = 0.0,
                        Precio = 7.0
                    },
                    new
                    {
                        ProductoId = 2,
                        CategoriaId = 1,
                        Costo = 50.0,
                        Descripcion = "Cebolla",
                        Existencia = 0.0,
                        Precio = 85.0
                    });
            });

            modelBuilder.Entity("RegistroCompras.Models.ComprasDetalle", b =>
            {
                b.HasOne("RegistroCompras.Models.Compras", null)
                    .WithMany("Detalle")
                    .HasForeignKey("CompraId")
                    .OnDelete(DeleteBehavior.Cascade)
                    .IsRequired();

                b.HasOne("RegistroCompras.Models.Productos", "producto")
                    .WithMany()
                    .HasForeignKey("ProductoId")
                    .OnDelete(DeleteBehavior.Cascade)
                    .IsRequired();

                b.Navigation("producto");
            });

            modelBuilder.Entity("RegistroCompras.Models.Productos", b =>
            {
                b.HasOne("RegistroCompras.Models.Categorias", "categoria")
                    .WithMany()
                    .HasForeignKey("CategoriaId")
                    .OnDelete(DeleteBehavior.Cascade)
                    .IsRequired();

                b.Navigation("categoria");
            });

            modelBuilder.Entity("RegistroCompras.Models.Compras", b =>
            {
                b.Navigation("Detalle");
            });
#pragma warning restore 612, 618
        }
    }
}
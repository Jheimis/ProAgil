﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ProAgil.api.Data;

namespace ProAgil.api.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.0");

            modelBuilder.Entity("ProAgil.api.Model.Evento", b =>
                {
                    b.Property<int>("eventoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("dataEvento")
                        .HasColumnType("TEXT");

                    b.Property<string>("imageUrl")
                        .HasColumnType("TEXT");

                    b.Property<string>("local")
                        .HasColumnType("TEXT");

                    b.Property<string>("lote")
                        .HasColumnType("TEXT");

                    b.Property<int>("qtdPessoas")
                        .HasColumnType("INTEGER");

                    b.Property<string>("tema")
                        .HasColumnType("TEXT");

                    b.HasKey("eventoId");

                    b.ToTable("Eventos");
                });
#pragma warning restore 612, 618
        }
    }
}

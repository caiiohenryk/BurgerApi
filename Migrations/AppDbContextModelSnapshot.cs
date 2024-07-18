﻿// <auto-generated />
using System;
using BurgerApi.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace BurgerApi.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("BurgerApi.Burgers.Models.Burger", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<bool>("Ativo")
                        .HasColumnType("boolean");

                    b.Property<Guid?>("ComboId")
                        .HasColumnType("uuid");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("ComboId");

                    b.ToTable("Burgers");
                });

            modelBuilder.Entity("BurgerApi.Burgers.Models.Combo", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<double>("Preco")
                        .HasColumnType("double precision");

                    b.HasKey("Id");

                    b.ToTable("Combos");
                });

            modelBuilder.Entity("BurgerApi.Burgers.Models.Burger", b =>
                {
                    b.HasOne("BurgerApi.Burgers.Models.Combo", "Combo")
                        .WithMany("Burgers")
                        .HasForeignKey("ComboId");

                    b.Navigation("Combo");
                });

            modelBuilder.Entity("BurgerApi.Burgers.Models.Combo", b =>
                {
                    b.Navigation("Burgers");
                });
#pragma warning restore 612, 618
        }
    }
}

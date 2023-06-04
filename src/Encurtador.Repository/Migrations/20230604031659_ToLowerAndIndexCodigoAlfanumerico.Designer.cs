﻿// <auto-generated />
using System;
using Encurtador.Repository.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Encurtador.Repository.Migrations
{
    [DbContext(typeof(EncurtadorContext))]
    [Migration("20230604031659_ToLowerAndIndexCodigoAlfanumerico")]
    partial class ToLowerAndIndexCodigoAlfanumerico
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Encurtador.Domain.Entities.UrlEncurtada", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<string>("CodigoAlfanumerico")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("character varying(10)")
                        .HasColumnName("codigoalfanumerico");

                    b.Property<DateTime>("DataExpiracao")
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("dataexpiracao");

                    b.Property<int>("Status")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasDefaultValue(0)
                        .HasColumnName("status");

                    b.Property<string>("UrlOriginal")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("urloriginal");

                    b.HasKey("Id");

                    b.HasIndex("CodigoAlfanumerico");

                    b.ToTable("urlencurtadas", (string)null);
                });
#pragma warning restore 612, 618
        }
    }
}

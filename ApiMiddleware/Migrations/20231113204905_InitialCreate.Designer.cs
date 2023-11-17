﻿// <auto-generated />
using ApiMiddleware.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ApiMiddleware.Migrations
{
    [DbContext(typeof(ContentContext))]
    [Migration("20231113204905_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.13");

            modelBuilder.Entity("ApiMiddleware.Entity.ContentEntity", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("TEXT");

                    b.Property<string>("PostContent")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("PostTitle")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("ContentEntities");
                });
#pragma warning restore 612, 618
        }
    }
}
﻿// <auto-generated />
using System;
using MegaDeskRazor.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace MegaDeskRazor.Migrations
{
    [DbContext(typeof(MegaDeskRazorContext))]
    [Migration("20230608165558_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("MegaDeskRazor.Models.DeliveryType", b =>
                {
                    b.Property<int>("DeliveryTypeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DeliveryTypeId"));

                    b.Property<string>("DeliveryName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("PriceBetween1000And2000")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("PriceOver2000")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("PriceUnder1000")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("DeliveryTypeId");

                    b.ToTable("DeliveryType");
                });

            modelBuilder.Entity("MegaDeskRazor.Models.Desk", b =>
                {
                    b.Property<int>("DeskId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DeskId"));

                    b.Property<int>("Depth")
                        .HasColumnType("int");

                    b.Property<int>("DesktopMaterialId")
                        .HasColumnType("int");

                    b.Property<int>("NumDrawers")
                        .HasColumnType("int");

                    b.Property<int>("Width")
                        .HasColumnType("int");

                    b.HasKey("DeskId");

                    b.HasIndex("DesktopMaterialId");

                    b.ToTable("Desk");
                });

            modelBuilder.Entity("MegaDeskRazor.Models.DeskQuote", b =>
                {
                    b.Property<int>("DeskQuoteId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DeskQuoteId"));

                    b.Property<string>("CustomerName")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("nvarchar(60)");

                    b.Property<int>("DeliveryTypeId")
                        .HasColumnType("int");

                    b.Property<int>("DeskId")
                        .HasColumnType("int");

                    b.Property<DateTime>("QuoteDate")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("QuotePrice")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("DeskQuoteId");

                    b.HasIndex("DeliveryTypeId");

                    b.HasIndex("DeskId");

                    b.ToTable("DeskQuote");
                });

            modelBuilder.Entity("MegaDeskRazor.Models.DesktopMaterial", b =>
                {
                    b.Property<int>("DesktopMaterialId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DesktopMaterialId"));

                    b.Property<string>("DesktopMaterialName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("DesktopMaterialPrice")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("DesktopMaterialId");

                    b.ToTable("DesktopMaterial");
                });

            modelBuilder.Entity("MegaDeskRazor.Models.Desk", b =>
                {
                    b.HasOne("MegaDeskRazor.Models.DesktopMaterial", "DesktopMaterial")
                        .WithMany()
                        .HasForeignKey("DesktopMaterialId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("DesktopMaterial");
                });

            modelBuilder.Entity("MegaDeskRazor.Models.DeskQuote", b =>
                {
                    b.HasOne("MegaDeskRazor.Models.DeliveryType", "DeliveryType")
                        .WithMany()
                        .HasForeignKey("DeliveryTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MegaDeskRazor.Models.Desk", "Desk")
                        .WithMany()
                        .HasForeignKey("DeskId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("DeliveryType");

                    b.Navigation("Desk");
                });
#pragma warning restore 612, 618
        }
    }
}

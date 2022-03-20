﻿// <auto-generated />
using DersDagitimProjesi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace DersDagitimProjesi.Migrations
{
    [DbContext(typeof(Context))]
    [Migration("20220213123023_mig1")]
    partial class mig1
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("DersDagitim.Models.Ders", b =>
                {
                    b.Property<int>("DersID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("DersID"));

                    b.Property<string>("DersAd")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("DersID");

                    b.ToTable("Derss");
                });

            modelBuilder.Entity("DersDagitim.Models.Ogrenci", b =>
                {
                    b.Property<int>("OgrenciID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("OgrenciID"));

                    b.Property<string>("OgrenciAd")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("OgrenciSoyad")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("Sinifid")
                        .HasColumnType("integer");

                    b.HasKey("OgrenciID");

                    b.HasIndex("Sinifid");

                    b.ToTable("Ogrencis");
                });

            modelBuilder.Entity("DersDagitim.Models.Ogretmen", b =>
                {
                    b.Property<int>("OgretmenID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("OgretmenID"));

                    b.Property<string>("OgretmenAd")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("OgretmenSoyad")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("OgretmenID");

                    b.ToTable("Ogretmens");
                });

            modelBuilder.Entity("DersDagitim.Models.Okul", b =>
                {
                    b.Property<int>("OkulID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("OkulID"));

                    b.Property<string>("OkulAdı")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("OkulID");

                    b.ToTable("Okuls");
                });

            modelBuilder.Entity("DersDagitim.Models.Sinif", b =>
                {
                    b.Property<int>("SinifID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("SinifID"));

                    b.Property<int>("OgrenciSayisi")
                        .HasColumnType("integer");

                    b.Property<int>("Okulid")
                        .HasColumnType("integer");

                    b.Property<int>("SinifNo")
                        .HasColumnType("integer");

                    b.Property<string>("SinifSube")
                        .IsRequired()
                        .HasMaxLength(1)
                        .HasColumnType("Char");

                    b.HasKey("SinifID");

                    b.HasIndex("Okulid");

                    b.ToTable("Sinifs");
                });

            modelBuilder.Entity("OgretmenSinif", b =>
                {
                    b.Property<int>("OgretmensOgretmenID")
                        .HasColumnType("integer");

                    b.Property<int>("SinifsSinifID")
                        .HasColumnType("integer");

                    b.HasKey("OgretmensOgretmenID", "SinifsSinifID");

                    b.HasIndex("SinifsSinifID");

                    b.ToTable("OgretmenSinif");
                });

            modelBuilder.Entity("DersDagitim.Models.Ogrenci", b =>
                {
                    b.HasOne("DersDagitim.Models.Sinif", "Siniflar")
                        .WithMany("Ogrencis")
                        .HasForeignKey("Sinifid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Siniflar");
                });

            modelBuilder.Entity("DersDagitim.Models.Sinif", b =>
                {
                    b.HasOne("DersDagitim.Models.Okul", "Okullar")
                        .WithMany("Sinifs")
                        .HasForeignKey("Okulid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Okullar");
                });

            modelBuilder.Entity("OgretmenSinif", b =>
                {
                    b.HasOne("DersDagitim.Models.Ogretmen", null)
                        .WithMany()
                        .HasForeignKey("OgretmensOgretmenID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DersDagitim.Models.Sinif", null)
                        .WithMany()
                        .HasForeignKey("SinifsSinifID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("DersDagitim.Models.Okul", b =>
                {
                    b.Navigation("Sinifs");
                });

            modelBuilder.Entity("DersDagitim.Models.Sinif", b =>
                {
                    b.Navigation("Ogrencis");
                });
#pragma warning restore 612, 618
        }
    }
}
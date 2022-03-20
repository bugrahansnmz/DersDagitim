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
    [Migration("20220304221611_qwe")]
    partial class qwe
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("DersDagitimProjesi.Models.Ders", b =>
                {
                    b.Property<int>("DersID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("DersID"));

                    b.Property<string>("DersAd")
                        .HasColumnType("text");

                    b.HasKey("DersID");

                    b.ToTable("Derss");
                });

            modelBuilder.Entity("DersDagitimProjesi.Models.DersProgram", b =>
                {
                    b.Property<int>("ProgramID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("ProgramID"));

                    b.Property<int>("Dersid")
                        .HasColumnType("integer");

                    b.Property<int>("Gunid")
                        .HasColumnType("integer");

                    b.Property<int>("Saatid")
                        .HasColumnType("integer");

                    b.Property<int>("Sinifid")
                        .HasColumnType("integer");

                    b.HasKey("ProgramID");

                    b.HasIndex("Dersid");

                    b.HasIndex("Gunid");

                    b.HasIndex("Saatid");

                    b.HasIndex("Sinifid");

                    b.ToTable("DersPrograms");
                });

            modelBuilder.Entity("DersDagitimProjesi.Models.Gun", b =>
                {
                    b.Property<int>("GunID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("GunID"));

                    b.Property<string>("GunAdi")
                        .HasColumnType("text");

                    b.HasKey("GunID");

                    b.ToTable("Guns");
                });

            modelBuilder.Entity("DersDagitimProjesi.Models.Ogrenci", b =>
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

            modelBuilder.Entity("DersDagitimProjesi.Models.Ogretmen", b =>
                {
                    b.Property<int>("OgretmenID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("OgretmenID"));

                    b.Property<int>("Dersid")
                        .HasColumnType("integer");

                    b.Property<string>("OgretmenAd")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("OgretmenSoyad")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("OgretmenID");

                    b.HasIndex("Dersid");

                    b.ToTable("Ogretmens");
                });

            modelBuilder.Entity("DersDagitimProjesi.Models.Okul", b =>
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

            modelBuilder.Entity("DersDagitimProjesi.Models.Saat", b =>
                {
                    b.Property<int>("SaatID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("SaatID"));

                    b.Property<string>("SaatKac")
                        .HasColumnType("text");

                    b.HasKey("SaatID");

                    b.ToTable("Saats");
                });

            modelBuilder.Entity("DersDagitimProjesi.Models.SabitBilgi", b =>
                {
                    b.Property<int>("SabitID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("SabitID"));

                    b.Property<int>("GunlukMaksDers")
                        .HasColumnType("integer");

                    b.Property<bool>("OgleArasi")
                        .HasColumnType("boolean");

                    b.HasKey("SabitID");

                    b.ToTable("SabitBilgis");
                });

            modelBuilder.Entity("DersDagitimProjesi.Models.Sinif", b =>
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

            modelBuilder.Entity("DersSinif", b =>
                {
                    b.Property<int>("DerssDersID")
                        .HasColumnType("integer");

                    b.Property<int>("SinifsSinifID")
                        .HasColumnType("integer");

                    b.HasKey("DerssDersID", "SinifsSinifID");

                    b.HasIndex("SinifsSinifID");

                    b.ToTable("DersSinif");
                });

            modelBuilder.Entity("DersDagitimProjesi.Models.DersProgram", b =>
                {
                    b.HasOne("DersDagitimProjesi.Models.Ders", "Ders")
                        .WithMany("DersPrograms")
                        .HasForeignKey("Dersid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DersDagitimProjesi.Models.Gun", "Gun")
                        .WithMany("DersPrograms")
                        .HasForeignKey("Gunid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DersDagitimProjesi.Models.Saat", "Saat")
                        .WithMany("DersPrograms")
                        .HasForeignKey("Saatid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DersDagitimProjesi.Models.Sinif", "Sinif")
                        .WithMany("DersPrograms")
                        .HasForeignKey("Sinifid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Ders");

                    b.Navigation("Gun");

                    b.Navigation("Saat");

                    b.Navigation("Sinif");
                });

            modelBuilder.Entity("DersDagitimProjesi.Models.Ogrenci", b =>
                {
                    b.HasOne("DersDagitimProjesi.Models.Sinif", "Sinif")
                        .WithMany("Ogrencis")
                        .HasForeignKey("Sinifid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Sinif");
                });

            modelBuilder.Entity("DersDagitimProjesi.Models.Ogretmen", b =>
                {
                    b.HasOne("DersDagitimProjesi.Models.Ders", "Ders")
                        .WithMany("Ogretmens")
                        .HasForeignKey("Dersid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Ders");
                });

            modelBuilder.Entity("DersDagitimProjesi.Models.Sinif", b =>
                {
                    b.HasOne("DersDagitimProjesi.Models.Okul", "Okul")
                        .WithMany("Sinifs")
                        .HasForeignKey("Okulid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Okul");
                });

            modelBuilder.Entity("DersSinif", b =>
                {
                    b.HasOne("DersDagitimProjesi.Models.Ders", null)
                        .WithMany()
                        .HasForeignKey("DerssDersID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DersDagitimProjesi.Models.Sinif", null)
                        .WithMany()
                        .HasForeignKey("SinifsSinifID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("DersDagitimProjesi.Models.Ders", b =>
                {
                    b.Navigation("DersPrograms");

                    b.Navigation("Ogretmens");
                });

            modelBuilder.Entity("DersDagitimProjesi.Models.Gun", b =>
                {
                    b.Navigation("DersPrograms");
                });

            modelBuilder.Entity("DersDagitimProjesi.Models.Okul", b =>
                {
                    b.Navigation("Sinifs");
                });

            modelBuilder.Entity("DersDagitimProjesi.Models.Saat", b =>
                {
                    b.Navigation("DersPrograms");
                });

            modelBuilder.Entity("DersDagitimProjesi.Models.Sinif", b =>
                {
                    b.Navigation("DersPrograms");

                    b.Navigation("Ogrencis");
                });
#pragma warning restore 612, 618
        }
    }
}

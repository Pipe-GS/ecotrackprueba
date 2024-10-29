﻿// <auto-generated />
using System;
using EcoTrack;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace EcoTrackBackend.Migrations
{
    [DbContext(typeof(EcoTrackDbContext))]
    [Migration("20241026191252_DatosClima")]
    partial class DatosClima
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            MySqlModelBuilderExtensions.AutoIncrementColumns(modelBuilder);

            modelBuilder.Entity("EcoTrack.Models.Actividad", b =>
                {
                    b.Property<int>("IdActividad")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("IdActividad"));

                    b.Property<int>("Duracion")
                        .HasColumnType("int");

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("datetime(6)");

                    b.Property<TimeSpan>("Hora")
                        .HasColumnType("time(6)");

                    b.Property<int>("IdTipoActividad")
                        .HasColumnType("int");

                    b.Property<int>("IdUsuario")
                        .HasColumnType("int");

                    b.Property<string>("Notas")
                        .HasColumnType("longtext");

                    b.Property<string>("Ubicacion")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("IdActividad");

                    b.HasIndex("IdTipoActividad");

                    b.HasIndex("IdUsuario");

                    b.ToTable("Actividades");
                });

            modelBuilder.Entity("EcoTrack.Models.DatosClima", b =>
                {
                    b.Property<int>("IdDatosClima")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("IdDatosClima"));

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<float>("Humedad")
                        .HasColumnType("float");

                    b.Property<int>("IdActividad")
                        .HasColumnType("int");

                    b.Property<float>("IndiceUV")
                        .HasColumnType("float");

                    b.Property<string>("RecomendacionUV")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<float>("Temperatura")
                        .HasColumnType("float");

                    b.HasKey("IdDatosClima");

                    b.HasIndex("IdActividad");

                    b.ToTable("DatosClima");
                });

            modelBuilder.Entity("EcoTrack.Models.Notificacion", b =>
                {
                    b.Property<int>("IdNotificacion")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("IdNotificacion"));

                    b.Property<bool>("Enviado")
                        .HasColumnType("tinyint(1)");

                    b.Property<DateTime>("FechaEnvio")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("IdActividad")
                        .HasColumnType("int");

                    b.Property<int>("IdUsuario")
                        .HasColumnType("int");

                    b.Property<string>("Mensaje")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)");

                    b.HasKey("IdNotificacion");

                    b.ToTable("Notificaciones");
                });

            modelBuilder.Entity("EcoTrack.Models.TipoActividad", b =>
                {
                    b.Property<int>("IdTipoActividad")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("IdTipoActividad"));

                    b.Property<string>("DescripcionActividad")
                        .HasMaxLength(2147483647)
                        .HasColumnType("longtext");

                    b.Property<string>("NombreActividad")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.HasKey("IdTipoActividad");

                    b.ToTable("TipoActividades");
                });

            modelBuilder.Entity("EcoTrack.Models.Usuario", b =>
                {
                    b.Property<int>("IdUsuario")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("IdUsuario"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.HasKey("IdUsuario");

                    b.ToTable("Usuarios");
                });

            modelBuilder.Entity("EcoTrack.Models.Actividad", b =>
                {
                    b.HasOne("EcoTrack.Models.TipoActividad", "TipoActividad")
                        .WithMany()
                        .HasForeignKey("IdTipoActividad")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("EcoTrack.Models.Usuario", "Usuario")
                        .WithMany()
                        .HasForeignKey("IdUsuario")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("TipoActividad");

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("EcoTrack.Models.DatosClima", b =>
                {
                    b.HasOne("EcoTrack.Models.Actividad", "Actividad")
                        .WithMany("DatosClima")
                        .HasForeignKey("IdActividad")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Actividad");
                });

            modelBuilder.Entity("EcoTrack.Models.Actividad", b =>
                {
                    b.Navigation("DatosClima");
                });
#pragma warning restore 612, 618
        }
    }
}

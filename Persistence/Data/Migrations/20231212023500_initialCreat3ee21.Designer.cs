﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Persistence.Data;

#nullable disable

namespace Persistence.Data.Migrations
{
    [DbContext(typeof(ApiDbContext))]
    [Migration("20231212023500_initialCreat3ee21")]
    partial class initialCreat3ee21
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Domain.Entities.CategoriaPersona", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("NombreCategoria")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.HasKey("Id");

                    b.ToTable("categoriaPersona", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            NombreCategoria = "Vigilantes"
                        },
                        new
                        {
                            Id = 2,
                            NombreCategoria = "Aseo"
                        });
                });

            modelBuilder.Entity("Domain.Entities.Ciudad", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("IdDepartamentoFk")
                        .HasColumnType("int");

                    b.Property<string>("NombreCiudad")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("IdDepartamentoFk");

                    b.ToTable("ciudad", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            IdDepartamentoFk = 1,
                            NombreCiudad = "Bucaramanga"
                        },
                        new
                        {
                            Id = 2,
                            IdDepartamentoFk = 1,
                            NombreCiudad = "Piedecuesta"
                        },
                        new
                        {
                            Id = 3,
                            IdDepartamentoFk = 1,
                            NombreCiudad = "Giron"
                        });
                });

            modelBuilder.Entity("Domain.Entities.ContactoPersona", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<int>("IdPersonaFk")
                        .HasColumnType("int");

                    b.Property<int>("IdTipoContactoFk")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("Descripcion")
                        .IsUnique();

                    b.HasIndex("IdPersonaFk");

                    b.HasIndex("IdTipoContactoFk");

                    b.ToTable("contactoPersona", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Descripcion = "Madre",
                            IdPersonaFk = 1,
                            IdTipoContactoFk = 2
                        },
                        new
                        {
                            Id = 2,
                            Descripcion = "Abuelo",
                            IdPersonaFk = 2,
                            IdTipoContactoFk = 1
                        },
                        new
                        {
                            Id = 3,
                            Descripcion = "Abuela",
                            IdPersonaFk = 5,
                            IdTipoContactoFk = 1
                        },
                        new
                        {
                            Id = 4,
                            Descripcion = "Tia",
                            IdPersonaFk = 4,
                            IdTipoContactoFk = 2
                        },
                        new
                        {
                            Id = 5,
                            Descripcion = "Esposa",
                            IdPersonaFk = 5,
                            IdTipoContactoFk = 1
                        },
                        new
                        {
                            Id = 6,
                            Descripcion = "Hermano",
                            IdPersonaFk = 6,
                            IdTipoContactoFk = 2
                        });
                });

            modelBuilder.Entity("Domain.Entities.Contrato", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateOnly>("FechaContrato")
                        .HasColumnType("date");

                    b.Property<DateOnly>("FechaFin")
                        .HasColumnType("date");

                    b.Property<int>("IdClienteFk")
                        .HasColumnType("int");

                    b.Property<int>("IdEmpleadoFk")
                        .HasColumnType("int");

                    b.Property<int>("IdEstadoFk")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("IdEmpleadoFk");

                    b.HasIndex("IdEstadoFk");

                    b.ToTable("contrato", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            FechaContrato = new DateOnly(2023, 8, 3),
                            FechaFin = new DateOnly(2023, 10, 2),
                            IdClienteFk = 2,
                            IdEmpleadoFk = 1,
                            IdEstadoFk = 1
                        },
                        new
                        {
                            Id = 2,
                            FechaContrato = new DateOnly(2023, 7, 23),
                            FechaFin = new DateOnly(2023, 8, 12),
                            IdClienteFk = 1,
                            IdEmpleadoFk = 2,
                            IdEstadoFk = 2
                        });
                });

            modelBuilder.Entity("Domain.Entities.Departamento", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("IdPaisFk")
                        .HasColumnType("int");

                    b.Property<string>("NombreDepartamento")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("IdPaisFk");

                    b.ToTable("departamento", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            IdPaisFk = 1,
                            NombreDepartamento = "Santander"
                        },
                        new
                        {
                            Id = 2,
                            IdPaisFk = 2,
                            NombreDepartamento = "California"
                        });
                });

            modelBuilder.Entity("Domain.Entities.DireccionPersona", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Avenida")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("CallePrincipal")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("CalleSecundaria")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<int>("IdPersonaFk")
                        .HasColumnType("int");

                    b.Property<int>("IdTipoDireccionFk")
                        .HasColumnType("int");

                    b.Property<string>("InformacionAdicional")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("IdPersonaFk");

                    b.HasIndex("IdTipoDireccionFk");

                    b.ToTable("direccionPersona", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Avenida = "Av arenales",
                            CallePrincipal = "Cll 23 A",
                            CalleSecundaria = "Cll 1",
                            IdPersonaFk = 2,
                            IdTipoDireccionFk = 1,
                            InformacionAdicional = "Cerca de la iglesia"
                        },
                        new
                        {
                            Id = 2,
                            Avenida = "Av 1 Casanare",
                            CallePrincipal = "Cll 55",
                            CalleSecundaria = "Cll 79",
                            IdPersonaFk = 1,
                            IdTipoDireccionFk = 2,
                            InformacionAdicional = "Detras del estadio"
                        });
                });

            modelBuilder.Entity("Domain.Entities.Estado", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.HasKey("Id");

                    b.ToTable("estado", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Descripcion = "Activo"
                        },
                        new
                        {
                            Id = 2,
                            Descripcion = "Inactivo"
                        });
                });

            modelBuilder.Entity("Domain.Entities.Pais", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("NombrePais")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.HasKey("Id");

                    b.ToTable("pais", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            NombrePais = "Colombia"
                        },
                        new
                        {
                            Id = 2,
                            NombrePais = "Estados Unidos"
                        });
                });

            modelBuilder.Entity("Domain.Entities.Persona", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateOnly>("FechaReg")
                        .HasColumnType("date");

                    b.Property<int>("IdCategoriaFk")
                        .HasColumnType("int");

                    b.Property<int>("IdCiudadFk")
                        .HasColumnType("int");

                    b.Property<int>("IdPersona")
                        .HasColumnType("int");

                    b.Property<int>("IdTipoPersonaFk")
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("IdCategoriaFk");

                    b.HasIndex("IdCiudadFk");

                    b.HasIndex("IdPersona")
                        .IsUnique();

                    b.HasIndex("IdTipoPersonaFk");

                    b.ToTable("persona", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            FechaReg = new DateOnly(2023, 1, 1),
                            IdCategoriaFk = 2,
                            IdCiudadFk = 1,
                            IdPersona = 4324,
                            IdTipoPersonaFk = 1,
                            Nombre = "Carlos Marin"
                        },
                        new
                        {
                            Id = 2,
                            FechaReg = new DateOnly(2023, 2, 25),
                            IdCategoriaFk = 1,
                            IdCiudadFk = 2,
                            IdPersona = 333,
                            IdTipoPersonaFk = 2,
                            Nombre = "Maria Gonzales"
                        },
                        new
                        {
                            Id = 3,
                            FechaReg = new DateOnly(2000, 2, 15),
                            IdCategoriaFk = 1,
                            IdCiudadFk = 2,
                            IdPersona = 5453,
                            IdTipoPersonaFk = 2,
                            Nombre = "Jose Gomez"
                        },
                        new
                        {
                            Id = 4,
                            FechaReg = new DateOnly(2003, 7, 3),
                            IdCategoriaFk = 2,
                            IdCiudadFk = 1,
                            IdPersona = 1274,
                            IdTipoPersonaFk = 2,
                            Nombre = "Luis Villa"
                        },
                        new
                        {
                            Id = 5,
                            FechaReg = new DateOnly(2015, 4, 1),
                            IdCategoriaFk = 1,
                            IdCiudadFk = 1,
                            IdPersona = 89,
                            IdTipoPersonaFk = 1,
                            Nombre = "Jose Manrrique"
                        },
                        new
                        {
                            Id = 6,
                            FechaReg = new DateOnly(2019, 11, 21),
                            IdCategoriaFk = 1,
                            IdCiudadFk = 2,
                            IdPersona = 664,
                            IdTipoPersonaFk = 1,
                            Nombre = "Emanuel Torres"
                        },
                        new
                        {
                            Id = 7,
                            FechaReg = new DateOnly(2023, 6, 12),
                            IdCategoriaFk = 1,
                            IdCiudadFk = 2,
                            IdPersona = 43244,
                            IdTipoPersonaFk = 1,
                            Nombre = "Luna Cardenas"
                        },
                        new
                        {
                            Id = 8,
                            FechaReg = new DateOnly(2019, 11, 21),
                            IdCategoriaFk = 1,
                            IdCiudadFk = 1,
                            IdPersona = 343,
                            IdTipoPersonaFk = 2,
                            Nombre = "Paco Diaz"
                        },
                        new
                        {
                            Id = 9,
                            FechaReg = new DateOnly(2012, 1, 21),
                            IdCategoriaFk = 1,
                            IdCiudadFk = 1,
                            IdPersona = 1634,
                            IdTipoPersonaFk = 2,
                            Nombre = "Jaime Caseres"
                        },
                        new
                        {
                            Id = 10,
                            FechaReg = new DateOnly(1999, 2, 21),
                            IdCategoriaFk = 1,
                            IdCiudadFk = 2,
                            IdPersona = 9675,
                            IdTipoPersonaFk = 1,
                            Nombre = "Luisa Hernandez"
                        },
                        new
                        {
                            Id = 11,
                            FechaReg = new DateOnly(2012, 6, 18),
                            IdCategoriaFk = 1,
                            IdCiudadFk = 2,
                            IdPersona = 86756,
                            IdTipoPersonaFk = 1,
                            Nombre = "Nicole Orduz"
                        },
                        new
                        {
                            Id = 12,
                            FechaReg = new DateOnly(2017, 1, 21),
                            IdCategoriaFk = 2,
                            IdCiudadFk = 3,
                            IdPersona = 6565,
                            IdTipoPersonaFk = 1,
                            Nombre = "Mauricio Jaimes"
                        },
                        new
                        {
                            Id = 13,
                            FechaReg = new DateOnly(2018, 9, 27),
                            IdCategoriaFk = 2,
                            IdCiudadFk = 2,
                            IdPersona = 24324,
                            IdTipoPersonaFk = 1,
                            Nombre = "Fernando Cardenas"
                        });
                });

            modelBuilder.Entity("Domain.Entities.Programacion", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("IdContratoFk")
                        .HasColumnType("int");

                    b.Property<int>("IdEmpleadoFk")
                        .HasColumnType("int");

                    b.Property<int>("IdTurnoFk")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("IdContratoFk");

                    b.HasIndex("IdEmpleadoFk");

                    b.HasIndex("IdTurnoFk");

                    b.ToTable("programacion", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            IdContratoFk = 1,
                            IdEmpleadoFk = 1,
                            IdTurnoFk = 2
                        },
                        new
                        {
                            Id = 2,
                            IdContratoFk = 2,
                            IdEmpleadoFk = 1,
                            IdTurnoFk = 1
                        });
                });

            modelBuilder.Entity("Domain.Entities.RefreshToken", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("Expires")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("IdUserFk")
                        .HasColumnType("int");

                    b.Property<DateTime?>("Revoked")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Token")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("IdUserFk");

                    b.ToTable("refreshToken", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.Rol", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.HasKey("Id");

                    b.ToTable("rol", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Nombre = "Administrador"
                        },
                        new
                        {
                            Id = 2,
                            Nombre = "Empleado"
                        });
                });

            modelBuilder.Entity("Domain.Entities.TipoContacto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.HasKey("Id");

                    b.ToTable("tipoContacto", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Descripcion = "Emergencia"
                        },
                        new
                        {
                            Id = 2,
                            Descripcion = "Normal"
                        });
                });

            modelBuilder.Entity("Domain.Entities.TipoDireccion", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.HasKey("Id");

                    b.ToTable("tipoDireccion", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Descripcion = "Hogar"
                        },
                        new
                        {
                            Id = 2,
                            Descripcion = "Oficina"
                        });
                });

            modelBuilder.Entity("Domain.Entities.TipoPersona", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.HasKey("Id");

                    b.ToTable("tipoPersona", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Descripcion = "Empleado"
                        },
                        new
                        {
                            Id = 2,
                            Descripcion = "Cliente"
                        });
                });

            modelBuilder.Entity("Domain.Entities.Turno", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<TimeSpan>("HoraFinTurno")
                        .HasColumnType("time(6)");

                    b.Property<TimeSpan>("HoraInicioTurno")
                        .HasColumnType("time(6)");

                    b.Property<string>("NombreTurno")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Turno", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            HoraFinTurno = new TimeSpan(0, 6, 2, 0, 0),
                            HoraInicioTurno = new TimeSpan(0, 5, 30, 0, 0),
                            NombreTurno = "Diurno"
                        },
                        new
                        {
                            Id = 2,
                            HoraFinTurno = new TimeSpan(0, 7, 58, 0, 0),
                            HoraInicioTurno = new TimeSpan(0, 3, 33, 0, 0),
                            NombreTurno = "Nocturno"
                        });
                });

            modelBuilder.Entity("Domain.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Contraseña")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.HasKey("Id");

                    b.ToTable("user", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Contraseña = "1234",
                            Email = "kevin@gmail.com",
                            Nombre = "Kevin"
                        },
                        new
                        {
                            Id = 2,
                            Contraseña = "1234",
                            Email = "user@gmail.com",
                            Nombre = "user"
                        });
                });

            modelBuilder.Entity("Domain.Entities.UserRol", b =>
                {
                    b.Property<int>("IdUsuarioFk")
                        .HasColumnType("int");

                    b.Property<int>("IdRolFk")
                        .HasColumnType("int");

                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.HasKey("IdUsuarioFk", "IdRolFk");

                    b.HasIndex("IdRolFk");

                    b.ToTable("usersRols", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.Ciudad", b =>
                {
                    b.HasOne("Domain.Entities.Departamento", "Departamento")
                        .WithMany("Ciudades")
                        .HasForeignKey("IdDepartamentoFk")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Departamento");
                });

            modelBuilder.Entity("Domain.Entities.ContactoPersona", b =>
                {
                    b.HasOne("Domain.Entities.Persona", "persona")
                        .WithMany("ContactosPersonas")
                        .HasForeignKey("IdPersonaFk")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.TipoContacto", "TipoContacto")
                        .WithMany("ContactosPersonas")
                        .HasForeignKey("IdTipoContactoFk")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("TipoContacto");

                    b.Navigation("persona");
                });

            modelBuilder.Entity("Domain.Entities.Contrato", b =>
                {
                    b.HasOne("Domain.Entities.Persona", "Personaa")
                        .WithMany("Contratos")
                        .HasForeignKey("IdEmpleadoFk")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.Estado", "Estado")
                        .WithMany("Contratos")
                        .HasForeignKey("IdEstadoFk")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Estado");

                    b.Navigation("Personaa");
                });

            modelBuilder.Entity("Domain.Entities.Departamento", b =>
                {
                    b.HasOne("Domain.Entities.Pais", "Pais")
                        .WithMany("Departamentos")
                        .HasForeignKey("IdPaisFk")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Pais");
                });

            modelBuilder.Entity("Domain.Entities.DireccionPersona", b =>
                {
                    b.HasOne("Domain.Entities.Persona", "Persona")
                        .WithMany("DireccionesPersonas")
                        .HasForeignKey("IdPersonaFk")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.TipoDireccion", "TipoDireccion")
                        .WithMany("DireccionesPersonas")
                        .HasForeignKey("IdTipoDireccionFk")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Persona");

                    b.Navigation("TipoDireccion");
                });

            modelBuilder.Entity("Domain.Entities.Persona", b =>
                {
                    b.HasOne("Domain.Entities.CategoriaPersona", "CategoriaPersona")
                        .WithMany("Personas")
                        .HasForeignKey("IdCategoriaFk")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.Ciudad", "Ciudad")
                        .WithMany("Personas")
                        .HasForeignKey("IdCiudadFk")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.TipoPersona", "TipoPersona")
                        .WithMany("Personas")
                        .HasForeignKey("IdTipoPersonaFk")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CategoriaPersona");

                    b.Navigation("Ciudad");

                    b.Navigation("TipoPersona");
                });

            modelBuilder.Entity("Domain.Entities.Programacion", b =>
                {
                    b.HasOne("Domain.Entities.Contrato", "Contrato")
                        .WithMany("Programaciones")
                        .HasForeignKey("IdContratoFk")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.Persona", "Persona")
                        .WithMany("Programaciones")
                        .HasForeignKey("IdEmpleadoFk")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.Turno", "Turno")
                        .WithMany("Programaciones")
                        .HasForeignKey("IdTurnoFk")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Contrato");

                    b.Navigation("Persona");

                    b.Navigation("Turno");
                });

            modelBuilder.Entity("Domain.Entities.RefreshToken", b =>
                {
                    b.HasOne("Domain.Entities.User", "User")
                        .WithMany("RefreshTokens")
                        .HasForeignKey("IdUserFk")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Domain.Entities.UserRol", b =>
                {
                    b.HasOne("Domain.Entities.Rol", "Rol")
                        .WithMany("RolesUsuarios")
                        .HasForeignKey("IdRolFk")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.User", "Usuario")
                        .WithMany("RolesUsuarios")
                        .HasForeignKey("IdUsuarioFk")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Rol");

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("Domain.Entities.CategoriaPersona", b =>
                {
                    b.Navigation("Personas");
                });

            modelBuilder.Entity("Domain.Entities.Ciudad", b =>
                {
                    b.Navigation("Personas");
                });

            modelBuilder.Entity("Domain.Entities.Contrato", b =>
                {
                    b.Navigation("Programaciones");
                });

            modelBuilder.Entity("Domain.Entities.Departamento", b =>
                {
                    b.Navigation("Ciudades");
                });

            modelBuilder.Entity("Domain.Entities.Estado", b =>
                {
                    b.Navigation("Contratos");
                });

            modelBuilder.Entity("Domain.Entities.Pais", b =>
                {
                    b.Navigation("Departamentos");
                });

            modelBuilder.Entity("Domain.Entities.Persona", b =>
                {
                    b.Navigation("ContactosPersonas");

                    b.Navigation("Contratos");

                    b.Navigation("DireccionesPersonas");

                    b.Navigation("Programaciones");
                });

            modelBuilder.Entity("Domain.Entities.Rol", b =>
                {
                    b.Navigation("RolesUsuarios");
                });

            modelBuilder.Entity("Domain.Entities.TipoContacto", b =>
                {
                    b.Navigation("ContactosPersonas");
                });

            modelBuilder.Entity("Domain.Entities.TipoDireccion", b =>
                {
                    b.Navigation("DireccionesPersonas");
                });

            modelBuilder.Entity("Domain.Entities.TipoPersona", b =>
                {
                    b.Navigation("Personas");
                });

            modelBuilder.Entity("Domain.Entities.Turno", b =>
                {
                    b.Navigation("Programaciones");
                });

            modelBuilder.Entity("Domain.Entities.User", b =>
                {
                    b.Navigation("RefreshTokens");

                    b.Navigation("RolesUsuarios");
                });
#pragma warning restore 612, 618
        }
    }
}

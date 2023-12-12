using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Persistence.Data.Migrations
{
    /// <inheritdoc />
    public partial class initialCreatee1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "categoriaPersona",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    NombreCategoria = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_categoriaPersona", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "estado",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Descripcion = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_estado", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "pais",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    NombrePais = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_pais", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "rol",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_rol", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "tipoContacto",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Descripcion = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tipoContacto", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "tipoDireccion",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Descripcion = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tipoDireccion", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "tipoPersona",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Descripcion = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tipoPersona", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Turno",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    NombreTurno = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    HoraInicioTurno = table.Column<TimeSpan>(type: "time(6)", nullable: false),
                    HoraFinTurno = table.Column<TimeSpan>(type: "time(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Turno", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "user",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Email = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Contraseña = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "departamento",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    IdPaisFk = table.Column<int>(type: "int", nullable: false),
                    NombreDepartamento = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_departamento", x => x.Id);
                    table.ForeignKey(
                        name: "FK_departamento_pais_IdPaisFk",
                        column: x => x.IdPaisFk,
                        principalTable: "pais",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "refreshToken",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    IdUserFk = table.Column<int>(type: "int", nullable: false),
                    Token = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Expires = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Revoked = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_refreshToken", x => x.Id);
                    table.ForeignKey(
                        name: "FK_refreshToken_user_IdUserFk",
                        column: x => x.IdUserFk,
                        principalTable: "user",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "usersRols",
                columns: table => new
                {
                    IdUsuarioFk = table.Column<int>(type: "int", nullable: false),
                    IdRolFk = table.Column<int>(type: "int", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_usersRols", x => new { x.IdUsuarioFk, x.IdRolFk });
                    table.ForeignKey(
                        name: "FK_usersRols_rol_IdRolFk",
                        column: x => x.IdRolFk,
                        principalTable: "rol",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_usersRols_user_IdUsuarioFk",
                        column: x => x.IdUsuarioFk,
                        principalTable: "user",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ciudad",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    IdDepartamentoFk = table.Column<int>(type: "int", nullable: false),
                    NombreCiudad = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ciudad", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ciudad_departamento_IdDepartamentoFk",
                        column: x => x.IdDepartamentoFk,
                        principalTable: "departamento",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "persona",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    IdPersona = table.Column<int>(type: "int", nullable: false),
                    Nombre = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    FechaReg = table.Column<DateOnly>(type: "date", nullable: false),
                    IdTipoPersonaFk = table.Column<int>(type: "int", nullable: false),
                    IdCategoriaFk = table.Column<int>(type: "int", nullable: false),
                    IdCiudadFk = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_persona", x => x.Id);
                    table.ForeignKey(
                        name: "FK_persona_categoriaPersona_IdCategoriaFk",
                        column: x => x.IdCategoriaFk,
                        principalTable: "categoriaPersona",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_persona_ciudad_IdCiudadFk",
                        column: x => x.IdCiudadFk,
                        principalTable: "ciudad",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_persona_tipoPersona_IdTipoPersonaFk",
                        column: x => x.IdTipoPersonaFk,
                        principalTable: "tipoPersona",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "contactoPersona",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Descripcion = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IdPersonaFk = table.Column<int>(type: "int", nullable: false),
                    IdTipoContactoFk = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_contactoPersona", x => x.Id);
                    table.ForeignKey(
                        name: "FK_contactoPersona_persona_IdPersonaFk",
                        column: x => x.IdPersonaFk,
                        principalTable: "persona",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_contactoPersona_tipoContacto_IdTipoContactoFk",
                        column: x => x.IdTipoContactoFk,
                        principalTable: "tipoContacto",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "contrato",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    IdClienteFk = table.Column<int>(type: "int", nullable: false),
                    FechaContrato = table.Column<DateOnly>(type: "date", nullable: false),
                    IdEmpleadoFk = table.Column<int>(type: "int", nullable: false),
                    FechaFin = table.Column<DateOnly>(type: "date", nullable: false),
                    IdEstadoFk = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_contrato", x => x.Id);
                    table.ForeignKey(
                        name: "FK_contrato_estado_IdEstadoFk",
                        column: x => x.IdEstadoFk,
                        principalTable: "estado",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_contrato_persona_IdEmpleadoFk",
                        column: x => x.IdEmpleadoFk,
                        principalTable: "persona",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "direccionPersona",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CallePrincipal = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CalleSecundaria = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Avenida = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    InformacionAdicional = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IdPersonaFk = table.Column<int>(type: "int", nullable: false),
                    IdTipoDireccionFk = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_direccionPersona", x => x.Id);
                    table.ForeignKey(
                        name: "FK_direccionPersona_persona_IdPersonaFk",
                        column: x => x.IdPersonaFk,
                        principalTable: "persona",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_direccionPersona_tipoDireccion_IdTipoDireccionFk",
                        column: x => x.IdTipoDireccionFk,
                        principalTable: "tipoDireccion",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "programacion",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    IdContratoFk = table.Column<int>(type: "int", nullable: false),
                    IdTurnoFk = table.Column<int>(type: "int", nullable: false),
                    IdEmpleadoFk = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_programacion", x => x.Id);
                    table.ForeignKey(
                        name: "FK_programacion_Turno_IdTurnoFk",
                        column: x => x.IdTurnoFk,
                        principalTable: "Turno",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_programacion_contrato_IdContratoFk",
                        column: x => x.IdContratoFk,
                        principalTable: "contrato",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_programacion_persona_IdEmpleadoFk",
                        column: x => x.IdEmpleadoFk,
                        principalTable: "persona",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "Turno",
                columns: new[] { "Id", "HoraFinTurno", "HoraInicioTurno", "NombreTurno" },
                values: new object[,]
                {
                    { 1, new TimeSpan(0, 6, 2, 0, 0), new TimeSpan(0, 5, 30, 0, 0), "Diurno" },
                    { 2, new TimeSpan(0, 7, 58, 0, 0), new TimeSpan(0, 3, 33, 0, 0), "Nocturno" }
                });

            migrationBuilder.InsertData(
                table: "categoriaPersona",
                columns: new[] { "Id", "NombreCategoria" },
                values: new object[,]
                {
                    { 1, "Vigilantes" },
                    { 2, "Aseo" }
                });

            migrationBuilder.InsertData(
                table: "estado",
                columns: new[] { "Id", "Descripcion" },
                values: new object[,]
                {
                    { 1, "Activo" },
                    { 2, "Inactivo" }
                });

            migrationBuilder.InsertData(
                table: "pais",
                columns: new[] { "Id", "NombrePais" },
                values: new object[,]
                {
                    { 1, "Colombia" },
                    { 2, "Estados Unidos" }
                });

            migrationBuilder.InsertData(
                table: "rol",
                columns: new[] { "Id", "Nombre" },
                values: new object[,]
                {
                    { 1, "Administrador" },
                    { 2, "Empleado" }
                });

            migrationBuilder.InsertData(
                table: "tipoContacto",
                columns: new[] { "Id", "Descripcion" },
                values: new object[,]
                {
                    { 1, "Emergencia" },
                    { 2, "Normal" }
                });

            migrationBuilder.InsertData(
                table: "tipoDireccion",
                columns: new[] { "Id", "Descripcion" },
                values: new object[,]
                {
                    { 1, "Hogar" },
                    { 2, "Oficina" }
                });

            migrationBuilder.InsertData(
                table: "tipoPersona",
                columns: new[] { "Id", "Descripcion" },
                values: new object[,]
                {
                    { 1, "Empleado" },
                    { 2, "Cliente" }
                });

            migrationBuilder.InsertData(
                table: "user",
                columns: new[] { "Id", "Contraseña", "Email", "Nombre" },
                values: new object[,]
                {
                    { 1, "1234", "kevin@gmail.com", "Kevin" },
                    { 2, "1234", "user@gmail.com", "user" }
                });

            migrationBuilder.InsertData(
                table: "departamento",
                columns: new[] { "Id", "IdPaisFk", "NombreDepartamento" },
                values: new object[,]
                {
                    { 1, 1, "Santander" },
                    { 2, 2, "California" }
                });

            migrationBuilder.InsertData(
                table: "ciudad",
                columns: new[] { "Id", "IdDepartamentoFk", "NombreCiudad" },
                values: new object[,]
                {
                    { 1, 1, "Bucaramanga" },
                    { 2, 1, "Piedecuesta" },
                    { 3, 1, "Giron" }
                });

            migrationBuilder.InsertData(
                table: "persona",
                columns: new[] { "Id", "FechaReg", "IdCategoriaFk", "IdCiudadFk", "IdPersona", "IdTipoPersonaFk", "Nombre" },
                values: new object[,]
                {
                    { 1, new DateOnly(2023, 1, 1), 2, 1, 4324, 1, "Carlos Marin" },
                    { 2, new DateOnly(2023, 2, 25), 1, 2, 333, 2, "Maria Gonzales" },
                    { 3, new DateOnly(2000, 2, 15), 1, 2, 5453, 2, "Jose Gomez" },
                    { 4, new DateOnly(2003, 7, 3), 2, 1, 1274, 2, "Luis Villa" },
                    { 5, new DateOnly(2015, 4, 1), 1, 1, 89, 1, "Jose Manrrique" },
                    { 6, new DateOnly(2019, 11, 21), 1, 2, 664, 1, "Emanuel Torres" },
                    { 7, new DateOnly(2023, 6, 12), 1, 2, 43244, 1, "Luna Cardenas" }
                });

            migrationBuilder.InsertData(
                table: "contactoPersona",
                columns: new[] { "Id", "Descripcion", "IdPersonaFk", "IdTipoContactoFk" },
                values: new object[,]
                {
                    { 1, "Madre", 1, 2 },
                    { 2, "Abuelo", 2, 1 },
                    { 3, "Abuela", 5, 1 },
                    { 4, "Tia", 4, 2 },
                    { 5, "Esposa", 5, 1 },
                    { 6, "Hermano", 6, 2 }
                });

            migrationBuilder.InsertData(
                table: "contrato",
                columns: new[] { "Id", "FechaContrato", "FechaFin", "IdClienteFk", "IdEmpleadoFk", "IdEstadoFk" },
                values: new object[,]
                {
                    { 1, new DateOnly(2023, 8, 3), new DateOnly(2023, 10, 2), 2, 1, 1 },
                    { 2, new DateOnly(2023, 7, 23), new DateOnly(2023, 8, 12), 1, 2, 2 }
                });

            migrationBuilder.InsertData(
                table: "direccionPersona",
                columns: new[] { "Id", "Avenida", "CallePrincipal", "CalleSecundaria", "IdPersonaFk", "IdTipoDireccionFk", "InformacionAdicional" },
                values: new object[,]
                {
                    { 1, "Av arenales", "Cll 23 A", "Cll 1", 2, 1, "Cerca de la iglesia" },
                    { 2, "Av 1 Casanare", "Cll 55", "Cll 79", 1, 2, "Detras del estadio" }
                });

            migrationBuilder.InsertData(
                table: "programacion",
                columns: new[] { "Id", "IdContratoFk", "IdEmpleadoFk", "IdTurnoFk" },
                values: new object[,]
                {
                    { 1, 1, 1, 2 },
                    { 2, 2, 1, 1 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ciudad_IdDepartamentoFk",
                table: "ciudad",
                column: "IdDepartamentoFk");

            migrationBuilder.CreateIndex(
                name: "IX_contactoPersona_Descripcion",
                table: "contactoPersona",
                column: "Descripcion",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_contactoPersona_IdPersonaFk",
                table: "contactoPersona",
                column: "IdPersonaFk");

            migrationBuilder.CreateIndex(
                name: "IX_contactoPersona_IdTipoContactoFk",
                table: "contactoPersona",
                column: "IdTipoContactoFk");

            migrationBuilder.CreateIndex(
                name: "IX_contrato_IdEmpleadoFk",
                table: "contrato",
                column: "IdEmpleadoFk");

            migrationBuilder.CreateIndex(
                name: "IX_contrato_IdEstadoFk",
                table: "contrato",
                column: "IdEstadoFk");

            migrationBuilder.CreateIndex(
                name: "IX_departamento_IdPaisFk",
                table: "departamento",
                column: "IdPaisFk");

            migrationBuilder.CreateIndex(
                name: "IX_direccionPersona_IdPersonaFk",
                table: "direccionPersona",
                column: "IdPersonaFk");

            migrationBuilder.CreateIndex(
                name: "IX_direccionPersona_IdTipoDireccionFk",
                table: "direccionPersona",
                column: "IdTipoDireccionFk");

            migrationBuilder.CreateIndex(
                name: "IX_persona_IdCategoriaFk",
                table: "persona",
                column: "IdCategoriaFk");

            migrationBuilder.CreateIndex(
                name: "IX_persona_IdCiudadFk",
                table: "persona",
                column: "IdCiudadFk");

            migrationBuilder.CreateIndex(
                name: "IX_persona_IdPersona",
                table: "persona",
                column: "IdPersona",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_persona_IdTipoPersonaFk",
                table: "persona",
                column: "IdTipoPersonaFk");

            migrationBuilder.CreateIndex(
                name: "IX_programacion_IdContratoFk",
                table: "programacion",
                column: "IdContratoFk");

            migrationBuilder.CreateIndex(
                name: "IX_programacion_IdEmpleadoFk",
                table: "programacion",
                column: "IdEmpleadoFk");

            migrationBuilder.CreateIndex(
                name: "IX_programacion_IdTurnoFk",
                table: "programacion",
                column: "IdTurnoFk");

            migrationBuilder.CreateIndex(
                name: "IX_refreshToken_IdUserFk",
                table: "refreshToken",
                column: "IdUserFk");

            migrationBuilder.CreateIndex(
                name: "IX_usersRols_IdRolFk",
                table: "usersRols",
                column: "IdRolFk");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "contactoPersona");

            migrationBuilder.DropTable(
                name: "direccionPersona");

            migrationBuilder.DropTable(
                name: "programacion");

            migrationBuilder.DropTable(
                name: "refreshToken");

            migrationBuilder.DropTable(
                name: "usersRols");

            migrationBuilder.DropTable(
                name: "tipoContacto");

            migrationBuilder.DropTable(
                name: "tipoDireccion");

            migrationBuilder.DropTable(
                name: "Turno");

            migrationBuilder.DropTable(
                name: "contrato");

            migrationBuilder.DropTable(
                name: "rol");

            migrationBuilder.DropTable(
                name: "user");

            migrationBuilder.DropTable(
                name: "estado");

            migrationBuilder.DropTable(
                name: "persona");

            migrationBuilder.DropTable(
                name: "categoriaPersona");

            migrationBuilder.DropTable(
                name: "ciudad");

            migrationBuilder.DropTable(
                name: "tipoPersona");

            migrationBuilder.DropTable(
                name: "departamento");

            migrationBuilder.DropTable(
                name: "pais");
        }
    }
}

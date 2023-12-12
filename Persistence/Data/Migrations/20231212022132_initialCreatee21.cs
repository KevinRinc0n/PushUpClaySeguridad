using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Persistence.Data.Migrations
{
    /// <inheritdoc />
    public partial class initialCreatee21 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "persona",
                columns: new[] { "Id", "FechaReg", "IdCategoriaFk", "IdCiudadFk", "IdPersona", "IdTipoPersonaFk", "Nombre" },
                values: new object[,]
                {
                    { 8, new DateOnly(2019, 11, 21), 1, 1, 343, 2, "Paco Diaz" },
                    { 9, new DateOnly(2012, 1, 21), 1, 1, 1634, 2, "Jaime Caseres" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "persona",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "persona",
                keyColumn: "Id",
                keyValue: 9);
        }
    }
}

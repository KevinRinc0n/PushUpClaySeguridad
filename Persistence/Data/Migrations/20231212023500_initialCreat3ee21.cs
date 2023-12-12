using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Persistence.Data.Migrations
{
    /// <inheritdoc />
    public partial class initialCreat3ee21 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "persona",
                columns: new[] { "Id", "FechaReg", "IdCategoriaFk", "IdCiudadFk", "IdPersona", "IdTipoPersonaFk", "Nombre" },
                values: new object[,]
                {
                    { 10, new DateOnly(1999, 2, 21), 1, 2, 9675, 1, "Luisa Hernandez" },
                    { 11, new DateOnly(2012, 6, 18), 1, 2, 86756, 1, "Nicole Orduz" },
                    { 12, new DateOnly(2017, 1, 21), 2, 3, 6565, 1, "Mauricio Jaimes" },
                    { 13, new DateOnly(2018, 9, 27), 2, 2, 24324, 1, "Fernando Cardenas" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "persona",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "persona",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "persona",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "persona",
                keyColumn: "Id",
                keyValue: 13);
        }
    }
}

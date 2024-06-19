using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EXAMEN_PARCIAL_2.Migrations
{
    /// <inheritdoc />
    public partial class CrearTablasMarcasYJuguetes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "juguetes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Codigo = table.Column<int>(type: "int", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Precio = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Vigencia = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Activo = table.Column<bool>(type: "bit", nullable: false),
                    JugueteId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_juguetes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_juguetes_juguetes_JugueteId",
                        column: x => x.JugueteId,
                        principalTable: "juguetes",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "marca",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Codigo = table.Column<int>(type: "int", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Activo = table.Column<bool>(type: "bit", nullable: false),
                    MarcaId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_marca", x => x.Id);
                    table.ForeignKey(
                        name: "FK_marca_marca_MarcaId",
                        column: x => x.MarcaId,
                        principalTable: "marca",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_juguetes_JugueteId",
                table: "juguetes",
                column: "JugueteId");

            migrationBuilder.CreateIndex(
                name: "IX_marca_MarcaId",
                table: "marca",
                column: "MarcaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "juguetes");

            migrationBuilder.DropTable(
                name: "marca");
        }
    }
}

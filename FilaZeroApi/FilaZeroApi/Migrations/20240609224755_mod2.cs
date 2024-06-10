using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FilaZeroApi.Migrations
{
    /// <inheritdoc />
    public partial class mod2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "agenciasCapacidade",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "TEXT", nullable: false),
                    agenciaId = table.Column<Guid>(type: "TEXT", nullable: false),
                    HorarioFechamento = table.Column<string>(type: "TEXT", nullable: false),
                    HorarioAbertura = table.Column<string>(type: "TEXT", nullable: false),
                    lotacao = table.Column<int>(type: "INTEGER", nullable: false),
                    quantidadeFichas = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_agenciasCapacidade", x => x.id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "agenciasCapacidade");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FilaZeroApi.Migrations
{
    /// <inheritdoc />
    public partial class mod1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "nome",
                table: "Agencias",
                newName: "senha");

            migrationBuilder.AddColumn<string>(
                name: "cnpj",
                table: "Agencias",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "codigoAgencia",
                table: "Agencias",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "endereco",
                table: "Agencias",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "nomeBanco",
                table: "Agencias",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "nomeCompleto",
                table: "Agencias",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "cnpj",
                table: "Agencias");

            migrationBuilder.DropColumn(
                name: "codigoAgencia",
                table: "Agencias");

            migrationBuilder.DropColumn(
                name: "endereco",
                table: "Agencias");

            migrationBuilder.DropColumn(
                name: "nomeBanco",
                table: "Agencias");

            migrationBuilder.DropColumn(
                name: "nomeCompleto",
                table: "Agencias");

            migrationBuilder.RenameColumn(
                name: "senha",
                table: "Agencias",
                newName: "nome");
        }
    }
}

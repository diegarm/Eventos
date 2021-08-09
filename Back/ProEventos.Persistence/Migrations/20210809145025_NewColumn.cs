using Microsoft.EntityFrameworkCore.Migrations;

namespace ProEventos.Persistence.Migrations
{
    public partial class NewColumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RedeSociais_Palestrantes_palestranteId",
                table: "RedeSociais");

            migrationBuilder.DropColumn(
                name: "Palestrante",
                table: "RedeSociais");

            migrationBuilder.RenameColumn(
                name: "palestranteId",
                table: "RedeSociais",
                newName: "PalestranteId");

            migrationBuilder.RenameIndex(
                name: "IX_RedeSociais_palestranteId",
                table: "RedeSociais",
                newName: "IX_RedeSociais_PalestranteId");

            migrationBuilder.AddForeignKey(
                name: "FK_RedeSociais_Palestrantes_PalestranteId",
                table: "RedeSociais",
                column: "PalestranteId",
                principalTable: "Palestrantes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RedeSociais_Palestrantes_PalestranteId",
                table: "RedeSociais");

            migrationBuilder.RenameColumn(
                name: "PalestranteId",
                table: "RedeSociais",
                newName: "palestranteId");

            migrationBuilder.RenameIndex(
                name: "IX_RedeSociais_PalestranteId",
                table: "RedeSociais",
                newName: "IX_RedeSociais_palestranteId");

            migrationBuilder.AddColumn<int>(
                name: "Palestrante",
                table: "RedeSociais",
                type: "int",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_RedeSociais_Palestrantes_palestranteId",
                table: "RedeSociais",
                column: "palestranteId",
                principalTable: "Palestrantes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

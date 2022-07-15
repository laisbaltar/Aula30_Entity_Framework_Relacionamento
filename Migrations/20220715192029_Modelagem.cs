using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Aula30.Migrations
{
    public partial class Modelagem : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "InstituicaoModelId",
                table: "Alunos",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Alunos_InstituicaoModelId",
                table: "Alunos",
                column: "InstituicaoModelId");

            migrationBuilder.AddForeignKey(
                name: "FK_Alunos_Instituicoes_InstituicaoModelId",
                table: "Alunos",
                column: "InstituicaoModelId",
                principalTable: "Instituicoes",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Alunos_Instituicoes_InstituicaoModelId",
                table: "Alunos");

            migrationBuilder.DropIndex(
                name: "IX_Alunos_InstituicaoModelId",
                table: "Alunos");

            migrationBuilder.DropColumn(
                name: "InstituicaoModelId",
                table: "Alunos");
        }
    }
}

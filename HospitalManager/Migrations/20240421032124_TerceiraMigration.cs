using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HospitalManager.Migrations
{
    public partial class TerceiraMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Funcionarios_Departamentos_departamentoId",
                table: "Funcionarios");

            migrationBuilder.RenameColumn(
                name: "departamentoId",
                table: "Funcionarios",
                newName: "DepartamentoId");

            migrationBuilder.RenameIndex(
                name: "IX_Funcionarios_departamentoId",
                table: "Funcionarios",
                newName: "IX_Funcionarios_DepartamentoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Funcionarios_Departamentos_DepartamentoId",
                table: "Funcionarios",
                column: "DepartamentoId",
                principalTable: "Departamentos",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Funcionarios_Departamentos_DepartamentoId",
                table: "Funcionarios");

            migrationBuilder.RenameColumn(
                name: "DepartamentoId",
                table: "Funcionarios",
                newName: "departamentoId");

            migrationBuilder.RenameIndex(
                name: "IX_Funcionarios_DepartamentoId",
                table: "Funcionarios",
                newName: "IX_Funcionarios_departamentoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Funcionarios_Departamentos_departamentoId",
                table: "Funcionarios",
                column: "departamentoId",
                principalTable: "Departamentos",
                principalColumn: "Id");
        }
    }
}

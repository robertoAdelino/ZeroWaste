using Microsoft.EntityFrameworkCore.Migrations;

namespace ZeroWaste.Migrations
{
    public partial class dados : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "NumeroPessoasAbrangidas",
                table: "Instituicoes",
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<int>(
                name: "NumeroPessoasAgregado",
                table: "Familias",
                nullable: false,
                oldClrType: typeof(string));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "NumeroPessoasAbrangidas",
                table: "Instituicoes",
                nullable: false,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<string>(
                name: "NumeroPessoasAgregado",
                table: "Familias",
                nullable: false,
                oldClrType: typeof(int));
        }
    }
}

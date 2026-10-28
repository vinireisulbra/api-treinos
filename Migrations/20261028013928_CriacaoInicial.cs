using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ApiTreinos.Migrations
{
    /// <inheritdoc />
    public partial class CriacaoInicial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Treinos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nome = table.Column<string>(type: "TEXT", nullable: false),
                    GrupoMuscular = table.Column<string>(type: "TEXT", nullable: false),
                    Series = table.Column<int>(type: "INTEGER", nullable: false),
                    Repeticoes = table.Column<int>(type: "INTEGER", nullable: false),
                    Carga = table.Column<decimal>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Treinos", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Treinos",
                columns: new[] { "Id", "Carga", "GrupoMuscular", "Nome", "Repeticoes", "Series" },
                values: new object[,]
                {
                    { 1, 20.0m, "Peito", "Treino A - Peito e Tríceps", 12, 4 },
                    { 2, 15.0m, "Costas", "Treino B - Costas e Bíceps", 10, 3 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Treinos");
        }
    }
}

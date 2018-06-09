using Microsoft.EntityFrameworkCore.Migrations;

namespace AplikacjaKulinarna.Repository.Migrations
{
    public partial class AddDifficultyToRecipe : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Difficulty",
                table: "Recipes",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Difficulty",
                table: "Recipes");
        }
    }
}

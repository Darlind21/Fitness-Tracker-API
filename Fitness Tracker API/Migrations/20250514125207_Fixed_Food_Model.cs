using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Fitness_Tracker_API.Migrations
{
    /// <inheritdoc />
    public partial class Fixed_Food_Model : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SugarInCarbsGrams",
                table: "Foods");

            migrationBuilder.RenameColumn(
                name: "ServingPortionInGrams",
                table: "Foods",
                newName: "ServingInGrams");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ServingInGrams",
                table: "Foods",
                newName: "ServingPortionInGrams");

            migrationBuilder.AddColumn<float>(
                name: "SugarInCarbsGrams",
                table: "Foods",
                type: "real",
                nullable: false,
                defaultValue: 0f);
        }
    }
}

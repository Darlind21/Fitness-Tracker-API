﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Fitness_Tracker_API.Migrations
{
    /// <inheritdoc />
    public partial class Fixed_Food_Model_again : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<float>(
                name: "Calories",
                table: "Foods",
                type: "real",
                nullable: true,
                oldClrType: typeof(float),
                oldType: "real");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<float>(
                name: "Calories",
                table: "Foods",
                type: "real",
                nullable: false,
                defaultValue: 0f,
                oldClrType: typeof(float),
                oldType: "real",
                oldNullable: true);
        }
    }
}

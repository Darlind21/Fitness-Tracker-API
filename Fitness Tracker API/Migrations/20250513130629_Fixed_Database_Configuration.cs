using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Fitness_Tracker_API.Migrations
{
    /// <inheritdoc />
    public partial class Fixed_Database_Configuration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Excercises_Workouts_WorkoutId",
                table: "Excercises");

            migrationBuilder.DropForeignKey(
                name: "FK_Foods_Meals_MealId",
                table: "Foods");

            migrationBuilder.DropForeignKey(
                name: "FK_WorkoutSets_Excercises_ExcerciseId",
                table: "WorkoutSets");

            migrationBuilder.DropIndex(
                name: "IX_Foods_MealId",
                table: "Foods");

            migrationBuilder.DropIndex(
                name: "IX_Excercises_WorkoutId",
                table: "Excercises");

            migrationBuilder.DropColumn(
                name: "MealId",
                table: "Foods");

            migrationBuilder.DropColumn(
                name: "TargetedMuscleGroups",
                table: "Excercises");

            migrationBuilder.DropColumn(
                name: "WorkoutId",
                table: "Excercises");

            migrationBuilder.RenameColumn(
                name: "ExcerciseId",
                table: "WorkoutSets",
                newName: "WorkoutExcerciseId");

            migrationBuilder.RenameIndex(
                name: "IX_WorkoutSets_ExcerciseId",
                table: "WorkoutSets",
                newName: "IX_WorkoutSets_WorkoutExcerciseId");

            migrationBuilder.AlterColumn<string>(
                name: "Status",
                table: "Workouts",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MealType",
                table: "Meals",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "TypeOfExcercise",
                table: "Excercises",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "TypeOfEquipment",
                table: "Excercises",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "ConsumedFood",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MealId = table.Column<int>(type: "int", nullable: false),
                    FoodId = table.Column<int>(type: "int", nullable: false),
                    ServingPortionInGrams = table.Column<byte>(type: "tinyint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConsumedFood", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ConsumedFood_Foods_FoodId",
                        column: x => x.FoodId,
                        principalTable: "Foods",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ConsumedFood_Meals_MealId",
                        column: x => x.MealId,
                        principalTable: "Meals",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TargetedMuscleGroups",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TargetedMuscleGroups", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WorkoutExcercises",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WorkoutId = table.Column<int>(type: "int", nullable: false),
                    ExcerciseId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkoutExcercises", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WorkoutExcercises_Excercises_ExcerciseId",
                        column: x => x.ExcerciseId,
                        principalTable: "Excercises",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WorkoutExcercises_Workouts_WorkoutId",
                        column: x => x.WorkoutId,
                        principalTable: "Workouts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ExcerciseTargetedMuscleGroup",
                columns: table => new
                {
                    ExcercisesId = table.Column<int>(type: "int", nullable: false),
                    TargetedMuscleGroupsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExcerciseTargetedMuscleGroup", x => new { x.ExcercisesId, x.TargetedMuscleGroupsId });
                    table.ForeignKey(
                        name: "FK_ExcerciseTargetedMuscleGroup_Excercises_ExcercisesId",
                        column: x => x.ExcercisesId,
                        principalTable: "Excercises",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ExcerciseTargetedMuscleGroup_TargetedMuscleGroups_TargetedMuscleGroupsId",
                        column: x => x.TargetedMuscleGroupsId,
                        principalTable: "TargetedMuscleGroups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ConsumedFood_FoodId",
                table: "ConsumedFood",
                column: "FoodId");

            migrationBuilder.CreateIndex(
                name: "IX_ConsumedFood_MealId",
                table: "ConsumedFood",
                column: "MealId");

            migrationBuilder.CreateIndex(
                name: "IX_ExcerciseTargetedMuscleGroup_TargetedMuscleGroupsId",
                table: "ExcerciseTargetedMuscleGroup",
                column: "TargetedMuscleGroupsId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkoutExcercises_ExcerciseId",
                table: "WorkoutExcercises",
                column: "ExcerciseId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkoutExcercises_WorkoutId",
                table: "WorkoutExcercises",
                column: "WorkoutId");

            migrationBuilder.AddForeignKey(
                name: "FK_WorkoutSets_WorkoutExcercises_WorkoutExcerciseId",
                table: "WorkoutSets",
                column: "WorkoutExcerciseId",
                principalTable: "WorkoutExcercises",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WorkoutSets_WorkoutExcercises_WorkoutExcerciseId",
                table: "WorkoutSets");

            migrationBuilder.DropTable(
                name: "ConsumedFood");

            migrationBuilder.DropTable(
                name: "ExcerciseTargetedMuscleGroup");

            migrationBuilder.DropTable(
                name: "WorkoutExcercises");

            migrationBuilder.DropTable(
                name: "TargetedMuscleGroups");

            migrationBuilder.DropColumn(
                name: "MealType",
                table: "Meals");

            migrationBuilder.RenameColumn(
                name: "WorkoutExcerciseId",
                table: "WorkoutSets",
                newName: "ExcerciseId");

            migrationBuilder.RenameIndex(
                name: "IX_WorkoutSets_WorkoutExcerciseId",
                table: "WorkoutSets",
                newName: "IX_WorkoutSets_ExcerciseId");

            migrationBuilder.AlterColumn<int>(
                name: "Status",
                table: "Workouts",
                type: "int",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MealId",
                table: "Foods",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "TypeOfExcercise",
                table: "Excercises",
                type: "int",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "TypeOfEquipment",
                table: "Excercises",
                type: "int",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TargetedMuscleGroups",
                table: "Excercises",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "WorkoutId",
                table: "Excercises",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Foods_MealId",
                table: "Foods",
                column: "MealId");

            migrationBuilder.CreateIndex(
                name: "IX_Excercises_WorkoutId",
                table: "Excercises",
                column: "WorkoutId");

            migrationBuilder.AddForeignKey(
                name: "FK_Excercises_Workouts_WorkoutId",
                table: "Excercises",
                column: "WorkoutId",
                principalTable: "Workouts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Foods_Meals_MealId",
                table: "Foods",
                column: "MealId",
                principalTable: "Meals",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_WorkoutSets_Excercises_ExcerciseId",
                table: "WorkoutSets",
                column: "ExcerciseId",
                principalTable: "Excercises",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

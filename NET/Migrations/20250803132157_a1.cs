using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NET.Migrations
{
    /// <inheritdoc />
    public partial class a1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ExercisesIds",
                table: "TrainingSessions");

            migrationBuilder.AddColumn<int>(
                name: "WorkoutId",
                table: "TrainingSessions",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_TrainingSessions_WorkoutId",
                table: "TrainingSessions",
                column: "WorkoutId");

            migrationBuilder.AddForeignKey(
                name: "FK_TrainingSessions_Workouts_WorkoutId",
                table: "TrainingSessions",
                column: "WorkoutId",
                principalTable: "Workouts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TrainingSessions_Workouts_WorkoutId",
                table: "TrainingSessions");

            migrationBuilder.DropIndex(
                name: "IX_TrainingSessions_WorkoutId",
                table: "TrainingSessions");

            migrationBuilder.DropColumn(
                name: "WorkoutId",
                table: "TrainingSessions");

            migrationBuilder.AddColumn<int[]>(
                name: "ExercisesIds",
                table: "TrainingSessions",
                type: "integer[]",
                nullable: false,
                defaultValue: new int[0]);
        }
    }
}

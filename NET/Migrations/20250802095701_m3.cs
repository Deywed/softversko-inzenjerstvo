using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NET.Migrations
{
    /// <inheritdoc />
    public partial class m3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Exercises_TrainingSessions_TrainingSessionId",
                table: "Exercises");

            migrationBuilder.DropIndex(
                name: "IX_Exercises_TrainingSessionId",
                table: "Exercises");

            migrationBuilder.DropColumn(
                name: "Lastname",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "TrainingSessionId",
                table: "Exercises");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Users",
                newName: "Username");

            migrationBuilder.AddColumn<int[]>(
                name: "ExercisesIds",
                table: "TrainingSessions",
                type: "integer[]",
                nullable: false,
                defaultValue: new int[0]);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ExercisesIds",
                table: "TrainingSessions");

            migrationBuilder.RenameColumn(
                name: "Username",
                table: "Users",
                newName: "Name");

            migrationBuilder.AddColumn<string>(
                name: "Lastname",
                table: "Users",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TrainingSessionId",
                table: "Exercises",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Exercises_TrainingSessionId",
                table: "Exercises",
                column: "TrainingSessionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Exercises_TrainingSessions_TrainingSessionId",
                table: "Exercises",
                column: "TrainingSessionId",
                principalTable: "TrainingSessions",
                principalColumn: "Id");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NET.Migrations
{
    /// <inheritdoc />
    public partial class m6 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Gyms_Cities_CityId",
                table: "Gyms");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Gyms_GymId",
                table: "Users");

            migrationBuilder.RenameColumn(
                name: "GymId",
                table: "Users",
                newName: "GymID");

            migrationBuilder.RenameIndex(
                name: "IX_Users_GymId",
                table: "Users",
                newName: "IX_Users_GymID");

            migrationBuilder.AlterColumn<int>(
                name: "GymID",
                table: "Users",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CityId",
                table: "Gyms",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddForeignKey(
                name: "FK_Gyms_Cities_CityId",
                table: "Gyms",
                column: "CityId",
                principalTable: "Cities",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Gyms_GymID",
                table: "Users",
                column: "GymID",
                principalTable: "Gyms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Gyms_Cities_CityId",
                table: "Gyms");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Gyms_GymID",
                table: "Users");

            migrationBuilder.RenameColumn(
                name: "GymID",
                table: "Users",
                newName: "GymId");

            migrationBuilder.RenameIndex(
                name: "IX_Users_GymID",
                table: "Users",
                newName: "IX_Users_GymId");

            migrationBuilder.AlterColumn<int>(
                name: "GymId",
                table: "Users",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<int>(
                name: "CityId",
                table: "Gyms",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Gyms_Cities_CityId",
                table: "Gyms",
                column: "CityId",
                principalTable: "Cities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Gyms_GymId",
                table: "Users",
                column: "GymId",
                principalTable: "Gyms",
                principalColumn: "Id");
        }
    }
}

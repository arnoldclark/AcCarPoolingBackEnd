using Microsoft.EntityFrameworkCore.Migrations;

namespace AcCarPooling.Migrations
{
    public partial class FixingRequiredJourney : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_User_Journey_JourneyId",
                table: "User");

            migrationBuilder.AlterColumn<int>(
                name: "JourneyId",
                table: "User",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_User_Journey_JourneyId",
                table: "User",
                column: "JourneyId",
                principalTable: "Journey",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_User_Journey_JourneyId",
                table: "User");

            migrationBuilder.AlterColumn<int>(
                name: "JourneyId",
                table: "User",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_User_Journey_JourneyId",
                table: "User",
                column: "JourneyId",
                principalTable: "Journey",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

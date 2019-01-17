using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AcCarPooling.Migrations
{
    public partial class AddLiftRequests : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LiftRequest",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    JourneyId = table.Column<int>(nullable: true),
                    DriverId = table.Column<int>(nullable: true),
                    PassengerId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LiftRequest", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LiftRequest_User_DriverId",
                        column: x => x.DriverId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_LiftRequest_Journey_JourneyId",
                        column: x => x.JourneyId,
                        principalTable: "Journey",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_LiftRequest_User_PassengerId",
                        column: x => x.PassengerId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LiftRequest_DriverId",
                table: "LiftRequest",
                column: "DriverId");

            migrationBuilder.CreateIndex(
                name: "IX_LiftRequest_JourneyId",
                table: "LiftRequest",
                column: "JourneyId");

            migrationBuilder.CreateIndex(
                name: "IX_LiftRequest_PassengerId",
                table: "LiftRequest",
                column: "PassengerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LiftRequest");
        }
    }
}

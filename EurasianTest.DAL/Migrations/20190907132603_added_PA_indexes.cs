using Microsoft.EntityFrameworkCore.Migrations;

namespace EurasianTest.DAL.Migrations
{
    public partial class added_PA_indexes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProjectAdministrators_Users_ProjectId",
                table: "ProjectAdministrators");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectAdministrators_UserId",
                table: "ProjectAdministrators",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectAdministrators_Users_UserId",
                table: "ProjectAdministrators",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProjectAdministrators_Users_UserId",
                table: "ProjectAdministrators");

            migrationBuilder.DropIndex(
                name: "IX_ProjectAdministrators_UserId",
                table: "ProjectAdministrators");

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectAdministrators_Users_ProjectId",
                table: "ProjectAdministrators",
                column: "ProjectId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

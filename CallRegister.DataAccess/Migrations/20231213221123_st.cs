using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CallRegisterWeb.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class st : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Agents_Teams_TeamsId",
                table: "Agents");

            migrationBuilder.DropIndex(
                name: "IX_Agents_TeamsId",
                table: "Agents");

            migrationBuilder.DropColumn(
                name: "TeamsId",
                table: "Agents");

            migrationBuilder.CreateIndex(
                name: "IX_Agents_TeamId",
                table: "Agents",
                column: "TeamId");

            migrationBuilder.AddForeignKey(
                name: "FK_Agents_Teams_TeamId",
                table: "Agents",
                column: "TeamId",
                principalTable: "Teams",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Agents_Teams_TeamId",
                table: "Agents");

            migrationBuilder.DropIndex(
                name: "IX_Agents_TeamId",
                table: "Agents");

            migrationBuilder.AddColumn<int>(
                name: "TeamsId",
                table: "Agents",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Agents",
                keyColumn: "Id",
                keyValue: 1,
                column: "TeamsId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Agents",
                keyColumn: "Id",
                keyValue: 2,
                column: "TeamsId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Agents",
                keyColumn: "Id",
                keyValue: 3,
                column: "TeamsId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Agents",
                keyColumn: "Id",
                keyValue: 4,
                column: "TeamsId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Agents",
                keyColumn: "Id",
                keyValue: 5,
                column: "TeamsId",
                value: null);

            migrationBuilder.CreateIndex(
                name: "IX_Agents_TeamsId",
                table: "Agents",
                column: "TeamsId");

            migrationBuilder.AddForeignKey(
                name: "FK_Agents_Teams_TeamsId",
                table: "Agents",
                column: "TeamsId",
                principalTable: "Teams",
                principalColumn: "Id");
        }
    }
}

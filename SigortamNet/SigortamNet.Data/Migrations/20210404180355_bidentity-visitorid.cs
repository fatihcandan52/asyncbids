using Microsoft.EntityFrameworkCore.Migrations;

namespace SigortamNet.Data.Migrations
{
    public partial class bidentityvisitorid : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LicensePlate",
                table: "Bids");

            migrationBuilder.AddColumn<int>(
                name: "VisitorId",
                table: "Bids",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Bids_VisitorId",
                table: "Bids",
                column: "VisitorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Bids_Visitors_VisitorId",
                table: "Bids",
                column: "VisitorId",
                principalTable: "Visitors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bids_Visitors_VisitorId",
                table: "Bids");

            migrationBuilder.DropIndex(
                name: "IX_Bids_VisitorId",
                table: "Bids");

            migrationBuilder.DropColumn(
                name: "VisitorId",
                table: "Bids");

            migrationBuilder.AddColumn<string>(
                name: "LicensePlate",
                table: "Bids",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "");
        }
    }
}

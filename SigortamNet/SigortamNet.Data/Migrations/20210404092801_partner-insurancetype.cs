using Microsoft.EntityFrameworkCore.Migrations;

namespace SigortamNet.Data.Migrations
{
    public partial class partnerinsurancetype : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "InsuranceType",
                table: "Partners",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "InsuranceType",
                table: "Partners");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Bootcamp4_AspMVC.Migrations
{
    /// <inheritdoc />
    public partial class addColumPtoductUid : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Uid",
                table: "Products",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Uid",
                table: "Products");
        }
    }
}

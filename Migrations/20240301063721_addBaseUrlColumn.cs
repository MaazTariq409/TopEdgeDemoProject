using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TopEdgeDemoProject.Migrations
{
    /// <inheritdoc />
    public partial class addBaseUrlColumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "baseUrl",
                table: "ScrapData",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "baseUrl",
                table: "ScrapData");
        }
    }
}

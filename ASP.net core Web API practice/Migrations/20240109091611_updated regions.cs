using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WalkandTrailsofSAAPI.Migrations
{
    /// <inheritdoc />
    public partial class updatedregions : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "WalkImaeUrl",
                table: "Walks",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "WalkImaeUrl",
                table: "Walks");
        }
    }
}

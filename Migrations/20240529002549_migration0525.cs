using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ElectronicHealthProfile.Migrations
{
    /// <inheritdoc />
    public partial class migration0525 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "LabResultSets",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "LabResultSets");
        }
    }
}

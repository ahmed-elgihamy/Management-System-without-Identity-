using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Management_System1.Migrations
{
    /// <inheritdoc />
    public partial class deletegrade : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Grade",
                table: "Trainees");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Grade",
                table: "Trainees",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyProject.Server.Migrations
{
    public partial class aa : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AssessmentJson",
                table: "Assessments",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AssessmentJson",
                table: "Assessments");
        }
    }
}

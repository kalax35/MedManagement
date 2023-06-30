using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MedManagement.Data.Migrations
{
    /// <inheritdoc />
    public partial class evaluationdesc : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "EvaluationDesctyption",
                table: "Evaluation",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "EvaluationDesctyption",
                table: "Evaluation",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }
    }
}

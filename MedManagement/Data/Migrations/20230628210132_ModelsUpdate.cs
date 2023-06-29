using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MedManagement.Data.Migrations
{
    /// <inheritdoc />
    public partial class ModelsUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.CreateTable(
                name: "DoctorMedicalFacility",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                                            .Annotation("SqlServer:Identity", "1, 1"),
                    DoctorId = table.Column<int>(type: "int", nullable: false),
                    MedicalFacilityId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DoctorMedicalFacility", x => x.ID);
                    table.ForeignKey(
                        name: "FK_DoctorMedicalFacility_Doctor_DoctorId",
                        column: x => x.DoctorId,
                        principalTable: "Doctor",
                        principalColumn: "DoctorID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DoctorMedicalFacility_MedicalFacility_MedicalFacilityId",
                        column: x => x.MedicalFacilityId,
                        principalTable: "MedicalFacility",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}

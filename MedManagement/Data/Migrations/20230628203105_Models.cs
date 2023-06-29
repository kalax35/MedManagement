using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MedManagement.Data.Migrations
{
    /// <inheritdoc />
    public partial class Models : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MedicalFacility",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Street = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PostalCode = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicalFacility", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Patient",
                columns: table => new
                {
                    PatientID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PatientName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PatientSurname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PatientAge = table.Column<int>(type: "int", nullable: false),
                    PatientType = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Patient", x => x.PatientID);
                });

            migrationBuilder.CreateTable(
                name: "Doctor",
                columns: table => new
                {
                    DoctorID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DoctorName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DoctorSurname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DoctorPhoto = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DoctorMedicalSpecialization = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DoctorAboutMe = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DoctorPhone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MedicalFacilityId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Doctor", x => x.DoctorID);
                    table.ForeignKey(
                        name: "FK_Doctor_MedicalFacility_MedicalFacilityId",
                        column: x => x.MedicalFacilityId,
                        principalTable: "MedicalFacility",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "DiseasesTreated",
                columns: table => new
                {
                    DiseasesTreatedID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DoctorId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DiseasesTreated", x => x.DiseasesTreatedID);
                    table.ForeignKey(
                        name: "FK_DiseasesTreated_Doctor_DoctorId",
                        column: x => x.DoctorId,
                        principalTable: "Doctor",
                        principalColumn: "DoctorID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DoctorMedicalFacility",
                columns: table => new
                {
                    ID = table.Column<string>(type: "nvarchar(450)", nullable: false),
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

            migrationBuilder.CreateTable(
                name: "Evaluation",
                columns: table => new
                {
                    EvaluationID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EvaluationValue = table.Column<int>(type: "int", nullable: false),
                    EvaluationDesctyption = table.Column<int>(type: "int", nullable: false),
                    DoctorId = table.Column<int>(type: "int", nullable: false),
                    PatientId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Evaluation", x => x.EvaluationID);
                    table.ForeignKey(
                        name: "FK_Evaluation_Doctor_DoctorId",
                        column: x => x.DoctorId,
                        principalTable: "Doctor",
                        principalColumn: "DoctorID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Evaluation_Patient_PatientId",
                        column: x => x.PatientId,
                        principalTable: "Patient",
                        principalColumn: "PatientID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Service",
                columns: table => new
                {
                    ServiceID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ServiceName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ServiceDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ServicePrice = table.Column<double>(type: "float", nullable: false),
                    DoctorId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Service", x => x.ServiceID);
                    table.ForeignKey(
                        name: "FK_Service_Doctor_DoctorId",
                        column: x => x.DoctorId,
                        principalTable: "Doctor",
                        principalColumn: "DoctorID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Terms",
                columns: table => new
                {
                    TermsID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsBusy = table.Column<bool>(type: "bit", nullable: false),
                    MedicalFacilityId = table.Column<int>(type: "int", nullable: false),
                    DoctorId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Terms", x => x.TermsID);
                    table.ForeignKey(
                        name: "FK_Terms_Doctor_DoctorId",
                        column: x => x.DoctorId,
                        principalTable: "Doctor",
                        principalColumn: "DoctorID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Terms_MedicalFacility_MedicalFacilityId",
                        column: x => x.MedicalFacilityId,
                        principalTable: "MedicalFacility",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DiseasesTreated_DoctorId",
                table: "DiseasesTreated",
                column: "DoctorId");

            migrationBuilder.CreateIndex(
                name: "IX_Doctor_MedicalFacilityId",
                table: "Doctor",
                column: "MedicalFacilityId");

            migrationBuilder.CreateIndex(
                name: "IX_DoctorMedicalFacility_DoctorId",
                table: "DoctorMedicalFacility",
                column: "DoctorId");

            migrationBuilder.CreateIndex(
                name: "IX_DoctorMedicalFacility_MedicalFacilityId",
                table: "DoctorMedicalFacility",
                column: "MedicalFacilityId");

            migrationBuilder.CreateIndex(
                name: "IX_Evaluation_DoctorId",
                table: "Evaluation",
                column: "DoctorId");

            migrationBuilder.CreateIndex(
                name: "IX_Evaluation_PatientId",
                table: "Evaluation",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_Service_DoctorId",
                table: "Service",
                column: "DoctorId");

            migrationBuilder.CreateIndex(
                name: "IX_Terms_DoctorId",
                table: "Terms",
                column: "DoctorId");

            migrationBuilder.CreateIndex(
                name: "IX_Terms_MedicalFacilityId",
                table: "Terms",
                column: "MedicalFacilityId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DiseasesTreated");

            migrationBuilder.DropTable(
                name: "DoctorMedicalFacility");

            migrationBuilder.DropTable(
                name: "Evaluation");

            migrationBuilder.DropTable(
                name: "Service");

            migrationBuilder.DropTable(
                name: "Terms");

            migrationBuilder.DropTable(
                name: "Patient");

            migrationBuilder.DropTable(
                name: "Doctor");

            migrationBuilder.DropTable(
                name: "MedicalFacility");
        }
    }
}

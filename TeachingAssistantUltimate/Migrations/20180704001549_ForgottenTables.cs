using Microsoft.EntityFrameworkCore.Migrations;

namespace TeachingAssistantUltimate.Migrations
{
    public partial class ForgottenTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AssessmentTypes",
                columns: new[] { "AssessmentTypesID", "AssessmentType", "Total" },
                values: new object[] { 1, "Quiz", 10.0 });

            migrationBuilder.InsertData(
                table: "AssessmentTypes",
                columns: new[] { "AssessmentTypesID", "AssessmentType", "Total" },
                values: new object[] { 2, "Assignment", 10.0 });

            migrationBuilder.InsertData(
                table: "AssessmentTypes",
                columns: new[] { "AssessmentTypesID", "AssessmentType", "Total" },
                values: new object[] { 3, "Mid-Sem", 20.0 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AssessmentTypes",
                keyColumn: "AssessmentTypesID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "AssessmentTypes",
                keyColumn: "AssessmentTypesID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "AssessmentTypes",
                keyColumn: "AssessmentTypesID",
                keyValue: 3);
        }
    }
}

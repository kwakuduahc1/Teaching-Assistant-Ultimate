using Microsoft.EntityFrameworkCore.Migrations;

namespace TeachingAssistantUltimate.Migrations
{
    public partial class Results : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "SubjectCode",
                table: "Subjects",
                maxLength: 10,
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "AssessmentTypes",
                columns: table => new
                {
                    AssessmentTypesID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    AssessmentType = table.Column<string>(maxLength: 15, nullable: false),
                    Total = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AssessmentTypes", x => x.AssessmentTypesID);
                });

            migrationBuilder.CreateTable(
                name: "Classes",
                columns: table => new
                {
                    ClassesID = table.Column<byte>(nullable: false),
                    Name = table.Column<string>(maxLength: 10, nullable: false),
                    IndexPrefix = table.Column<string>(maxLength: 20, nullable: false),
                    Concurrency = table.Column<byte>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Classes", x => x.ClassesID);
                });

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    StudentsID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(maxLength: 100, nullable: false),
                    IndexNumber = table.Column<string>(nullable: false),
                    ClassesID = table.Column<int>(nullable: false),
                    ClassesID1 = table.Column<byte>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.StudentsID);
                    table.ForeignKey(
                        name: "FK_Students_Classes_ClassesID1",
                        column: x => x.ClassesID1,
                        principalTable: "Classes",
                        principalColumn: "ClassesID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Results",
                columns: table => new
                {
                    ResultsID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    StudentsID = table.Column<int>(nullable: false),
                    SubjectsID = table.Column<int>(nullable: false),
                    AssessmentTypesID = table.Column<byte>(nullable: false),
                    Score = table.Column<double>(nullable: false),
                    TotalScore = table.Column<double>(nullable: false),
                    AssessmentTypesID1 = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Results", x => x.ResultsID);
                    table.ForeignKey(
                        name: "FK_Results_AssessmentTypes_AssessmentTypesID1",
                        column: x => x.AssessmentTypesID1,
                        principalTable: "AssessmentTypes",
                        principalColumn: "AssessmentTypesID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Results_Students_StudentsID",
                        column: x => x.StudentsID,
                        principalTable: "Students",
                        principalColumn: "StudentsID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Results_Subjects_SubjectsID",
                        column: x => x.SubjectsID,
                        principalTable: "Subjects",
                        principalColumn: "SubjectsID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "Subjects",
                keyColumn: "SubjectsID",
                keyValue: 1,
                columns: new[] { "Concurrency", "SubjectCode" },
                values: new object[] { null, "001" });

            migrationBuilder.UpdateData(
                table: "Subjects",
                keyColumn: "SubjectsID",
                keyValue: 2,
                columns: new[] { "Concurrency", "SubjectCode" },
                values: new object[] { null, "002" });

            migrationBuilder.CreateIndex(
                name: "IX_Results_AssessmentTypesID1",
                table: "Results",
                column: "AssessmentTypesID1");

            migrationBuilder.CreateIndex(
                name: "IX_Results_StudentsID",
                table: "Results",
                column: "StudentsID");

            migrationBuilder.CreateIndex(
                name: "IX_Results_SubjectsID",
                table: "Results",
                column: "SubjectsID");

            migrationBuilder.CreateIndex(
                name: "IX_Students_ClassesID1",
                table: "Students",
                column: "ClassesID1");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Results");

            migrationBuilder.DropTable(
                name: "AssessmentTypes");

            migrationBuilder.DropTable(
                name: "Students");

            migrationBuilder.DropTable(
                name: "Classes");

            migrationBuilder.DropColumn(
                name: "SubjectCode",
                table: "Subjects");
        }
    }
}

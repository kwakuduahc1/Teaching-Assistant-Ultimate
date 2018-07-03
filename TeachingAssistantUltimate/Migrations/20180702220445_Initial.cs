using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TeachingAssistantUltimate.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Subjects",
                columns: table => new
                {
                    SubjectsID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Subject = table.Column<string>(maxLength: 250, nullable: false),
                    Concurrency = table.Column<byte[]>(rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subjects", x => x.SubjectsID);
                });

            migrationBuilder.CreateTable(
                name: "Questions",
                columns: table => new
                {
                    QuestionsID = table.Column<Guid>(nullable: false),
                    Question = table.Column<string>(maxLength: 2147483647, nullable: false),
                    Topic = table.Column<string>(maxLength: 200, nullable: false),
                    SubjectsID = table.Column<int>(nullable: false),
                    DateAdded = table.Column<DateTime>(nullable: false),
                    Concurrency = table.Column<byte[]>(rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Questions", x => x.QuestionsID);
                    table.ForeignKey(
                        name: "FK_Questions_Subjects_SubjectsID",
                        column: x => x.SubjectsID,
                        principalTable: "Subjects",
                        principalColumn: "SubjectsID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Options",
                columns: table => new
                {
                    OptionsID = table.Column<Guid>(nullable: false),
                    Option = table.Column<string>(maxLength: 250, nullable: false),
                    QuestionsID = table.Column<Guid>(nullable: false),
                    IsAnswer = table.Column<bool>(nullable: false),
                    Concurrency = table.Column<byte[]>(rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Options", x => x.OptionsID);
                    table.ForeignKey(
                        name: "FK_Options_Questions_QuestionsID",
                        column: x => x.QuestionsID,
                        principalTable: "Questions",
                        principalColumn: "QuestionsID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Subjects",
                columns: new[] { "SubjectsID", "Concurrency", "Subject" },
                values: new object[] { 1, null, "Public Health Nursing" });

            migrationBuilder.InsertData(
                table: "Subjects",
                columns: new[] { "SubjectsID", "Concurrency", "Subject" },
                values: new object[] { 2, null, "Basic Infection Prevention and Control" });

            migrationBuilder.CreateIndex(
                name: "IX_Options_QuestionsID",
                table: "Options",
                column: "QuestionsID");

            migrationBuilder.CreateIndex(
                name: "IX_Questions_SubjectsID",
                table: "Questions",
                column: "SubjectsID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Options");

            migrationBuilder.DropTable(
                name: "Questions");

            migrationBuilder.DropTable(
                name: "Subjects");
        }
    }
}

using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace CoursWork.Migrations
{
    public partial class someEntyties : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "ResultPercent",
                table: "UserCourses",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.CreateTable(
                name: "Modules",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CourceId = table.Column<int>(nullable: true),
                    Discription = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Modules", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Modules_Courses_CourceId",
                        column: x => x.CourceId,
                        principalTable: "Courses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Tests",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ModuleId = table.Column<int>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Question = table.Column<string>(nullable: true),
                    StepNumber = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tests", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tests_Modules_ModuleId",
                        column: x => x.ModuleId,
                        principalTable: "Modules",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Theories",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ModuleId = table.Column<int>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    StepNumber = table.Column<int>(nullable: false),
                    Text = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Theories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Theories_Modules_ModuleId",
                        column: x => x.ModuleId,
                        principalTable: "Modules",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TestResulties",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Correct = table.Column<bool>(nullable: false),
                    TestId = table.Column<int>(nullable: true),
                    Variant = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TestResulties", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TestResulties_Tests_TestId",
                        column: x => x.TestId,
                        principalTable: "Tests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UserTheory",
                columns: table => new
                {
                    IdUser = table.Column<int>(nullable: false),
                    IdTheory = table.Column<int>(nullable: false),
                    Finished = table.Column<bool>(nullable: false),
                    TheoryId = table.Column<int>(nullable: true),
                    UserId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserTheory", x => new { x.IdUser, x.IdTheory });
                    table.ForeignKey(
                        name: "FK_UserTheory_Theories_TheoryId",
                        column: x => x.TheoryId,
                        principalTable: "Theories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserTheory_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UserTestResulties",
                columns: table => new
                {
                    IdUser = table.Column<int>(nullable: false),
                    IdTestResults = table.Column<int>(nullable: false),
                    Finished = table.Column<bool>(nullable: false),
                    TestResultsId = table.Column<int>(nullable: true),
                    UserId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserTestResulties", x => new { x.IdUser, x.IdTestResults });
                    table.ForeignKey(
                        name: "FK_UserTestResulties_TestResulties_TestResultsId",
                        column: x => x.TestResultsId,
                        principalTable: "TestResulties",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserTestResulties_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Modules_CourceId",
                table: "Modules",
                column: "CourceId");

            migrationBuilder.CreateIndex(
                name: "IX_TestResulties_TestId",
                table: "TestResulties",
                column: "TestId");

            migrationBuilder.CreateIndex(
                name: "IX_Tests_ModuleId",
                table: "Tests",
                column: "ModuleId");

            migrationBuilder.CreateIndex(
                name: "IX_Theories_ModuleId",
                table: "Theories",
                column: "ModuleId");

            migrationBuilder.CreateIndex(
                name: "IX_UserTestResulties_TestResultsId",
                table: "UserTestResulties",
                column: "TestResultsId");

            migrationBuilder.CreateIndex(
                name: "IX_UserTestResulties_UserId",
                table: "UserTestResulties",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserTheory_TheoryId",
                table: "UserTheory",
                column: "TheoryId");

            migrationBuilder.CreateIndex(
                name: "IX_UserTheory_UserId",
                table: "UserTheory",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserTestResulties");

            migrationBuilder.DropTable(
                name: "UserTheory");

            migrationBuilder.DropTable(
                name: "TestResulties");

            migrationBuilder.DropTable(
                name: "Theories");

            migrationBuilder.DropTable(
                name: "Tests");

            migrationBuilder.DropTable(
                name: "Modules");

            migrationBuilder.DropColumn(
                name: "ResultPercent",
                table: "UserCourses");
        }
    }
}

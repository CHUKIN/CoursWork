using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace CoursWork.Migrations
{
    public partial class changeTestResults : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_UserTestResulties",
                table: "UserTestResulties");

            migrationBuilder.AddColumn<int>(
                name: "IdTest",
                table: "UserTestResulties",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TestId",
                table: "UserTestResulties",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserTestResulties",
                table: "UserTestResulties",
                columns: new[] { "IdUser", "IdTestResults", "IdTest" });

            migrationBuilder.CreateIndex(
                name: "IX_UserTestResulties_TestId",
                table: "UserTestResulties",
                column: "TestId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserTestResulties_Tests_TestId",
                table: "UserTestResulties",
                column: "TestId",
                principalTable: "Tests",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserTestResulties_Tests_TestId",
                table: "UserTestResulties");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserTestResulties",
                table: "UserTestResulties");

            migrationBuilder.DropIndex(
                name: "IX_UserTestResulties_TestId",
                table: "UserTestResulties");

            migrationBuilder.DropColumn(
                name: "IdTest",
                table: "UserTestResulties");

            migrationBuilder.DropColumn(
                name: "TestId",
                table: "UserTestResulties");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserTestResulties",
                table: "UserTestResulties",
                columns: new[] { "IdUser", "IdTestResults" });
        }
    }
}

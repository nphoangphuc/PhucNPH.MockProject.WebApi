using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PhucNPH.MockProject.Repository.Migrations
{
    public partial class add_seed_data : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "Id", "Deleted", "DepartmentLocation", "DepartmentName" },
                values: new object[] { new Guid("b1028c84-b929-46de-afc1-157af578ef05"), false, "HEAD_OFFICE", "ADMIN_GROUP" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: new Guid("b1028c84-b929-46de-afc1-157af578ef05"));
        }
    }
}

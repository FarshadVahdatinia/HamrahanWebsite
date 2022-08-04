using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HamrahanTemplate.persistence.Migrations
{
    public partial class addingdateOfRegisterToPerson : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "RegisterDate",
                table: "Users",
                type: "datetime2",
                nullable: false,
                computedColumnSql: "(getdate())",
                stored: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RegisterDate",
                table: "Users");
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ContactInfo",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "VARCHAR (36)", nullable: false),
                    FirstName = table.Column<string>(type: "VARCHAR", nullable: false),
                    LastName = table.Column<string>(type: "VARCHAR", nullable: false),
                    EmployeeRegistrationNumber = table.Column<int>(type: "INT", nullable: false),
                    Department = table.Column<string>(type: "VARCHAR", nullable: false),
                    Location = table.Column<string>(type: "VARCHAR", nullable: false),
                    Position = table.Column<int>(type: "VARCHAR", nullable: false),
                    WorkPhoneNumber = table.Column<string>(type: "VARCHAR", nullable: false),
                    OtherWorkPhoneNumber = table.Column<string>(type: "VARCHAR", nullable: false),
                    CorporatePhoneNumber = table.Column<string>(type: "VARCHAR", nullable: false),
                    Email = table.Column<string>(type: "VARCHAR", nullable: false),
                    InsertedDate = table.Column<DateTime>(type: "DATETIME", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "DATETIME", nullable: false),
                    IsDeleted = table.Column<bool>(type: "BOOLEAN", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContactInfo", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ContactInfo");
        }
    }
}

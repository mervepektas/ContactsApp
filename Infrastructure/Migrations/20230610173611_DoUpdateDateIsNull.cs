using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class DoUpdateDateIsNull : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "ContactInfo",
                type: "DATETIME",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "DATETIME")
                .Annotation("Relational:ColumnOrder", 14);

            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                table: "ContactInfo",
                type: "BOOLEAN",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "BOOLEAN")
                .Annotation("Relational:ColumnOrder", 15);

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertedDate",
                table: "ContactInfo",
                type: "DATETIME",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "DATETIME")
                .Annotation("Relational:ColumnOrder", 14);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "ContactInfo",
                type: "DATETIME",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "DATETIME",
                oldNullable: true)
                .OldAnnotation("Relational:ColumnOrder", 14);

            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                table: "ContactInfo",
                type: "BOOLEAN",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "BOOLEAN")
                .OldAnnotation("Relational:ColumnOrder", 15);

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertedDate",
                table: "ContactInfo",
                type: "DATETIME",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "DATETIME")
                .OldAnnotation("Relational:ColumnOrder", 14);
        }
    }
}

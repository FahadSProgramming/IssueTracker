using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IT.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class UserRequestsTableFieldUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsManager",
                table: "SystemUserRequests",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AlterColumn<DateTime>(
                name: "StartedOn",
                table: "Projects",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2023, 11, 27, 21, 58, 38, 625, DateTimeKind.Utc).AddTicks(4285),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2023, 11, 27, 21, 45, 50, 843, DateTimeKind.Utc).AddTicks(8892));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ReportedOn",
                table: "Incidents",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2023, 11, 27, 21, 58, 38, 624, DateTimeKind.Utc).AddTicks(7024),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2023, 11, 27, 21, 45, 50, 843, DateTimeKind.Utc).AddTicks(282));

            migrationBuilder.AlterColumn<DateTime>(
                name: "SigningDate",
                table: "Customers",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2023, 11, 27, 21, 58, 38, 624, DateTimeKind.Utc).AddTicks(3833),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2023, 11, 27, 21, 45, 50, 842, DateTimeKind.Utc).AddTicks(6608));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsManager",
                table: "SystemUserRequests");

            migrationBuilder.AlterColumn<DateTime>(
                name: "StartedOn",
                table: "Projects",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2023, 11, 27, 21, 45, 50, 843, DateTimeKind.Utc).AddTicks(8892),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2023, 11, 27, 21, 58, 38, 625, DateTimeKind.Utc).AddTicks(4285));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ReportedOn",
                table: "Incidents",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2023, 11, 27, 21, 45, 50, 843, DateTimeKind.Utc).AddTicks(282),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2023, 11, 27, 21, 58, 38, 624, DateTimeKind.Utc).AddTicks(7024));

            migrationBuilder.AlterColumn<DateTime>(
                name: "SigningDate",
                table: "Customers",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2023, 11, 27, 21, 45, 50, 842, DateTimeKind.Utc).AddTicks(6608),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2023, 11, 27, 21, 58, 38, 624, DateTimeKind.Utc).AddTicks(3833));
        }
    }
}

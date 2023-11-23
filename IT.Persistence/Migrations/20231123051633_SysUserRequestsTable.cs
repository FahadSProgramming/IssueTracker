using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IT.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class SysUserRequestsTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "StartedOn",
                table: "Projects",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2023, 11, 23, 5, 16, 32, 726, DateTimeKind.Utc).AddTicks(7016),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2023, 11, 21, 17, 24, 42, 499, DateTimeKind.Utc).AddTicks(1390));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ReportedOn",
                table: "Incidents",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2023, 11, 23, 5, 16, 32, 725, DateTimeKind.Utc).AddTicks(9811),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2023, 11, 21, 17, 24, 42, 498, DateTimeKind.Utc).AddTicks(4775));

            migrationBuilder.AlterColumn<DateTime>(
                name: "SigningDate",
                table: "Customers",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2023, 11, 23, 5, 16, 32, 725, DateTimeKind.Utc).AddTicks(6593),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2023, 11, 21, 17, 24, 42, 498, DateTimeKind.Utc).AddTicks(1672));

            migrationBuilder.AddColumn<Guid>(
                name: "SystemUserId",
                table: "Contacts",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "DisplayName",
                table: "AspNetUsers",
                type: "TEXT",
                maxLength: 300,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "ContactId",
                table: "AspNetUsers",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Enabled",
                table: "AspNetUsers",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<Guid>(
                name: "SystemUserRequestId",
                table: "AspNetUsers",
                type: "TEXT",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "SystemUserRequest",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    DisplayName = table.Column<string>(type: "TEXT", maxLength: 300, nullable: false),
                    Email = table.Column<string>(type: "TEXT", maxLength: 250, nullable: false),
                    Position = table.Column<string>(type: "TEXT", maxLength: 100, nullable: true),
                    PhoneNumber = table.Column<string>(type: "TEXT", nullable: true),
                    Description = table.Column<string>(type: "TEXT", maxLength: 500, nullable: true),
                    Status = table.Column<int>(type: "INTEGER", nullable: false),
                    RequestorId = table.Column<Guid>(type: "TEXT", nullable: false),
                    CustomerId = table.Column<Guid>(type: "TEXT", nullable: false),
                    SystemUserId = table.Column<Guid>(type: "TEXT", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "TEXT", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "TEXT", nullable: false),
                    IsActive = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SystemUserRequest", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SystemUserRequest_Contacts_RequestorId",
                        column: x => x.RequestorId,
                        principalTable: "Contacts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SystemUserRequest_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_ContactId",
                table: "AspNetUsers",
                column: "ContactId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_SystemUserRequestId",
                table: "AspNetUsers",
                column: "SystemUserRequestId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_SystemUserRequest_CustomerId",
                table: "SystemUserRequest",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_SystemUserRequest_RequestorId",
                table: "SystemUserRequest",
                column: "RequestorId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Contacts_ContactId",
                table: "AspNetUsers",
                column: "ContactId",
                principalTable: "Contacts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_SystemUserRequest_SystemUserRequestId",
                table: "AspNetUsers",
                column: "SystemUserRequestId",
                principalTable: "SystemUserRequest",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Contacts_ContactId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_SystemUserRequest_SystemUserRequestId",
                table: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "SystemUserRequest");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_ContactId",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_SystemUserRequestId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "SystemUserId",
                table: "Contacts");

            migrationBuilder.DropColumn(
                name: "ContactId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Enabled",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "SystemUserRequestId",
                table: "AspNetUsers");

            migrationBuilder.AlterColumn<DateTime>(
                name: "StartedOn",
                table: "Projects",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2023, 11, 21, 17, 24, 42, 499, DateTimeKind.Utc).AddTicks(1390),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2023, 11, 23, 5, 16, 32, 726, DateTimeKind.Utc).AddTicks(7016));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ReportedOn",
                table: "Incidents",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2023, 11, 21, 17, 24, 42, 498, DateTimeKind.Utc).AddTicks(4775),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2023, 11, 23, 5, 16, 32, 725, DateTimeKind.Utc).AddTicks(9811));

            migrationBuilder.AlterColumn<DateTime>(
                name: "SigningDate",
                table: "Customers",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2023, 11, 21, 17, 24, 42, 498, DateTimeKind.Utc).AddTicks(1672),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2023, 11, 23, 5, 16, 32, 725, DateTimeKind.Utc).AddTicks(6593));

            migrationBuilder.AlterColumn<string>(
                name: "DisplayName",
                table: "AspNetUsers",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldMaxLength: 300);
        }
    }
}

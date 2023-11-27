using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IT.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class UserRequestsTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_SystemUserRequest_SystemUserRequestId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_SystemUserRequest_Contacts_RequestorId",
                table: "SystemUserRequest");

            migrationBuilder.DropForeignKey(
                name: "FK_SystemUserRequest_Customers_CustomerId",
                table: "SystemUserRequest");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SystemUserRequest",
                table: "SystemUserRequest");

            migrationBuilder.RenameTable(
                name: "SystemUserRequest",
                newName: "SystemUserRequests");

            migrationBuilder.RenameIndex(
                name: "IX_SystemUserRequest_RequestorId",
                table: "SystemUserRequests",
                newName: "IX_SystemUserRequests_RequestorId");

            migrationBuilder.RenameIndex(
                name: "IX_SystemUserRequest_CustomerId",
                table: "SystemUserRequests",
                newName: "IX_SystemUserRequests_CustomerId");

            migrationBuilder.AlterColumn<DateTime>(
                name: "StartedOn",
                table: "Projects",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2023, 11, 27, 21, 45, 50, 843, DateTimeKind.Utc).AddTicks(8892),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2023, 11, 23, 5, 16, 32, 726, DateTimeKind.Utc).AddTicks(7016));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ReportedOn",
                table: "Incidents",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2023, 11, 27, 21, 45, 50, 843, DateTimeKind.Utc).AddTicks(282),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2023, 11, 23, 5, 16, 32, 725, DateTimeKind.Utc).AddTicks(9811));

            migrationBuilder.AlterColumn<DateTime>(
                name: "SigningDate",
                table: "Customers",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2023, 11, 27, 21, 45, 50, 842, DateTimeKind.Utc).AddTicks(6608),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2023, 11, 23, 5, 16, 32, 725, DateTimeKind.Utc).AddTicks(6593));

            migrationBuilder.AddPrimaryKey(
                name: "PK_SystemUserRequests",
                table: "SystemUserRequests",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_SystemUserRequests_SystemUserRequestId",
                table: "AspNetUsers",
                column: "SystemUserRequestId",
                principalTable: "SystemUserRequests",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SystemUserRequests_Contacts_RequestorId",
                table: "SystemUserRequests",
                column: "RequestorId",
                principalTable: "Contacts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SystemUserRequests_Customers_CustomerId",
                table: "SystemUserRequests",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_SystemUserRequests_SystemUserRequestId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_SystemUserRequests_Contacts_RequestorId",
                table: "SystemUserRequests");

            migrationBuilder.DropForeignKey(
                name: "FK_SystemUserRequests_Customers_CustomerId",
                table: "SystemUserRequests");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SystemUserRequests",
                table: "SystemUserRequests");

            migrationBuilder.RenameTable(
                name: "SystemUserRequests",
                newName: "SystemUserRequest");

            migrationBuilder.RenameIndex(
                name: "IX_SystemUserRequests_RequestorId",
                table: "SystemUserRequest",
                newName: "IX_SystemUserRequest_RequestorId");

            migrationBuilder.RenameIndex(
                name: "IX_SystemUserRequests_CustomerId",
                table: "SystemUserRequest",
                newName: "IX_SystemUserRequest_CustomerId");

            migrationBuilder.AlterColumn<DateTime>(
                name: "StartedOn",
                table: "Projects",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2023, 11, 23, 5, 16, 32, 726, DateTimeKind.Utc).AddTicks(7016),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2023, 11, 27, 21, 45, 50, 843, DateTimeKind.Utc).AddTicks(8892));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ReportedOn",
                table: "Incidents",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2023, 11, 23, 5, 16, 32, 725, DateTimeKind.Utc).AddTicks(9811),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2023, 11, 27, 21, 45, 50, 843, DateTimeKind.Utc).AddTicks(282));

            migrationBuilder.AlterColumn<DateTime>(
                name: "SigningDate",
                table: "Customers",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2023, 11, 23, 5, 16, 32, 725, DateTimeKind.Utc).AddTicks(6593),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2023, 11, 27, 21, 45, 50, 842, DateTimeKind.Utc).AddTicks(6608));

            migrationBuilder.AddPrimaryKey(
                name: "PK_SystemUserRequest",
                table: "SystemUserRequest",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_SystemUserRequest_SystemUserRequestId",
                table: "AspNetUsers",
                column: "SystemUserRequestId",
                principalTable: "SystemUserRequest",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SystemUserRequest_Contacts_RequestorId",
                table: "SystemUserRequest",
                column: "RequestorId",
                principalTable: "Contacts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SystemUserRequest_Customers_CustomerId",
                table: "SystemUserRequest",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

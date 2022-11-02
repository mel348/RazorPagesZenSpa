using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RazorPages.Migrations
{
    public partial class ClientAndAnnotations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clients",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(name: "First Name", nullable: false),
                    LastName = table.Column<string>(name: "Last Name", nullable: false),
                    Address = table.Column<string>(nullable: true),
                    City = table.Column<string>(nullable: true),
                    State = table.Column<string>(nullable: true),
                    Zipcode = table.Column<string>(nullable: true),
                    Country = table.Column<string>(nullable: true),
                    Phone = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: false),
                    Username = table.Column<string>(nullable: false),
                    Password = table.Column<string>(nullable: false),
                    ConfirmPassword = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clients", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "ClientServices",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClientID = table.Column<int>(nullable: false),
                    ServicesID = table.Column<int>(nullable: false),
                    Date = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClientServices", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ClientServices_Clients_ClientID",
                        column: x => x.ClientID,
                        principalTable: "Clients",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ClientServices_Services_ServicesID",
                        column: x => x.ServicesID,
                        principalTable: "Services",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Clients",
                columns: new[] { "ID", "Address", "City", "ConfirmPassword", "Country", "Email", "First Name", "Last Name", "Password", "Phone", "Zipcode", "State", "Username" },
                values: new object[,]
                {
                    { 1, null, null, null, null, "flo@schmoe.net", "Flo", "Schmoe", "FloSchmoe1234*", null, null, null, "Flo" },
                    { 2, null, null, null, null, "jojo@schmoe.net", "Jo", "Schmoe", "JoJoSchmoe1234?", null, null, null, "JoJo" },
                    { 3, null, null, null, null, "truly@schmoe.net", "Truly", "Schmoe", "Truly9876**", null, null, null, "Truly" }
                });

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "ID",
                keyValue: 6,
                column: "Classification",
                value: "Cut");

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "ID",
                keyValue: 7,
                column: "Classification",
                value: "Color");

            migrationBuilder.InsertData(
                table: "ClientServices",
                columns: new[] { "ID", "ClientID", "Date", "ServicesID" },
                values: new object[] { 1, 1, new DateTime(2022, 11, 1, 23, 52, 42, 19, DateTimeKind.Local).AddTicks(7827), 1 });

            migrationBuilder.InsertData(
                table: "ClientServices",
                columns: new[] { "ID", "ClientID", "Date", "ServicesID" },
                values: new object[] { 3, 1, new DateTime(2022, 11, 1, 23, 52, 42, 23, DateTimeKind.Local).AddTicks(9238), 5 });

            migrationBuilder.InsertData(
                table: "ClientServices",
                columns: new[] { "ID", "ClientID", "Date", "ServicesID" },
                values: new object[] { 2, 2, new DateTime(2022, 11, 1, 23, 52, 42, 23, DateTimeKind.Local).AddTicks(9156), 7 });

            migrationBuilder.CreateIndex(
                name: "IX_ClientServices_ClientID",
                table: "ClientServices",
                column: "ClientID");

            migrationBuilder.CreateIndex(
                name: "IX_ClientServices_ServicesID",
                table: "ClientServices",
                column: "ServicesID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ClientServices");

            migrationBuilder.DropTable(
                name: "Clients");

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "ID",
                keyValue: 6,
                column: "Classification",
                value: "Salon");

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "ID",
                keyValue: 7,
                column: "Classification",
                value: "Salon");
        }
    }
}

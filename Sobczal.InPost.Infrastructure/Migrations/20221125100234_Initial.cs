using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Sobczal.InPost.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Boxes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Address = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Boxes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "InPostUser",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    Username = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InPostUser", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Packages",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    SentAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ReceivedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    SourceId = table.Column<Guid>(type: "uuid", nullable: false),
                    DestinationId = table.Column<Guid>(type: "uuid", nullable: false),
                    FromId = table.Column<string>(type: "text", nullable: false),
                    ToId = table.Column<string>(type: "text", nullable: false),
                    CanBePickedUp = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Packages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Packages_Boxes_DestinationId",
                        column: x => x.DestinationId,
                        principalTable: "Boxes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Packages_Boxes_SourceId",
                        column: x => x.SourceId,
                        principalTable: "Boxes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Packages_InPostUser_FromId",
                        column: x => x.FromId,
                        principalTable: "InPostUser",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Packages_InPostUser_ToId",
                        column: x => x.ToId,
                        principalTable: "InPostUser",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "PackageStep",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    PackageId = table.Column<Guid>(type: "uuid", nullable: false),
                    Type = table.Column<int>(type: "integer", nullable: false),
                    At = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PackageStep", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PackageStep_Packages_PackageId",
                        column: x => x.PackageId,
                        principalTable: "Packages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Boxes",
                columns: new[] { "Id", "Address", "Name" },
                values: new object[,]
                {
                    { new Guid("0cd04aae-0ca0-4f95-82d1-6502990f188d"), "ul. Zabraniceka 20 / Rzeczna 20, 03-872 Warszawa", "WAW08N" },
                    { new Guid("262a4d59-9c9c-41e3-a184-6ae04233b591"), "ul. Popiełuszki 17b, 01-711 Warszawa", "WAW92N" },
                    { new Guid("3028e3f0-5abf-49c6-a785-3b7e88da9157"), "ul. Mińska 69/U-5, 03-828 Warszawa", "WAW44H" },
                    { new Guid("47f3a1ec-339a-43fe-b75d-4a3d7648da48"), "ul. Wincentego 4, 03-505 Warszawa", "WAW15A" },
                    { new Guid("48f73e4f-2c3d-4c0b-8497-25f3d8bc134e"), "ul. Jagiellońska 82B, 03-301 Warszawa", "WAW465M" },
                    { new Guid("4e7ec03b-c86f-4fdf-926c-315be006baa7"), "ul. Lidzka 5, 03-523 Warszawa", "WAW431M" },
                    { new Guid("4f1247b1-0999-498c-aa85-5e6069bc7979"), "ul. Żupnicza 15, 03-821 Warszawa", "WAW642M" },
                    { new Guid("68af2be2-f33e-4076-b14f-7078efc209ea"), "ul. Kochanowskiego 10A, 01-716 Warszawa", "WAW18M" },
                    { new Guid("6e5b022d-4b53-4307-aa0a-065cfe7c8b98"), "ul. Pabla Nerudy 1, 01-926 Warszawa", "WAW395M" },
                    { new Guid("79bc1380-cbea-48b6-ad11-b0c4c54209d4"), "ul. Birżanska 1, 03-780 Warszawa", "WAW130AP" },
                    { new Guid("89281263-3449-473e-8ec6-051c4d382668"), "ul. Broniewskiego 26, 01-771 Warszawa", "WAW87AP" },
                    { new Guid("9f9a866c-5b4d-4ff3-9cc6-9f33933e7786"), "ul. Przeworska 7, 04-382 Warszawa", "WAW15H" },
                    { new Guid("a2c83514-272c-4786-93dc-a951d975caf6"), "ul. Jagiellońska 7, 03-721 Warszawa", "WAW333M" },
                    { new Guid("a34ba07d-5c67-4fa1-abb7-b9033d0971af"), "ul. Kickiego 21 A, 04-390 Warszawa", "WAW343M" },
                    { new Guid("b3799b43-a034-45a3-b2a8-edc5dfa97a41"), "ul. Jagiellońska 57/5, 03-301 Warszawa", "WAW30B" },
                    { new Guid("b803486b-f56f-4453-9beb-a678f26671f7"), "ul. Kijowska 20, 03-743 Warszawa", "WAW36A" },
                    { new Guid("c1ff144a-7a35-424c-997c-81dee284d516"), "ul. Targowa 24, 03-733 Warszawa", "WAW166M" },
                    { new Guid("c723247d-f28f-4d10-b7af-5a5778cea7f4"), "ul. Josepha Conrada 1, 01-922 Warszawa", "WAW39M" },
                    { new Guid("c9c9444b-5eb5-47ca-839c-fce7abd15d2b"), "ul. Odrowąża 7A, 03-310 Warszawa", "WAW127AP" },
                    { new Guid("e818b676-8937-4cbd-bd01-90fa3b10941b"), "ul. Chrzanowskiego 4, 04-381 Warszawa", "WAW106M" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Packages_DestinationId",
                table: "Packages",
                column: "DestinationId");

            migrationBuilder.CreateIndex(
                name: "IX_Packages_FromId",
                table: "Packages",
                column: "FromId");

            migrationBuilder.CreateIndex(
                name: "IX_Packages_SourceId",
                table: "Packages",
                column: "SourceId");

            migrationBuilder.CreateIndex(
                name: "IX_Packages_ToId",
                table: "Packages",
                column: "ToId");

            migrationBuilder.CreateIndex(
                name: "IX_PackageStep_PackageId",
                table: "PackageStep",
                column: "PackageId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PackageStep");

            migrationBuilder.DropTable(
                name: "Packages");

            migrationBuilder.DropTable(
                name: "Boxes");

            migrationBuilder.DropTable(
                name: "InPostUser");
        }
    }
}

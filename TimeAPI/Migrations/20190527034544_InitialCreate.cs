using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TimeAPI.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clients",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: false),
                    Identifier = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clients", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Matters",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: false),
                    Identifier = table.Column<string>(nullable: false),
                    ClientId = table.Column<int>(nullable: false),
                    ClientId1 = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Matters", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Matters_Clients_ClientId1",
                        column: x => x.ClientId1,
                        principalTable: "Clients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Entries",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    StartTime = table.Column<DateTime>(nullable: false),
                    ElapsedTime = table.Column<double>(nullable: false),
                    Narrative = table.Column<string>(nullable: false),
                    MatterId = table.Column<int>(nullable: false),
                    MatterId1 = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Entries", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Entries_Matters_MatterId1",
                        column: x => x.MatterId1,
                        principalTable: "Matters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Descriptors",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: false),
                    Identifier = table.Column<string>(nullable: false),
                    EntryId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Descriptors", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Descriptors_Entries_EntryId",
                        column: x => x.EntryId,
                        principalTable: "Entries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DescriptorEntries",
                columns: table => new
                {
                    DescriptorId = table.Column<int>(nullable: false),
                    EntryId = table.Column<int>(nullable: false),
                    Id = table.Column<int>(nullable: false),
                    DescriptorId1 = table.Column<long>(nullable: true),
                    EntryId1 = table.Column<long>(nullable: true),
                    MatterId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DescriptorEntries", x => new { x.DescriptorId, x.EntryId });
                    table.ForeignKey(
                        name: "FK_DescriptorEntries_Descriptors_DescriptorId1",
                        column: x => x.DescriptorId1,
                        principalTable: "Descriptors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DescriptorEntries_Entries_EntryId1",
                        column: x => x.EntryId1,
                        principalTable: "Entries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DescriptorEntries_Matters_MatterId",
                        column: x => x.MatterId,
                        principalTable: "Matters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DescriptorEntries_DescriptorId1",
                table: "DescriptorEntries",
                column: "DescriptorId1");

            migrationBuilder.CreateIndex(
                name: "IX_DescriptorEntries_EntryId1",
                table: "DescriptorEntries",
                column: "EntryId1");

            migrationBuilder.CreateIndex(
                name: "IX_DescriptorEntries_MatterId",
                table: "DescriptorEntries",
                column: "MatterId");

            migrationBuilder.CreateIndex(
                name: "IX_Descriptors_EntryId",
                table: "Descriptors",
                column: "EntryId");

            migrationBuilder.CreateIndex(
                name: "IX_Entries_MatterId1",
                table: "Entries",
                column: "MatterId1");

            migrationBuilder.CreateIndex(
                name: "IX_Matters_ClientId1",
                table: "Matters",
                column: "ClientId1");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DescriptorEntries");

            migrationBuilder.DropTable(
                name: "Descriptors");

            migrationBuilder.DropTable(
                name: "Entries");

            migrationBuilder.DropTable(
                name: "Matters");

            migrationBuilder.DropTable(
                name: "Clients");
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HrPLatform.DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CompanyInformations",
                columns: table => new
                {
                    CompanyId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CompanyName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CompanyDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CompanyPhone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CompanyEmail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CompanyWebsite = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CompanyAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CardHoldersName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CardNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SecurityCode = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompanyInformations", x => x.CompanyId);
                });

            migrationBuilder.CreateTable(
                name: "PersonalInformations",
                columns: table => new
                {
                    SSN = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonalInformations", x => x.SSN);
                });

            migrationBuilder.CreateTable(
                name: "HrAutho",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    PassWordHash = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    PassWordSalt = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    CompanyId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HrAutho", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HrAutho_CompanyInformations_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "CompanyInformations",
                        principalColumn: "CompanyId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PersonalCompany",
                columns: table => new
                {
                    SSN = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CompanyId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonalCompany", x => new { x.SSN, x.CompanyId });
                    table.ForeignKey(
                        name: "FK_PersonalCompany_CompanyInformations_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "CompanyInformations",
                        principalColumn: "CompanyId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PersonalCompany_PersonalInformations_SSN",
                        column: x => x.SSN,
                        principalTable: "PersonalInformations",
                        principalColumn: "SSN",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TitleInformations",
                columns: table => new
                {
                    TitleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Team = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Department = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StartDate = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Payment = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SsnPersonal = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CompanyId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TitleInformations", x => x.TitleId);
                    table.ForeignKey(
                        name: "FK_TitleInformations_CompanyInformations_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "CompanyInformations",
                        principalColumn: "CompanyId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TitleInformations_PersonalInformations_SsnPersonal",
                        column: x => x.SsnPersonal,
                        principalTable: "PersonalInformations",
                        principalColumn: "SSN",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_HrAutho_CompanyId",
                table: "HrAutho",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonalCompany_CompanyId",
                table: "PersonalCompany",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_TitleInformations_CompanyId",
                table: "TitleInformations",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_TitleInformations_SsnPersonal",
                table: "TitleInformations",
                column: "SsnPersonal",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HrAutho");

            migrationBuilder.DropTable(
                name: "PersonalCompany");

            migrationBuilder.DropTable(
                name: "TitleInformations");

            migrationBuilder.DropTable(
                name: "CompanyInformations");

            migrationBuilder.DropTable(
                name: "PersonalInformations");
        }
    }
}

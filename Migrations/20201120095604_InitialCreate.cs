using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Africanbiomedtests.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "HealthcareProviders",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(nullable: true),
                    FullName = table.Column<string>(nullable: true),
                    Street = table.Column<string>(nullable: true),
                    City = table.Column<string>(nullable: true),
                    State = table.Column<string>(nullable: true),
                    ZipCode = table.Column<string>(nullable: true),
                    PasswordHash = table.Column<string>(nullable: true),
                    AcceptTerms = table.Column<bool>(nullable: false),
                    Role = table.Column<int>(nullable: false),
                    VerificationToken = table.Column<string>(nullable: true),
                    Verified = table.Column<DateTime>(nullable: true),
                    ResetToken = table.Column<string>(nullable: true),
                    ResetTokenExpires = table.Column<DateTime>(nullable: true),
                    PasswordReset = table.Column<DateTime>(nullable: true),
                    Created = table.Column<DateTime>(nullable: false),
                    Updated = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HealthcareProviders", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Accounts",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(nullable: true),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    PasswordHash = table.Column<string>(nullable: true),
                    AcceptTerms = table.Column<bool>(nullable: false),
                    Role = table.Column<int>(nullable: false),
                    HealthcareProviderId = table.Column<int>(nullable: true),
                    VerificationToken = table.Column<string>(nullable: true),
                    Verified = table.Column<DateTime>(nullable: true),
                    ResetToken = table.Column<string>(nullable: true),
                    ResetTokenExpires = table.Column<DateTime>(nullable: true),
                    PasswordReset = table.Column<DateTime>(nullable: true),
                    Created = table.Column<DateTime>(nullable: false),
                    Updated = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accounts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Accounts_HealthcareProviders_HealthcareProviderId",
                        column: x => x.HealthcareProviderId,
                        principalTable: "HealthcareProviders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Accounts_RefreshTokens",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AccountId = table.Column<int>(nullable: false),
                    Token = table.Column<string>(nullable: true),
                    Expires = table.Column<DateTime>(nullable: false),
                    Created = table.Column<DateTime>(nullable: false),
                    CreatedByIp = table.Column<string>(nullable: true),
                    Revoked = table.Column<DateTime>(nullable: true),
                    RevokedByIp = table.Column<string>(nullable: true),
                    ReplacedByToken = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accounts_RefreshTokens", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Accounts_RefreshTokens_Accounts_AccountId",
                        column: x => x.AccountId,
                        principalTable: "Accounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HealthcareProviders_RefreshTokens",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AccountId = table.Column<int>(nullable: true),
                    Token = table.Column<string>(nullable: true),
                    Expires = table.Column<DateTime>(nullable: false),
                    Created = table.Column<DateTime>(nullable: false),
                    CreatedByIp = table.Column<string>(nullable: true),
                    Revoked = table.Column<DateTime>(nullable: true),
                    RevokedByIp = table.Column<string>(nullable: true),
                    ReplacedByToken = table.Column<string>(nullable: true),
                    HealthcareProviderId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HealthcareProviders_RefreshTokens", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HealthcareProviders_RefreshTokens_Accounts_AccountId",
                        column: x => x.AccountId,
                        principalTable: "Accounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HealthcareProviders_RefreshTokens_HealthcareProviders_HealthcareProviderId",
                        column: x => x.HealthcareProviderId,
                        principalTable: "HealthcareProviders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Newborns",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    BirthDate = table.Column<DateTime>(nullable: false),
                    Gender = table.Column<string>(nullable: true),
                    AccountId = table.Column<int>(nullable: true),
                    HealthcareProviderId = table.Column<int>(nullable: true),
                    Created = table.Column<DateTime>(nullable: false),
                    Updated = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Newborns", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Newborns_Accounts_AccountId",
                        column: x => x.AccountId,
                        principalTable: "Accounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Newborns_HealthcareProviders_HealthcareProviderId",
                        column: x => x.HealthcareProviderId,
                        principalTable: "HealthcareProviders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Accounts_HealthcareProviderId",
                table: "Accounts",
                column: "HealthcareProviderId");

            migrationBuilder.CreateIndex(
                name: "IX_Accounts_RefreshTokens_AccountId",
                table: "Accounts_RefreshTokens",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_HealthcareProviders_RefreshTokens_AccountId",
                table: "HealthcareProviders_RefreshTokens",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_HealthcareProviders_RefreshTokens_HealthcareProviderId",
                table: "HealthcareProviders_RefreshTokens",
                column: "HealthcareProviderId");

            migrationBuilder.CreateIndex(
                name: "IX_Newborns_AccountId",
                table: "Newborns",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_Newborns_HealthcareProviderId",
                table: "Newborns",
                column: "HealthcareProviderId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Accounts_RefreshTokens");

            migrationBuilder.DropTable(
                name: "HealthcareProviders_RefreshTokens");

            migrationBuilder.DropTable(
                name: "Newborns");

            migrationBuilder.DropTable(
                name: "Accounts");

            migrationBuilder.DropTable(
                name: "HealthcareProviders");
        }
    }
}

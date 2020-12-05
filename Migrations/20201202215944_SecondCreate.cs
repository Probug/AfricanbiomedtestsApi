using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Africanbiomedtests.Migrations
{
    public partial class SecondCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MedTest",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Price = table.Column<decimal>(nullable: false),
                    Created = table.Column<DateTime>(nullable: false),
                    Updated = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedTest", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MedTestOrder",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MedTestId = table.Column<int>(nullable: true),
                    healthcareProviderId = table.Column<int>(nullable: true),
                    AccountId = table.Column<int>(nullable: true),
                    NewbornId = table.Column<int>(nullable: true),
                    PaymentStatus = table.Column<string>(nullable: true),
                    CompletionStatus = table.Column<bool>(nullable: false),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    DateCompleted = table.Column<DateTime>(nullable: false),
                    Updated = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedTestOrder", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MedTestOrder_Accounts_AccountId",
                        column: x => x.AccountId,
                        principalTable: "Accounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MedTestOrder_MedTest_MedTestId",
                        column: x => x.MedTestId,
                        principalTable: "MedTest",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MedTestOrder_Newborns_NewbornId",
                        column: x => x.NewbornId,
                        principalTable: "Newborns",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MedTestOrder_HealthcareProviders_healthcareProviderId",
                        column: x => x.healthcareProviderId,
                        principalTable: "HealthcareProviders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MedTestResult",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MedTestId = table.Column<int>(nullable: true),
                    AccountId = table.Column<int>(nullable: true),
                    healthcareProviderId = table.Column<int>(nullable: true),
                    NewbornId = table.Column<int>(nullable: true),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    CompletionStatus = table.Column<bool>(nullable: false),
                    DateCompleted = table.Column<DateTime>(nullable: false),
                    Analysis = table.Column<string>(nullable: true),
                    Action = table.Column<string>(nullable: true),
                    Updated = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedTestResult", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MedTestResult_Accounts_AccountId",
                        column: x => x.AccountId,
                        principalTable: "Accounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MedTestResult_MedTest_MedTestId",
                        column: x => x.MedTestId,
                        principalTable: "MedTest",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MedTestResult_Newborns_NewbornId",
                        column: x => x.NewbornId,
                        principalTable: "Newborns",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MedTestResult_HealthcareProviders_healthcareProviderId",
                        column: x => x.healthcareProviderId,
                        principalTable: "HealthcareProviders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MedTestOrder_AccountId",
                table: "MedTestOrder",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_MedTestOrder_MedTestId",
                table: "MedTestOrder",
                column: "MedTestId");

            migrationBuilder.CreateIndex(
                name: "IX_MedTestOrder_NewbornId",
                table: "MedTestOrder",
                column: "NewbornId");

            migrationBuilder.CreateIndex(
                name: "IX_MedTestOrder_healthcareProviderId",
                table: "MedTestOrder",
                column: "healthcareProviderId");

            migrationBuilder.CreateIndex(
                name: "IX_MedTestResult_AccountId",
                table: "MedTestResult",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_MedTestResult_MedTestId",
                table: "MedTestResult",
                column: "MedTestId");

            migrationBuilder.CreateIndex(
                name: "IX_MedTestResult_NewbornId",
                table: "MedTestResult",
                column: "NewbornId");

            migrationBuilder.CreateIndex(
                name: "IX_MedTestResult_healthcareProviderId",
                table: "MedTestResult",
                column: "healthcareProviderId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MedTestOrder");

            migrationBuilder.DropTable(
                name: "MedTestResult");

            migrationBuilder.DropTable(
                name: "MedTest");
        }
    }
}

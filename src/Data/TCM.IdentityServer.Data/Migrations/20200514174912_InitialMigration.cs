using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TCM.IdentityServer.Data.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Subject = table.Column<string>(maxLength: 200, nullable: false),
                    UserName = table.Column<string>(maxLength: 200, nullable: true),
                    Password = table.Column<string>(maxLength: 200, nullable: true),
                    Email = table.Column<string>(maxLength: 200, nullable: true),
                    CPF = table.Column<string>(maxLength: 11, nullable: true),
                    CNPJ = table.Column<string>(maxLength: 14, nullable: true),
                    Active = table.Column<bool>(nullable: false),
                    IsCPFVerified = table.Column<bool>(nullable: false),
                    IsCNPJVerified = table.Column<bool>(nullable: false),
                    SecurityCode = table.Column<string>(maxLength: 200, nullable: true),
                    SecurityCodeExpirationDate = table.Column<DateTime>(nullable: false),
                    ConcurrencyStamp = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Claims",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Type = table.Column<string>(maxLength: 250, nullable: false),
                    Value = table.Column<string>(maxLength: 250, nullable: false),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    UserId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Claims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Claims_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Logins",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Provider = table.Column<string>(maxLength: 200, nullable: false),
                    ProviderIdentityKey = table.Column<string>(maxLength: 200, nullable: false),
                    UserId = table.Column<Guid>(nullable: false),
                    ConcurrencyStamp = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Logins", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Logins_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Secrets",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Secret = table.Column<string>(nullable: false),
                    UserId = table.Column<Guid>(nullable: false),
                    ConcurrencyStamp = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Secrets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Secrets_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Active", "CNPJ", "CPF", "ConcurrencyStamp", "Email", "IsCNPJVerified", "IsCPFVerified", "Password", "SecurityCode", "SecurityCodeExpirationDate", "Subject", "UserName" },
                values: new object[] { new Guid("2715f962-dec3-46a3-95a1-d50a2ffc4e1e"), true, null, null, "1a9eccbb-3580-4d93-99f7-504357e49b94", null, false, false, "admin", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "1204d34f-3590-4a96-ade5-678a2108e9e4", "admin" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Active", "CNPJ", "CPF", "ConcurrencyStamp", "Email", "IsCNPJVerified", "IsCPFVerified", "Password", "SecurityCode", "SecurityCodeExpirationDate", "Subject", "UserName" },
                values: new object[] { new Guid("67b855a3-f30f-4023-bb51-ab14c5b48811"), true, null, null, "eb652fe7-756b-49ba-a0a6-fca50bf042ea", null, false, false, "testuser", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "484ae583-5188-421f-8ea4-68c5f8287b85", "testuser" });

            migrationBuilder.InsertData(
                table: "Claims",
                columns: new[] { "Id", "ConcurrencyStamp", "Type", "UserId", "Value" },
                values: new object[,]
                {
                    { new Guid("e100411f-32d3-44f3-a165-6b1d803e7493"), "84042d62-5799-4b8a-b1c4-1882b4a588d3", "roles", new Guid("2715f962-dec3-46a3-95a1-d50a2ffc4e1e"), "global_admin" },
                    { new Guid("09f86a0d-1942-4de1-98d6-8eac2e7c21fe"), "3e7148d4-6b6e-48f9-b3e4-1404ea94f573", "given_name", new Guid("2715f962-dec3-46a3-95a1-d50a2ffc4e1e"), "Administrador" },
                    { new Guid("619c957d-d8c8-4ed1-9dc8-f9ae665e2706"), "d7675e3b-ca12-4e53-b208-dd74c90b52fb", "roles", new Guid("67b855a3-f30f-4023-bb51-ab14c5b48811"), "general_user" },
                    { new Guid("d4640432-41ed-4621-a38c-b15bea21f0ab"), "75432bfa-02a1-449a-a607-a318100d72ca", "given_name", new Guid("67b855a3-f30f-4023-bb51-ab14c5b48811"), "Test User" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Claims_UserId",
                table: "Claims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Logins_UserId",
                table: "Logins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Secrets_UserId",
                table: "Secrets",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_Subject",
                table: "Users",
                column: "Subject",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_UserName",
                table: "Users",
                column: "UserName",
                unique: true,
                filter: "[UserName] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Claims");

            migrationBuilder.DropTable(
                name: "Logins");

            migrationBuilder.DropTable(
                name: "Secrets");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}

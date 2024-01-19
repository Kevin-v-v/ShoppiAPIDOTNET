using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShoppiAPIDOTNET.Migrations
{
    public partial class Users : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UserProfiles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PhoneNumber = table.Column<string>(type: "varchar(15)", unicode: false, maxLength: 15, nullable: true),
                    Name = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: true),
                    LastName = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: true),
                    ProfilePictureUrl = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserProfiles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: true),
                    Description = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserAccounts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserName = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Email = table.Column<string>(type: "varchar(400)", unicode: false, maxLength: 400, nullable: true),
                    PasswordHash = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserTypeId = table.Column<int>(type: "int", nullable: false),
                    UserStatus = table.Column<int>(type: "int", nullable: false),
                    UserProfileId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserAccounts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserAccounts_UserProfiles_UserProfileId",
                        column: x => x.UserProfileId,
                        principalTable: "UserProfiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserAccounts_UserTypes_UserTypeId",
                        column: x => x.UserTypeId,
                        principalTable: "UserTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "UserProfiles",
                columns: new[] { "Id", "LastName", "Name", "PhoneNumber", "ProfilePictureUrl" },
                values: new object[,]
                {
                    { -2, "Fonsi", "Luis", "+5212312341234", null },
                    { -1, "Villalobos", "Kevin", "+5212323121212", null }
                });

            migrationBuilder.InsertData(
                table: "UserTypes",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { -2, "Usuario con permiso de publicar anuncios", "Seller" },
                    { -1, "Administrador del sistema", "Admin" }
                });

            migrationBuilder.InsertData(
                table: "UserAccounts",
                columns: new[] { "Id", "CreatedAt", "Email", "LastUpdatedAt", "PasswordHash", "UserName", "UserProfileId", "UserStatus", "UserTypeId" },
                values: new object[] { new Guid("46bb231d-6b09-4797-a5d7-5eb7c5adf01e"), new DateTime(2024, 1, 18, 20, 8, 15, 811, DateTimeKind.Local).AddTicks(2878), "kevinv@example.com", new DateTime(2024, 1, 18, 20, 8, 15, 811, DateTimeKind.Local).AddTicks(2897), "$2a$11$QGbqhRgG5xwaxMk2i8xb4edMQAYVYkMuyfAPapCDnpDsrsOd5V1sW", "KevinV", -1, 0, -1 });

            migrationBuilder.InsertData(
                table: "UserAccounts",
                columns: new[] { "Id", "CreatedAt", "Email", "LastUpdatedAt", "PasswordHash", "UserName", "UserProfileId", "UserStatus", "UserTypeId" },
                values: new object[] { new Guid("573a75fa-2106-42d3-958f-65829ca5608e"), new DateTime(2024, 1, 18, 20, 8, 15, 811, DateTimeKind.Local).AddTicks(2902), "luisd@example.com", new DateTime(2024, 1, 18, 20, 8, 15, 811, DateTimeKind.Local).AddTicks(2904), "$2a$11$GLY5Baw4A1lYtuPL.wS1c.vRoAJ6V.hIL9DNwD1tbOSWF2tQjfMg6", "LuisF", -2, 0, -2 });

            migrationBuilder.CreateIndex(
                name: "IX_UserAccounts_UserProfileId",
                table: "UserAccounts",
                column: "UserProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_UserAccounts_UserTypeId",
                table: "UserAccounts",
                column: "UserTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserAccounts");

            migrationBuilder.DropTable(
                name: "UserProfiles");

            migrationBuilder.DropTable(
                name: "UserTypes");
        }
    }
}

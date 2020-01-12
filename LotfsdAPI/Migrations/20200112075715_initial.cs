using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Lotfsd.API.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("Npgsql:PostgresExtension:uuid-ossp", ",,");

            migrationBuilder.CreateTable(
                name: "Items",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Guid = table.Column<string>(nullable: true, defaultValueSql: "uuid_generate_v4()"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Items", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Guid = table.Column<Guid>(nullable: false, defaultValueSql: "uuid_generate_v4()"),
                    UserName = table.Column<string>(nullable: true),
                    NormalizedUserName = table.Column<string>(nullable: true),
                    PasswordHash = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CharacterSheets",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Guid = table.Column<string>(nullable: true, defaultValueSql: "uuid_generate_v4()"),
                    Name = table.Column<string>(nullable: true),
                    Experience = table.Column<int>(nullable: false),
                    Class = table.Column<string>(nullable: true),
                    Race = table.Column<string>(nullable: true),
                    Age = table.Column<int>(nullable: false),
                    Gender = table.Column<string>(nullable: true),
                    Alignment = table.Column<string>(nullable: true),
                    Player = table.Column<string>(nullable: true),
                    AttackBonus = table.Column<int>(nullable: false),
                    CurrentHp = table.Column<int>(nullable: false),
                    MaxHp = table.Column<int>(nullable: false),
                    SurpriseChance = table.Column<int>(nullable: false),
                    Paralyze = table.Column<int>(nullable: false),
                    Poison = table.Column<int>(nullable: false),
                    BreathWeapon = table.Column<int>(nullable: false),
                    MagicalDevice = table.Column<int>(nullable: false),
                    Magic = table.Column<int>(nullable: false),
                    Charisma = table.Column<int>(nullable: false),
                    Constitution = table.Column<int>(nullable: false),
                    Dexterity = table.Column<int>(nullable: false),
                    Intelligence = table.Column<int>(nullable: false),
                    Strength = table.Column<int>(nullable: false),
                    Wisdom = table.Column<int>(nullable: false),
                    Architecture = table.Column<int>(nullable: false),
                    Bushcraft = table.Column<int>(nullable: false),
                    Climbing = table.Column<int>(nullable: false),
                    Languages = table.Column<int>(nullable: false),
                    OpenDoors = table.Column<int>(nullable: false),
                    Search = table.Column<int>(nullable: false),
                    SleightOfHand = table.Column<int>(nullable: false),
                    SneakAttack = table.Column<int>(nullable: false),
                    Stealth = table.Column<int>(nullable: false),
                    Tinkering = table.Column<int>(nullable: false),
                    Copper = table.Column<int>(nullable: false),
                    Silver = table.Column<int>(nullable: false),
                    Gold = table.Column<int>(nullable: false),
                    Standard = table.Column<bool>(nullable: false),
                    Parry = table.Column<bool>(nullable: false),
                    ImprovedParry = table.Column<bool>(nullable: false),
                    Press = table.Column<bool>(nullable: false),
                    Defensive = table.Column<bool>(nullable: false),
                    UserId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CharacterSheets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CharacterSheets_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Effects",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Guid = table.Column<string>(nullable: true, defaultValueSql: "uuid_generate_v4()"),
                    Type = table.Column<string>(nullable: true),
                    Target = table.Column<string>(nullable: true),
                    Method = table.Column<string>(nullable: true),
                    Value = table.Column<int>(nullable: false),
                    CharacterSheetId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Effects", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Effects_CharacterSheets_CharacterSheetId",
                        column: x => x.CharacterSheetId,
                        principalTable: "CharacterSheets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ItemInstances",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Guid = table.Column<string>(nullable: true, defaultValueSql: "uuid_generate_v4()"),
                    ItemId = table.Column<int>(nullable: true),
                    Equipped = table.Column<bool>(nullable: false),
                    CharacterSheetId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemInstances", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ItemInstances_CharacterSheets_CharacterSheetId",
                        column: x => x.CharacterSheetId,
                        principalTable: "CharacterSheets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ItemInstances_Items_ItemId",
                        column: x => x.ItemId,
                        principalTable: "Items",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Retainers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Guid = table.Column<string>(nullable: true, defaultValueSql: "uuid_generate_v4()"),
                    Name = table.Column<string>(nullable: true),
                    Position = table.Column<string>(nullable: true),
                    Class = table.Column<string>(nullable: true),
                    Level = table.Column<int>(nullable: false),
                    Hitpoints = table.Column<int>(nullable: false),
                    Wage = table.Column<int>(nullable: false),
                    Share = table.Column<int>(nullable: false),
                    CharacterSheetId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Retainers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Retainers_CharacterSheets_CharacterSheetId",
                        column: x => x.CharacterSheetId,
                        principalTable: "CharacterSheets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Properties",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Guid = table.Column<string>(nullable: true, defaultValueSql: "uuid_generate_v4()"),
                    Name = table.Column<string>(nullable: true),
                    Value = table.Column<int>(nullable: false),
                    Rent = table.Column<int>(nullable: false),
                    Location = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    InventoryId = table.Column<int>(nullable: true),
                    CharacterSheetId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Properties", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Properties_CharacterSheets_CharacterSheetId",
                        column: x => x.CharacterSheetId,
                        principalTable: "CharacterSheets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Properties_ItemInstances_InventoryId",
                        column: x => x.InventoryId,
                        principalTable: "ItemInstances",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CharacterSheets_Guid",
                table: "CharacterSheets",
                column: "Guid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CharacterSheets_UserId",
                table: "CharacterSheets",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Effects_CharacterSheetId",
                table: "Effects",
                column: "CharacterSheetId");

            migrationBuilder.CreateIndex(
                name: "IX_Effects_Guid",
                table: "Effects",
                column: "Guid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ItemInstances_CharacterSheetId",
                table: "ItemInstances",
                column: "CharacterSheetId");

            migrationBuilder.CreateIndex(
                name: "IX_ItemInstances_Guid",
                table: "ItemInstances",
                column: "Guid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ItemInstances_ItemId",
                table: "ItemInstances",
                column: "ItemId");

            migrationBuilder.CreateIndex(
                name: "IX_Items_Guid",
                table: "Items",
                column: "Guid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Properties_CharacterSheetId",
                table: "Properties",
                column: "CharacterSheetId");

            migrationBuilder.CreateIndex(
                name: "IX_Properties_Guid",
                table: "Properties",
                column: "Guid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Properties_InventoryId",
                table: "Properties",
                column: "InventoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Retainers_CharacterSheetId",
                table: "Retainers",
                column: "CharacterSheetId");

            migrationBuilder.CreateIndex(
                name: "IX_Retainers_Guid",
                table: "Retainers",
                column: "Guid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_Guid",
                table: "Users",
                column: "Guid",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Effects");

            migrationBuilder.DropTable(
                name: "Properties");

            migrationBuilder.DropTable(
                name: "Retainers");

            migrationBuilder.DropTable(
                name: "ItemInstances");

            migrationBuilder.DropTable(
                name: "CharacterSheets");

            migrationBuilder.DropTable(
                name: "Items");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}

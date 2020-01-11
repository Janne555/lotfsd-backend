﻿// <auto-generated />
using System;
using Lotfsd.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Lotfsd.API.Migrations
{
    [DbContext(typeof(LotfsdContext))]
    partial class LotfsdContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn)
                .HasAnnotation("ProductVersion", "3.1.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("Lotfsd.Data.Models.CharacterSheet", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn);

                    b.Property<int>("Age")
                        .HasColumnType("integer");

                    b.Property<string>("Alignment")
                        .HasColumnType("text");

                    b.Property<int>("Architecture")
                        .HasColumnType("integer");

                    b.Property<int>("AttackBonus")
                        .HasColumnType("integer");

                    b.Property<int>("BreathWeapon")
                        .HasColumnType("integer");

                    b.Property<int>("Bushcraft")
                        .HasColumnType("integer");

                    b.Property<int>("Charisma")
                        .HasColumnType("integer");

                    b.Property<string>("Class")
                        .HasColumnType("text");

                    b.Property<int>("Climbing")
                        .HasColumnType("integer");

                    b.Property<int>("Constitution")
                        .HasColumnType("integer");

                    b.Property<int>("Copper")
                        .HasColumnType("integer");

                    b.Property<int>("CurrentHp")
                        .HasColumnType("integer");

                    b.Property<bool>("Defensive")
                        .HasColumnType("boolean");

                    b.Property<int>("Dexterity")
                        .HasColumnType("integer");

                    b.Property<int>("Experience")
                        .HasColumnType("integer");

                    b.Property<string>("Gender")
                        .HasColumnType("text");

                    b.Property<int>("Gold")
                        .HasColumnType("integer");

                    b.Property<bool>("ImprovedParry")
                        .HasColumnType("boolean");

                    b.Property<int>("Intelligence")
                        .HasColumnType("integer");

                    b.Property<int>("Languages")
                        .HasColumnType("integer");

                    b.Property<int>("Magic")
                        .HasColumnType("integer");

                    b.Property<int>("MagicalDevice")
                        .HasColumnType("integer");

                    b.Property<int>("MaxHp")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<int>("OpenDoors")
                        .HasColumnType("integer");

                    b.Property<int>("Paralyze")
                        .HasColumnType("integer");

                    b.Property<bool>("Parry")
                        .HasColumnType("boolean");

                    b.Property<string>("Player")
                        .HasColumnType("text");

                    b.Property<int>("Poison")
                        .HasColumnType("integer");

                    b.Property<bool>("Press")
                        .HasColumnType("boolean");

                    b.Property<string>("Race")
                        .HasColumnType("text");

                    b.Property<int>("Search")
                        .HasColumnType("integer");

                    b.Property<int>("Silver")
                        .HasColumnType("integer");

                    b.Property<int>("SleightOfHand")
                        .HasColumnType("integer");

                    b.Property<int>("SneakAttack")
                        .HasColumnType("integer");

                    b.Property<bool>("Standard")
                        .HasColumnType("boolean");

                    b.Property<int>("Stealth")
                        .HasColumnType("integer");

                    b.Property<int>("Strength")
                        .HasColumnType("integer");

                    b.Property<int>("SurpriseChance")
                        .HasColumnType("integer");

                    b.Property<int>("Tinkering")
                        .HasColumnType("integer");

                    b.Property<int?>("UserId")
                        .HasColumnType("integer");

                    b.Property<int>("Wisdom")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("CharacterSheets");
                });

            modelBuilder.Entity("Lotfsd.Data.Models.Effect", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn);

                    b.Property<int?>("CharacterSheetId")
                        .HasColumnType("integer");

                    b.Property<string>("Method")
                        .HasColumnType("text");

                    b.Property<string>("Target")
                        .HasColumnType("text");

                    b.Property<string>("Type")
                        .HasColumnType("text");

                    b.Property<int>("Value")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("CharacterSheetId");

                    b.ToTable("Effects");
                });

            modelBuilder.Entity("Lotfsd.Data.Models.Item", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn);

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Items");
                });

            modelBuilder.Entity("Lotfsd.Data.Models.ItemInstance", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn);

                    b.Property<int?>("CharacterSheetId")
                        .HasColumnType("integer");

                    b.Property<bool>("Equipped")
                        .HasColumnType("boolean");

                    b.Property<int?>("ItemId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("CharacterSheetId");

                    b.HasIndex("ItemId");

                    b.ToTable("ItemInstances");
                });

            modelBuilder.Entity("Lotfsd.Data.Models.Property", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn);

                    b.Property<int?>("CharacterSheetId")
                        .HasColumnType("integer");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<int?>("InventoryId")
                        .HasColumnType("integer");

                    b.Property<string>("Location")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<int>("Rent")
                        .HasColumnType("integer");

                    b.Property<int>("Value")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("CharacterSheetId");

                    b.HasIndex("InventoryId");

                    b.ToTable("Properties");
                });

            modelBuilder.Entity("Lotfsd.Data.Models.Retainer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn);

                    b.Property<int?>("CharacterSheetId")
                        .HasColumnType("integer");

                    b.Property<string>("Class")
                        .HasColumnType("text");

                    b.Property<int>("Hitpoints")
                        .HasColumnType("integer");

                    b.Property<int>("Level")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<string>("Position")
                        .HasColumnType("text");

                    b.Property<int>("Share")
                        .HasColumnType("integer");

                    b.Property<int>("Wage")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("CharacterSheetId");

                    b.ToTable("Retainers");
                });

            modelBuilder.Entity("Lotfsd.Data.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn);

                    b.Property<string>("NormalizedUserName")
                        .HasColumnType("text");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("text");

                    b.Property<string>("UserName")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Lotfsd.Data.Models.CharacterSheet", b =>
                {
                    b.HasOne("Lotfsd.Data.Models.User", null)
                        .WithMany("Characters")
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("Lotfsd.Data.Models.Effect", b =>
                {
                    b.HasOne("Lotfsd.Data.Models.CharacterSheet", null)
                        .WithMany("Effects")
                        .HasForeignKey("CharacterSheetId");
                });

            modelBuilder.Entity("Lotfsd.Data.Models.ItemInstance", b =>
                {
                    b.HasOne("Lotfsd.Data.Models.CharacterSheet", null)
                        .WithMany("Inventory")
                        .HasForeignKey("CharacterSheetId");

                    b.HasOne("Lotfsd.Data.Models.Item", "Item")
                        .WithMany()
                        .HasForeignKey("ItemId");
                });

            modelBuilder.Entity("Lotfsd.Data.Models.Property", b =>
                {
                    b.HasOne("Lotfsd.Data.Models.CharacterSheet", null)
                        .WithMany("Properties")
                        .HasForeignKey("CharacterSheetId");

                    b.HasOne("Lotfsd.Data.Models.ItemInstance", "Inventory")
                        .WithMany()
                        .HasForeignKey("InventoryId");
                });

            modelBuilder.Entity("Lotfsd.Data.Models.Retainer", b =>
                {
                    b.HasOne("Lotfsd.Data.Models.CharacterSheet", null)
                        .WithMany("Retainers")
                        .HasForeignKey("CharacterSheetId");
                });
#pragma warning restore 612, 618
        }
    }
}

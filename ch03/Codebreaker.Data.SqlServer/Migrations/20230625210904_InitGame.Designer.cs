﻿// <auto-generated />
using System;
using Codebreaker.Data.SqlServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Codebreaker.Data.SqlServer.Migrations
{
    [DbContext(typeof(GamesSqlServerContext))]
    [Migration("20230625210904_InitGame")]
    partial class InitGame
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("Codebreaker")
                .HasAnnotation("ProductVersion", "8.0.0-preview.4.23259.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Codebreaker.GameAPIs.Models.Game", b =>
                {
                    b.Property<Guid>("GameId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<TimeSpan?>("Duration")
                        .HasColumnType("time");

                    b.Property<DateTime?>("EndTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("GameType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("LastMoveNumber")
                        .HasColumnType("int");

                    b.Property<int>("MaxMoves")
                        .HasColumnType("int");

                    b.Property<int>("NumberCodes")
                        .HasColumnType("int");

                    b.Property<string>("PlayerName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("StartTime")
                        .HasColumnType("datetime2");

                    b.Property<bool>("Won")
                        .HasColumnType("bit");

                    b.HasKey("GameId");

                    b.ToTable((string)null);

                    b.UseTpcMappingStrategy();
                });

            modelBuilder.Entity("Codebreaker.GameAPIs.Models.Move", b =>
                {
                    b.Property<Guid>("MoveId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("GameId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("MoveNumber")
                        .HasColumnType("int");

                    b.HasKey("MoveId");

                    b.ToTable((string)null);

                    b.UseTpcMappingStrategy();
                });

            modelBuilder.Entity("Codebreaker.GameAPIs.Models.Game<Codebreaker.GameAPIs.Models.ColorField, Codebreaker.GameAPIs.Models.ColorResult>", b =>
                {
                    b.HasBaseType("Codebreaker.GameAPIs.Models.Game");

                    b.Property<string>("Codes")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar")
                        .HasColumnName("Codes");

                    b.Property<string>("FieldValues")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar")
                        .HasColumnName("Fields");

                    b.ToTable("ColorGames", "Codebreaker");
                });

            modelBuilder.Entity("Codebreaker.GameAPIs.Models.Game<Codebreaker.GameAPIs.Models.ColorField, Codebreaker.GameAPIs.Models.SimpleColorResult>", b =>
                {
                    b.HasBaseType("Codebreaker.GameAPIs.Models.Game");

                    b.Property<string>("Codes")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar")
                        .HasColumnName("Codes");

                    b.Property<string>("FieldValues")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar")
                        .HasColumnName("Fields");

                    b.ToTable("SimpleGames", "Codebreaker");
                });

            modelBuilder.Entity("Codebreaker.GameAPIs.Models.Game<Codebreaker.GameAPIs.Models.ShapeAndColorField, Codebreaker.GameAPIs.Models.ShapeAndColorResult>", b =>
                {
                    b.HasBaseType("Codebreaker.GameAPIs.Models.Game");

                    b.Property<string>("Codes")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar")
                        .HasColumnName("Codes");

                    b.Property<string>("FieldValues")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar")
                        .HasColumnName("Fields");

                    b.ToTable("ShapeGames", "Codebreaker");
                });

            modelBuilder.Entity("Codebreaker.GameAPIs.Models.Move<Codebreaker.GameAPIs.Models.ColorField, Codebreaker.GameAPIs.Models.ColorResult>", b =>
                {
                    b.HasBaseType("Codebreaker.GameAPIs.Models.Move");

                    b.Property<string>("GuessPegs")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar");

                    b.Property<string>("KeyPegs")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar");

                    b.HasIndex("GameId");

                    b.ToTable("ColorMoves", "Codebreaker");
                });

            modelBuilder.Entity("Codebreaker.GameAPIs.Models.Move<Codebreaker.GameAPIs.Models.ColorField, Codebreaker.GameAPIs.Models.SimpleColorResult>", b =>
                {
                    b.HasBaseType("Codebreaker.GameAPIs.Models.Move");

                    b.Property<string>("GuessPegs")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar");

                    b.Property<string>("KeyPegs")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar");

                    b.HasIndex("GameId");

                    b.ToTable("SimpleMoves", "Codebreaker");
                });

            modelBuilder.Entity("Codebreaker.GameAPIs.Models.Move<Codebreaker.GameAPIs.Models.ShapeAndColorField, Codebreaker.GameAPIs.Models.ShapeAndColorResult>", b =>
                {
                    b.HasBaseType("Codebreaker.GameAPIs.Models.Move");

                    b.Property<string>("GuessPegs")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar");

                    b.Property<string>("KeyPegs")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar");

                    b.HasIndex("GameId");

                    b.ToTable("ShapeMoves", "Codebreaker");
                });

            modelBuilder.Entity("Codebreaker.GameAPIs.Models.Move<Codebreaker.GameAPIs.Models.ColorField, Codebreaker.GameAPIs.Models.ColorResult>", b =>
                {
                    b.HasOne("Codebreaker.GameAPIs.Models.Game<Codebreaker.GameAPIs.Models.ColorField, Codebreaker.GameAPIs.Models.ColorResult>", null)
                        .WithMany("Moves")
                        .HasForeignKey("GameId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Codebreaker.GameAPIs.Models.Move<Codebreaker.GameAPIs.Models.ColorField, Codebreaker.GameAPIs.Models.SimpleColorResult>", b =>
                {
                    b.HasOne("Codebreaker.GameAPIs.Models.Game<Codebreaker.GameAPIs.Models.ColorField, Codebreaker.GameAPIs.Models.SimpleColorResult>", null)
                        .WithMany("Moves")
                        .HasForeignKey("GameId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Codebreaker.GameAPIs.Models.Move<Codebreaker.GameAPIs.Models.ShapeAndColorField, Codebreaker.GameAPIs.Models.ShapeAndColorResult>", b =>
                {
                    b.HasOne("Codebreaker.GameAPIs.Models.Game<Codebreaker.GameAPIs.Models.ShapeAndColorField, Codebreaker.GameAPIs.Models.ShapeAndColorResult>", null)
                        .WithMany("Moves")
                        .HasForeignKey("GameId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Codebreaker.GameAPIs.Models.Game<Codebreaker.GameAPIs.Models.ColorField, Codebreaker.GameAPIs.Models.ColorResult>", b =>
                {
                    b.Navigation("Moves");
                });

            modelBuilder.Entity("Codebreaker.GameAPIs.Models.Game<Codebreaker.GameAPIs.Models.ColorField, Codebreaker.GameAPIs.Models.SimpleColorResult>", b =>
                {
                    b.Navigation("Moves");
                });

            modelBuilder.Entity("Codebreaker.GameAPIs.Models.Game<Codebreaker.GameAPIs.Models.ShapeAndColorField, Codebreaker.GameAPIs.Models.ShapeAndColorResult>", b =>
                {
                    b.Navigation("Moves");
                });
#pragma warning restore 612, 618
        }
    }
}

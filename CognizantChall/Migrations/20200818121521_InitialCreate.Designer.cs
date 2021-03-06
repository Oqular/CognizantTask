﻿// <auto-generated />
using CognizantChall.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CognizantChall.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20200818121521_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CognizantChall.Models.PlayerTasks", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("playersId")
                        .HasColumnType("int");

                    b.Property<int>("tasksId")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("playersId");

                    b.HasIndex("tasksId");

                    b.ToTable("PlayerTasks");
                });

            modelBuilder.Entity("CognizantChall.Models.Players", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("nickname")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("successfulTaskCount")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.ToTable("players");
                });

            modelBuilder.Entity("CognizantChall.Models.Tasks", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("testInput")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("testOutput")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("tasks");
                });

            modelBuilder.Entity("CognizantChall.Models.PlayerTasks", b =>
                {
                    b.HasOne("CognizantChall.Models.Players", "player")
                        .WithMany("tasks")
                        .HasForeignKey("playersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CognizantChall.Models.Tasks", "task")
                        .WithMany("players")
                        .HasForeignKey("tasksId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}

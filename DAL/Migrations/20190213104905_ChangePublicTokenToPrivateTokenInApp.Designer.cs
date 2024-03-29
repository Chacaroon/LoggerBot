﻿// <auto-generated />
using System;
using DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DAL.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    [Migration("20190213104905_ChangePublicTokenToPrivateTokenInApp")]
    partial class ChangePublicTokenToPrivateTokenInApp
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.1-servicing-10028")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("DAL.Models.App", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedAt");

                    b.Property<string>("Name");

                    b.Property<Guid>("PrivateToken");

                    b.Property<Guid>("SubscribeToken");

                    b.HasKey("Id");

                    b.ToTable("Apps");
                });

            modelBuilder.Entity("DAL.Models.ApplicationUser", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long>("ChatId");

                    b.Property<long?>("ChatStateId");

                    b.Property<DateTime>("CreatedAt");

                    b.HasKey("Id");

                    b.HasIndex("ChatStateId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("DAL.Models.ChatState", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedAt");

                    b.Property<bool>("IsWaitingFor");

                    b.Property<string>("WaitingFor");

                    b.HasKey("Id");

                    b.ToTable("ChatStates");
                });

            modelBuilder.Entity("DAL.Models.ExceptionInfo", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long?>("AppId");

                    b.Property<DateTime>("CreatedAt");

                    b.Property<string>("Message");

                    b.Property<string>("StackTrace");

                    b.HasKey("Id");

                    b.HasIndex("AppId");

                    b.ToTable("Exceptions");
                });

            modelBuilder.Entity("DAL.Models.UserApp", b =>
                {
                    b.Property<long>("UserId");

                    b.Property<long>("AppId");

                    b.Property<bool>("IsSubscriber");

                    b.HasKey("UserId", "AppId");

                    b.HasIndex("AppId");

                    b.ToTable("UserApp");
                });

            modelBuilder.Entity("DAL.Models.ApplicationUser", b =>
                {
                    b.HasOne("DAL.Models.ChatState", "ChatState")
                        .WithMany()
                        .HasForeignKey("ChatStateId");
                });

            modelBuilder.Entity("DAL.Models.ExceptionInfo", b =>
                {
                    b.HasOne("DAL.Models.App")
                        .WithMany("Exceptions")
                        .HasForeignKey("AppId");
                });

            modelBuilder.Entity("DAL.Models.UserApp", b =>
                {
                    b.HasOne("DAL.Models.App", "App")
                        .WithMany("UserApps")
                        .HasForeignKey("AppId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("DAL.Models.ApplicationUser", "User")
                        .WithMany("UserApps")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}

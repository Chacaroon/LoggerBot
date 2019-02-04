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
    [Migration("20190118161658_Init")]
    partial class Init
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
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreatedAt");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Apps");
                });

            modelBuilder.Entity("DAL.Models.ExceptionInfo", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid?>("AppId");

                    b.Property<DateTime>("CreatedAt");

                    b.Property<string>("Message");

                    b.Property<string>("StackTrace");

                    b.HasKey("Id");

                    b.HasIndex("AppId");

                    b.ToTable("Exceptions");
                });

            modelBuilder.Entity("DAL.Models.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<long>("ChatId");

                    b.Property<DateTime>("CreatedAt");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("DAL.Models.UserApp", b =>
                {
                    b.Property<Guid>("UserId");

                    b.Property<Guid>("AppId");

                    b.HasKey("UserId", "AppId");

                    b.HasIndex("AppId");

                    b.ToTable("UserApp");
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

                    b.HasOne("DAL.Models.User", "User")
                        .WithMany("UserApps")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}

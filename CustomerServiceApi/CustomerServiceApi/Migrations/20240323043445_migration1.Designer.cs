﻿// <auto-generated />
using System;
using CustomerServiceApi.Utility;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CustomerServiceApi.Migrations
{
    [DbContext(typeof(DbContextData))]
    [Migration("20240323043445_migration1")]
    partial class migration1
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.25")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("CustomerServiceApi.Models.Agent", b =>
                {
                    b.Property<int>("AgentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AgentId"), 1L, 1);

                    b.Property<string>("AgentName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("AgentId");

                    b.ToTable("Agents");
                });

            modelBuilder.Entity("CustomerServiceApi.Models.Form", b =>
                {
                    b.Property<int>("FormId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("FormId"), 1L, 1);

                    b.Property<int>("AgentId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("CustomerId")
                        .HasColumnType("int");

                    b.Property<string>("FormName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("FormId");

                    b.HasIndex("AgentId");

                    b.ToTable("Forms");
                });

            modelBuilder.Entity("CustomerServiceApi.Models.Purchase", b =>
                {
                    b.Property<int>("PurchaseID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PurchaseID"), 1L, 1);

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("FormId")
                        .HasColumnType("int");

                    b.Property<int>("PhurchaseAmount")
                        .HasColumnType("int");

                    b.Property<string>("PurchaseType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PurchaseID");

                    b.HasIndex("FormId");

                    b.ToTable("Purchases");
                });

            modelBuilder.Entity("CustomerServiceApi.Models.User", b =>
                {
                    b.Property<int>("UserID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserID"), 1L, 1);

                    b.Property<bool>("Active")
                        .HasColumnType("bit");

                    b.Property<int>("AgentId")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("Hash")
                        .HasColumnType("varbinary(max)");

                    b.Property<byte[]>("Salt")
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserID");

                    b.HasIndex("AgentId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("CustomerServiceApi.Models.Form", b =>
                {
                    b.HasOne("CustomerServiceApi.Models.Agent", "Agent")
                        .WithMany()
                        .HasForeignKey("AgentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Agent");
                });

            modelBuilder.Entity("CustomerServiceApi.Models.Purchase", b =>
                {
                    b.HasOne("CustomerServiceApi.Models.Form", "Form")
                        .WithMany()
                        .HasForeignKey("FormId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Form");
                });

            modelBuilder.Entity("CustomerServiceApi.Models.User", b =>
                {
                    b.HasOne("CustomerServiceApi.Models.Agent", "Agent")
                        .WithMany()
                        .HasForeignKey("AgentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Agent");
                });
#pragma warning restore 612, 618
        }
    }
}

﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PAccountant2.DAL.Context;

namespace PAccountant2.DAL.Migrations.Migrations
{
    [DbContext(typeof(PaccountantContext))]
    partial class PaccountantContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("PAccountant2.DAL.DBO.Entities.AccountDbo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AccountingId");

                    b.Property<decimal>("Amount");

                    b.HasKey("Id");

                    b.HasIndex("AccountingId");

                    b.ToTable("Account");
                });

            modelBuilder.Entity("PAccountant2.DAL.DBO.Entities.AccountOperationDbo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AccountId");

                    b.Property<decimal>("Amount");

                    b.Property<int>("ContragentId");

                    b.Property<DateTime>("Date");

                    b.Property<int>("OperationType");

                    b.HasKey("Id");

                    b.HasIndex("AccountId");

                    b.HasIndex("ContragentId");

                    b.ToTable("AccountOperation");
                });

            modelBuilder.Entity("PAccountant2.DAL.DBO.Entities.AccountingDbo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("UserEmail");

                    b.HasKey("Id");

                    b.HasIndex("UserEmail")
                        .IsUnique()
                        .HasFilter("[UserEmail] IS NOT NULL");

                    b.ToTable("Accounting");
                });

            modelBuilder.Entity("PAccountant2.DAL.DBO.Entities.ContragentDbo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AccountingId");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.HasIndex("AccountingId");

                    b.ToTable("Contragent");
                });

            modelBuilder.Entity("PAccountant2.DAL.DBO.Entities.Investment.InvestmentDbo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AccountingId");

                    b.Property<decimal>("BodyAmount");

                    b.Property<string>("Comment");

                    b.Property<int>("InvestmentType");

                    b.Property<int>("PaymentPeriod");

                    b.Property<float>("Percent");

                    b.Property<DateTime>("StartDate");

                    b.Property<long>("Term");

                    b.HasKey("Id");

                    b.HasIndex("AccountingId");

                    b.ToTable("Investment");
                });

            modelBuilder.Entity("PAccountant2.DAL.DBO.Entities.Investment.InvestmentOperationDbo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("Amount");

                    b.Property<int>("ContragentId");

                    b.Property<DateTime>("Date");

                    b.Property<int>("InvestmentId");

                    b.Property<int>("OperationType");

                    b.HasKey("Id");

                    b.HasIndex("ContragentId");

                    b.HasIndex("InvestmentId");

                    b.ToTable("InvestmentOperation");
                });

            modelBuilder.Entity("PAccountant2.DAL.DBO.Entities.UserDbo", b =>
                {
                    b.Property<string>("Email")
                        .ValueGeneratedOnAdd();

                    b.Property<byte[]>("Password");

                    b.HasKey("Email");

                    b.ToTable("User");
                });

            modelBuilder.Entity("PAccountant2.DAL.DBO.Entities.AccountDbo", b =>
                {
                    b.HasOne("PAccountant2.DAL.DBO.Entities.AccountingDbo", "Accounting")
                        .WithMany("Accounts")
                        .HasForeignKey("AccountingId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("PAccountant2.DAL.DBO.Entities.AccountOperationDbo", b =>
                {
                    b.HasOne("PAccountant2.DAL.DBO.Entities.AccountDbo", "Account")
                        .WithMany("AccountHistory")
                        .HasForeignKey("AccountId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("PAccountant2.DAL.DBO.Entities.ContragentDbo", "Contragent")
                        .WithMany("AccountOperations")
                        .HasForeignKey("ContragentId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("PAccountant2.DAL.DBO.Entities.AccountingDbo", b =>
                {
                    b.HasOne("PAccountant2.DAL.DBO.Entities.UserDbo", "User")
                        .WithOne("Accounting")
                        .HasForeignKey("PAccountant2.DAL.DBO.Entities.AccountingDbo", "UserEmail");
                });

            modelBuilder.Entity("PAccountant2.DAL.DBO.Entities.ContragentDbo", b =>
                {
                    b.HasOne("PAccountant2.DAL.DBO.Entities.AccountingDbo", "Accounting")
                        .WithMany()
                        .HasForeignKey("AccountingId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("PAccountant2.DAL.DBO.Entities.Investment.InvestmentDbo", b =>
                {
                    b.HasOne("PAccountant2.DAL.DBO.Entities.AccountingDbo", "Accounting")
                        .WithMany("Investments")
                        .HasForeignKey("AccountingId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("PAccountant2.DAL.DBO.Entities.Investment.InvestmentOperationDbo", b =>
                {
                    b.HasOne("PAccountant2.DAL.DBO.Entities.ContragentDbo", "Contragent")
                        .WithMany("InvestmentOperations")
                        .HasForeignKey("ContragentId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("PAccountant2.DAL.DBO.Entities.Investment.InvestmentDbo", "Investment")
                        .WithMany("Operations")
                        .HasForeignKey("InvestmentId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}

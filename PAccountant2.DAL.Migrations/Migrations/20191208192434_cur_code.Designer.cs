﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PAccountant2.DAL.Context;

namespace PAccountant2.DAL.Migrations.Migrations
{
    [DbContext(typeof(PaccountantContext))]
    [Migration("20191208192434_cur_code")]
    partial class cur_code
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("PAccountant2.DAL.DBO.Entities.Account.AccountDbo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AccountingId");

                    b.Property<decimal>("Amount");

                    b.Property<int>("CurrencyId");

                    b.Property<string>("Name")
                        .HasMaxLength(500);

                    b.HasKey("Id");

                    b.HasIndex("AccountingId");

                    b.HasIndex("CurrencyId");

                    b.ToTable("Account");
                });

            modelBuilder.Entity("PAccountant2.DAL.DBO.Entities.Account.AccountOperationDbo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AccountId");

                    b.Property<decimal>("Amount");

                    b.Property<int?>("ContragentId");

                    b.Property<int>("CurrencyId")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValue(1);

                    b.Property<DateTime>("Date");

                    b.Property<int>("OperationType");

                    b.HasKey("Id");

                    b.HasIndex("AccountId");

                    b.HasIndex("ContragentId");

                    b.HasIndex("CurrencyId");

                    b.ToTable("AccountOperation");
                });

            modelBuilder.Entity("PAccountant2.DAL.DBO.Entities.Accounting.AccountingDbo", b =>
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

            modelBuilder.Entity("PAccountant2.DAL.DBO.Entities.Accounting.AccountingOptionsDbo", b =>
                {
                    b.Property<int>("AccountingId");

                    b.Property<int>("AccountingBaseCurrencyId");

                    b.HasKey("AccountingId");

                    b.HasIndex("AccountingBaseCurrencyId");

                    b.ToTable("AccountingOptions");
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

            modelBuilder.Entity("PAccountant2.DAL.DBO.Entities.Credit.CreditDbo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AccountingId");

                    b.Property<decimal>("BodyAmount");

                    b.Property<string>("Comment");

                    b.Property<int>("CreditType");

                    b.Property<decimal>("LeftAmount");

                    b.Property<float>("Percent");

                    b.Property<decimal>("PercentAmount");

                    b.Property<int>("PercentPeriod");

                    b.Property<DateTime>("StartDate");

                    b.Property<long>("Term");

                    b.HasKey("Id");

                    b.HasIndex("AccountingId");

                    b.ToTable("Credit");
                });

            modelBuilder.Entity("PAccountant2.DAL.DBO.Entities.Credit.CreditOperationDbo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("Amount");

                    b.Property<int>("ContragentId");

                    b.Property<int>("CreditId");

                    b.Property<int>("CurrencyId");

                    b.Property<DateTime>("Date");

                    b.Property<int>("OperationType");

                    b.HasKey("Id");

                    b.HasIndex("ContragentId");

                    b.HasIndex("CreditId");

                    b.HasIndex("CurrencyId");

                    b.ToTable("CreditOperation");
                });

            modelBuilder.Entity("PAccountant2.DAL.DBO.Entities.Currency.CurrencyDbo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Code");

                    b.Property<string>("FullName");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Currency");
                });

            modelBuilder.Entity("PAccountant2.DAL.DBO.Entities.Currency.ExchangeRateDbo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BaseCurrencyId");

                    b.Property<float>("Buy");

                    b.Property<int>("ResultCurrencyId");

                    b.Property<float>("Sell");

                    b.HasKey("Id");

                    b.HasIndex("BaseCurrencyId");

                    b.HasIndex("ResultCurrencyId");

                    b.ToTable("ExchangeRate");
                });

            modelBuilder.Entity("PAccountant2.DAL.DBO.Entities.Investment.InvestmentDbo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AccountingId");

                    b.Property<string>("Comment");

                    b.Property<bool>("Completed");

                    b.Property<int>("CurrencyId");

                    b.Property<decimal>("CurrentBodyAmount");

                    b.Property<int>("InvestmentType");

                    b.Property<int>("MoneyIncomeOption");

                    b.Property<int>("PaymentPeriod");

                    b.Property<float>("Percent");

                    b.Property<decimal>("StartBodyAmount");

                    b.Property<DateTime>("StartDate");

                    b.Property<long>("Term");

                    b.HasKey("Id");

                    b.HasIndex("AccountingId");

                    b.HasIndex("CurrencyId");

                    b.ToTable("Investment");
                });

            modelBuilder.Entity("PAccountant2.DAL.DBO.Entities.Investment.InvestmentOperationDbo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("Amount");

                    b.Property<string>("Comment");

                    b.Property<int?>("ContragentDboId");

                    b.Property<int>("CurrencyId");

                    b.Property<DateTime>("Date");

                    b.Property<int>("InvestmentId");

                    b.Property<decimal>("NewTotalAmount");

                    b.HasKey("Id");

                    b.HasIndex("ContragentDboId");

                    b.HasIndex("CurrencyId");

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

            modelBuilder.Entity("PAccountant2.DAL.DBO.Entities.Account.AccountDbo", b =>
                {
                    b.HasOne("PAccountant2.DAL.DBO.Entities.Accounting.AccountingDbo", "Accounting")
                        .WithMany("Accounts")
                        .HasForeignKey("AccountingId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("PAccountant2.DAL.DBO.Entities.Currency.CurrencyDbo", "Currency")
                        .WithMany("Accounts")
                        .HasForeignKey("CurrencyId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("PAccountant2.DAL.DBO.Entities.Account.AccountOperationDbo", b =>
                {
                    b.HasOne("PAccountant2.DAL.DBO.Entities.Account.AccountDbo", "Account")
                        .WithMany("AccountHistory")
                        .HasForeignKey("AccountId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("PAccountant2.DAL.DBO.Entities.ContragentDbo", "Contragent")
                        .WithMany("AccountOperations")
                        .HasForeignKey("ContragentId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("PAccountant2.DAL.DBO.Entities.Currency.CurrencyDbo", "Currency")
                        .WithMany("AccountOperations")
                        .HasForeignKey("CurrencyId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("PAccountant2.DAL.DBO.Entities.Accounting.AccountingDbo", b =>
                {
                    b.HasOne("PAccountant2.DAL.DBO.Entities.UserDbo", "User")
                        .WithOne("Accounting")
                        .HasForeignKey("PAccountant2.DAL.DBO.Entities.Accounting.AccountingDbo", "UserEmail");
                });

            modelBuilder.Entity("PAccountant2.DAL.DBO.Entities.Accounting.AccountingOptionsDbo", b =>
                {
                    b.HasOne("PAccountant2.DAL.DBO.Entities.Currency.CurrencyDbo", "AccountingBaseCurrency")
                        .WithMany("AccountingOptions")
                        .HasForeignKey("AccountingBaseCurrencyId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("PAccountant2.DAL.DBO.Entities.Accounting.AccountingDbo", "Accounting")
                        .WithOne("Options")
                        .HasForeignKey("PAccountant2.DAL.DBO.Entities.Accounting.AccountingOptionsDbo", "AccountingId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("PAccountant2.DAL.DBO.Entities.ContragentDbo", b =>
                {
                    b.HasOne("PAccountant2.DAL.DBO.Entities.Accounting.AccountingDbo", "Accounting")
                        .WithMany()
                        .HasForeignKey("AccountingId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("PAccountant2.DAL.DBO.Entities.Credit.CreditDbo", b =>
                {
                    b.HasOne("PAccountant2.DAL.DBO.Entities.Accounting.AccountingDbo", "Accounting")
                        .WithMany("Credits")
                        .HasForeignKey("AccountingId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("PAccountant2.DAL.DBO.Entities.Credit.CreditOperationDbo", b =>
                {
                    b.HasOne("PAccountant2.DAL.DBO.Entities.ContragentDbo", "Contragent")
                        .WithMany("CreditOperations")
                        .HasForeignKey("ContragentId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("PAccountant2.DAL.DBO.Entities.Credit.CreditDbo", "Credit")
                        .WithMany("Operations")
                        .HasForeignKey("CreditId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("PAccountant2.DAL.DBO.Entities.Currency.CurrencyDbo", "Currency")
                        .WithMany("CreditOperations")
                        .HasForeignKey("CurrencyId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("PAccountant2.DAL.DBO.Entities.Currency.ExchangeRateDbo", b =>
                {
                    b.HasOne("PAccountant2.DAL.DBO.Entities.Currency.CurrencyDbo", "BaseCurrency")
                        .WithMany("BaseCurrenciesRates")
                        .HasForeignKey("BaseCurrencyId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("PAccountant2.DAL.DBO.Entities.Currency.CurrencyDbo", "ResultCurrency")
                        .WithMany("ResultCurrenciesRates")
                        .HasForeignKey("ResultCurrencyId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("PAccountant2.DAL.DBO.Entities.Investment.InvestmentDbo", b =>
                {
                    b.HasOne("PAccountant2.DAL.DBO.Entities.Accounting.AccountingDbo", "Accounting")
                        .WithMany("Investments")
                        .HasForeignKey("AccountingId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("PAccountant2.DAL.DBO.Entities.Currency.CurrencyDbo", "Currency")
                        .WithMany("Investments")
                        .HasForeignKey("CurrencyId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("PAccountant2.DAL.DBO.Entities.Investment.InvestmentOperationDbo", b =>
                {
                    b.HasOne("PAccountant2.DAL.DBO.Entities.ContragentDbo")
                        .WithMany("InvestmentOperations")
                        .HasForeignKey("ContragentDboId");

                    b.HasOne("PAccountant2.DAL.DBO.Entities.Currency.CurrencyDbo", "Currency")
                        .WithMany("InvestmentOperations")
                        .HasForeignKey("CurrencyId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("PAccountant2.DAL.DBO.Entities.Investment.InvestmentDbo", "Investment")
                        .WithMany("Operations")
                        .HasForeignKey("InvestmentId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}

﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using NMMSystem.Data.Domein;

#nullable disable

namespace NMMSystem.Data.Domein.Migrations
{
    [DbContext(typeof(Context))]
    partial class ContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("NMMSystem.Data.Domein.AddressInfo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("AddressType")
                        .HasColumnType("int");

                    b.Property<int>("SupplierId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("SupplierId");

                    b.ToTable("AddressInfo");
                });

            modelBuilder.Entity("NMMSystem.Data.Domein.ContactInformation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ContactInfo")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("ContactInformationType")
                        .HasColumnType("int");

                    b.Property<int>("SupplierId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("SupplierId");

                    b.ToTable("ContactInformation");
                });

            modelBuilder.Entity("NMMSystem.Data.Domein.Data.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("BarCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("UnitPrice")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.ToTable("Product");
                });

            modelBuilder.Entity("NMMSystem.Data.Domein.Data.SupplierBonusSpecificTime", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<decimal>("Bonus")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("DateTimeFrom")
                        .HasColumnType("Date");

                    b.Property<DateTime>("DateTimeTo")
                        .HasColumnType("Date");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SupplierId")
                        .HasColumnType("int");

                    b.Property<string>("Surname")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("SupplierId");

                    b.ToTable("SupplierBonusSpecificTime");
                });

            modelBuilder.Entity("NMMSystem.Data.Domein.Data.SupplierRecomendators", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("RecommendedSupplierId")
                        .HasColumnType("int");

                    b.Property<int>("RecommenderSupplierId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RecommendedSupplierId");

                    b.HasIndex("RecommenderSupplierId");

                    b.ToTable("SupplierRecomendators");
                });

            modelBuilder.Entity("NMMSystem.Data.Domein.Data.SupplierSale", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<decimal>("ProductPrise")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("SaleTime")
                        .HasColumnType("Date");

                    b.Property<int>("SupplierId")
                        .HasColumnType("int");

                    b.Property<decimal>("TotalPrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("UnitPrice")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.HasIndex("SupplierId");

                    b.ToTable("SupplierSale");
                });

            modelBuilder.Entity("NMMSystem.Data.Domein.PrivateInformation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("DateExpiry")
                        .HasColumnType("Date");

                    b.Property<DateTime>("DateIssue")
                        .HasColumnType("Date");

                    b.Property<int>("DocumenType")
                        .HasColumnType("int");

                    b.Property<string>("DocumentNumber")
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<string>("IssuingAutority")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("PrivateNumber")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("SerialNumber")
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<int>("SupplierId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("SupplierId");

                    b.ToTable("PrivateInformation");
                });

            modelBuilder.Entity("NMMSystem.Data.Domein.Supplier", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("Date");

                    b.Property<int>("Gender")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Picture")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SurName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Supplier");
                });

            modelBuilder.Entity("NMMSystem.Data.Domein.AddressInfo", b =>
                {
                    b.HasOne("NMMSystem.Data.Domein.Supplier", "Supplier")
                        .WithMany("AddressInfromations")
                        .HasForeignKey("SupplierId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Supplier");
                });

            modelBuilder.Entity("NMMSystem.Data.Domein.ContactInformation", b =>
                {
                    b.HasOne("NMMSystem.Data.Domein.Supplier", "Supplier")
                        .WithMany("ContactInfromations")
                        .HasForeignKey("SupplierId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Supplier");
                });

            modelBuilder.Entity("NMMSystem.Data.Domein.Data.SupplierBonusSpecificTime", b =>
                {
                    b.HasOne("NMMSystem.Data.Domein.Supplier", "Supplier")
                        .WithMany("SupplierBonusSpecificTime")
                        .HasForeignKey("SupplierId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Supplier");
                });

            modelBuilder.Entity("NMMSystem.Data.Domein.Data.SupplierRecomendators", b =>
                {
                    b.HasOne("NMMSystem.Data.Domein.Supplier", "RecommendedSupplier")
                        .WithMany()
                        .HasForeignKey("RecommendedSupplierId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("NMMSystem.Data.Domein.Supplier", "RecommenderSupplier")
                        .WithMany("RecommendedSupplier")
                        .HasForeignKey("RecommenderSupplierId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("RecommendedSupplier");

                    b.Navigation("RecommenderSupplier");
                });

            modelBuilder.Entity("NMMSystem.Data.Domein.Data.SupplierSale", b =>
                {
                    b.HasOne("NMMSystem.Data.Domein.Data.Product", "Product")
                        .WithMany("SupplierSale")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("NMMSystem.Data.Domein.Supplier", "Supplier")
                        .WithMany("SupplierSale")
                        .HasForeignKey("SupplierId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");

                    b.Navigation("Supplier");
                });

            modelBuilder.Entity("NMMSystem.Data.Domein.PrivateInformation", b =>
                {
                    b.HasOne("NMMSystem.Data.Domein.Supplier", "Supplier")
                        .WithMany("PrivateInfromations")
                        .HasForeignKey("SupplierId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Supplier");
                });

            modelBuilder.Entity("NMMSystem.Data.Domein.Data.Product", b =>
                {
                    b.Navigation("SupplierSale");
                });

            modelBuilder.Entity("NMMSystem.Data.Domein.Supplier", b =>
                {
                    b.Navigation("AddressInfromations");

                    b.Navigation("ContactInfromations");

                    b.Navigation("PrivateInfromations");

                    b.Navigation("RecommendedSupplier");

                    b.Navigation("SupplierBonusSpecificTime");

                    b.Navigation("SupplierSale");
                });
#pragma warning restore 612, 618
        }
    }
}

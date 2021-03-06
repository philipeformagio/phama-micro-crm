﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PhamaMicroCrm.Data.Context;

namespace PhamaMicroCrm.Data.Migrations
{
    [DbContext(typeof(PhamaMicroCrmContext))]
    [Migration("20200711232352_PhoneVarchar12")]
    partial class PhoneVarchar12
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("PhamaMicroCrm.Model.Entities.Address", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("City")
                        .HasColumnType("varchar(50)");

                    b.Property<Guid>("CompanyUnitId");

                    b.Property<DateTime>("CreatedAt");

                    b.Property<string>("State")
                        .HasColumnType("varchar(15)");

                    b.Property<string>("Street")
                        .HasColumnType("varchar(200)");

                    b.Property<string>("ZipCode")
                        .HasColumnType("varchar(8)");

                    b.HasKey("Id");

                    b.HasIndex("CompanyUnitId")
                        .IsUnique();

                    b.ToTable("Addresses");
                });

            modelBuilder.Entity("PhamaMicroCrm.Model.Entities.Company", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("Active");

                    b.Property<DateTime>("CreatedAt");

                    b.Property<string>("Field")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(200)");

                    b.Property<string>("Phone")
                        .HasColumnType("varchar(12)");

                    b.HasKey("Id");

                    b.ToTable("Companies");
                });

            modelBuilder.Entity("PhamaMicroCrm.Model.Entities.CompanyUnit", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("Active");

                    b.Property<Guid>("CompanyId");

                    b.Property<DateTime>("CreatedAt");

                    b.Property<string>("Name")
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Phone_1")
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Phone_2")
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Phone_3")
                        .HasColumnType("varchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("CompanyId");

                    b.ToTable("CompanyUnits");
                });

            modelBuilder.Entity("PhamaMicroCrm.Model.Entities.Contact", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid>("CompanyUnitId");

                    b.Property<DateTime>("CreatedAt");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Phone_1")
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Phone_2")
                        .HasColumnType("varchar(100)");

                    b.HasKey("Id");

                    b.HasIndex("CompanyUnitId");

                    b.ToTable("Contacts");
                });

            modelBuilder.Entity("PhamaMicroCrm.Model.Entities.Address", b =>
                {
                    b.HasOne("PhamaMicroCrm.Model.Entities.CompanyUnit", "CompanyUnit")
                        .WithOne("Address")
                        .HasForeignKey("PhamaMicroCrm.Model.Entities.Address", "CompanyUnitId");
                });

            modelBuilder.Entity("PhamaMicroCrm.Model.Entities.CompanyUnit", b =>
                {
                    b.HasOne("PhamaMicroCrm.Model.Entities.Company", "Company")
                        .WithMany("CompanyUnits")
                        .HasForeignKey("CompanyId");
                });

            modelBuilder.Entity("PhamaMicroCrm.Model.Entities.Contact", b =>
                {
                    b.HasOne("PhamaMicroCrm.Model.Entities.CompanyUnit", "CompanyUnit")
                        .WithMany("Contacts")
                        .HasForeignKey("CompanyUnitId");
                });
#pragma warning restore 612, 618
        }
    }
}

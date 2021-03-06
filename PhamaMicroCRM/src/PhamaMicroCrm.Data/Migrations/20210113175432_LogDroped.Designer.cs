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
    [Migration("20210113175432_LogDroped")]
    partial class LogDroped
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("PhamaMicroCrm.Model.Entities.Address", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("City")
                        .HasColumnType("varchar(50)");

                    b.Property<Guid>("CompanyUnitId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

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
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("Active")
                        .HasColumnType("bit");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

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
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("Active")
                        .HasColumnType("bit");

                    b.Property<Guid>("CompanyId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

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
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CompanyUnitId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

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

            modelBuilder.Entity("PhamaMicroCrm.Model.Entities.Note", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CompanyId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasColumnType("varchar(500)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("CompanyId");

                    b.ToTable("Notes");
                });

            modelBuilder.Entity("PhamaMicroCrm.Model.Entities.Address", b =>
                {
                    b.HasOne("PhamaMicroCrm.Model.Entities.CompanyUnit", "CompanyUnit")
                        .WithOne("Address")
                        .HasForeignKey("PhamaMicroCrm.Model.Entities.Address", "CompanyUnitId")
                        .IsRequired();
                });

            modelBuilder.Entity("PhamaMicroCrm.Model.Entities.CompanyUnit", b =>
                {
                    b.HasOne("PhamaMicroCrm.Model.Entities.Company", "Company")
                        .WithMany("CompanyUnits")
                        .HasForeignKey("CompanyId")
                        .IsRequired();
                });

            modelBuilder.Entity("PhamaMicroCrm.Model.Entities.Contact", b =>
                {
                    b.HasOne("PhamaMicroCrm.Model.Entities.CompanyUnit", "CompanyUnit")
                        .WithMany("Contacts")
                        .HasForeignKey("CompanyUnitId")
                        .IsRequired();
                });

            modelBuilder.Entity("PhamaMicroCrm.Model.Entities.Note", b =>
                {
                    b.HasOne("PhamaMicroCrm.Model.Entities.Company", "Company")
                        .WithMany("Notes")
                        .HasForeignKey("CompanyId")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}

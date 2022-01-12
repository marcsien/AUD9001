﻿// <auto-generated />
using System;
using AUD9001.DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace AUD9001.DataAccess.Migrations
{
    [DbContext(typeof(AUD9001StorageContext))]
    [Migration("20220111183911_TestmigrationJan11")]
    partial class TestmigrationJan11
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.3")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("AUD9001.DataAccess.Entities.AcceptanceCriteria", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("TargetId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TargetId");

                    b.ToTable("AcceptanceCriteria");
                });

            modelBuilder.Entity("AUD9001.DataAccess.Entities.Attachment", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DeleteDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("FileName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FilePath")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ProcessRequirementId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ProcessRequirementId");

                    b.ToTable("Attachment");
                });

            modelBuilder.Entity("AUD9001.DataAccess.Entities.Company", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Owner")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Company");
                });

            modelBuilder.Entity("AUD9001.DataAccess.Entities.Input", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("AdditionDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DeleteDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Input");
                });

            modelBuilder.Entity("AUD9001.DataAccess.Entities.Output", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("AdditionDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DeleteDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Output");
                });

            modelBuilder.Entity("AUD9001.DataAccess.Entities.Process", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CompanyId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("ProcessDeputyLiderId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProcessLiderId")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CompanyId");

                    b.ToTable("Processes");
                });

            modelBuilder.Entity("AUD9001.DataAccess.Entities.ProcessRequirement", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ProcessId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ProcessId");

                    b.ToTable("ProcessRequirement");
                });

            modelBuilder.Entity("AUD9001.DataAccess.Entities.Resource", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DeleteDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("TypeId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TypeId");

                    b.ToTable("Resources");
                });

            modelBuilder.Entity("AUD9001.DataAccess.Entities.ResourceType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("ResourceType");
                });

            modelBuilder.Entity("AUD9001.DataAccess.Entities.Target", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DeadlineDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int?>("ProcessId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ProcessId");

                    b.ToTable("Target");
                });

            modelBuilder.Entity("InputProcess", b =>
                {
                    b.Property<int>("InputsId")
                        .HasColumnType("int");

                    b.Property<int>("ProcessesId")
                        .HasColumnType("int");

                    b.HasKey("InputsId", "ProcessesId");

                    b.HasIndex("ProcessesId");

                    b.ToTable("InputProcess");
                });

            modelBuilder.Entity("OutputProcess", b =>
                {
                    b.Property<int>("OutputsId")
                        .HasColumnType("int");

                    b.Property<int>("ProcessesId")
                        .HasColumnType("int");

                    b.HasKey("OutputsId", "ProcessesId");

                    b.HasIndex("ProcessesId");

                    b.ToTable("OutputProcess");
                });

            modelBuilder.Entity("ProcessResource", b =>
                {
                    b.Property<int>("ProcessesId")
                        .HasColumnType("int");

                    b.Property<int>("ResourcesId")
                        .HasColumnType("int");

                    b.HasKey("ProcessesId", "ResourcesId");

                    b.HasIndex("ResourcesId");

                    b.ToTable("ProcessResource");
                });

            modelBuilder.Entity("AUD9001.DataAccess.Entities.AcceptanceCriteria", b =>
                {
                    b.HasOne("AUD9001.DataAccess.Entities.Target", null)
                        .WithMany("AcceptanceCriterias")
                        .HasForeignKey("TargetId");
                });

            modelBuilder.Entity("AUD9001.DataAccess.Entities.Attachment", b =>
                {
                    b.HasOne("AUD9001.DataAccess.Entities.ProcessRequirement", null)
                        .WithMany("Attachments")
                        .HasForeignKey("ProcessRequirementId");
                });

            modelBuilder.Entity("AUD9001.DataAccess.Entities.Process", b =>
                {
                    b.HasOne("AUD9001.DataAccess.Entities.Company", "Company")
                        .WithMany()
                        .HasForeignKey("CompanyId");

                    b.Navigation("Company");
                });

            modelBuilder.Entity("AUD9001.DataAccess.Entities.ProcessRequirement", b =>
                {
                    b.HasOne("AUD9001.DataAccess.Entities.Process", null)
                        .WithMany("Requirements")
                        .HasForeignKey("ProcessId");
                });

            modelBuilder.Entity("AUD9001.DataAccess.Entities.Resource", b =>
                {
                    b.HasOne("AUD9001.DataAccess.Entities.ResourceType", "Type")
                        .WithMany()
                        .HasForeignKey("TypeId");

                    b.Navigation("Type");
                });

            modelBuilder.Entity("AUD9001.DataAccess.Entities.Target", b =>
                {
                    b.HasOne("AUD9001.DataAccess.Entities.Process", null)
                        .WithMany("Targets")
                        .HasForeignKey("ProcessId");
                });

            modelBuilder.Entity("InputProcess", b =>
                {
                    b.HasOne("AUD9001.DataAccess.Entities.Input", null)
                        .WithMany()
                        .HasForeignKey("InputsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AUD9001.DataAccess.Entities.Process", null)
                        .WithMany()
                        .HasForeignKey("ProcessesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("OutputProcess", b =>
                {
                    b.HasOne("AUD9001.DataAccess.Entities.Output", null)
                        .WithMany()
                        .HasForeignKey("OutputsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AUD9001.DataAccess.Entities.Process", null)
                        .WithMany()
                        .HasForeignKey("ProcessesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ProcessResource", b =>
                {
                    b.HasOne("AUD9001.DataAccess.Entities.Process", null)
                        .WithMany()
                        .HasForeignKey("ProcessesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AUD9001.DataAccess.Entities.Resource", null)
                        .WithMany()
                        .HasForeignKey("ResourcesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("AUD9001.DataAccess.Entities.Process", b =>
                {
                    b.Navigation("Requirements");

                    b.Navigation("Targets");
                });

            modelBuilder.Entity("AUD9001.DataAccess.Entities.ProcessRequirement", b =>
                {
                    b.Navigation("Attachments");
                });

            modelBuilder.Entity("AUD9001.DataAccess.Entities.Target", b =>
                {
                    b.Navigation("AcceptanceCriterias");
                });
#pragma warning restore 612, 618
        }
    }
}
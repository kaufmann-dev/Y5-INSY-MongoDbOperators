﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Model.Configurations;

#nullable disable

namespace Model.Migrations
{
    [DbContext(typeof(OperatorDbContext))]
    [Migration("20230410185820_migger4")]
    partial class migger4
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Model.Entities.CodeExample", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("CODE_EXAMPLE_ID");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("CODE");

                    b.HasKey("Id");

                    b.ToTable("CODE_EXAMPLES_ST");
                });

            modelBuilder.Entity("Model.Entities.Operator", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("OPERATOR_ID");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(10000)
                        .HasColumnType("text")
                        .HasColumnName("DESCRIPTION");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(45)
                        .HasColumnType("varchar(45)")
                        .HasColumnName("NAME");

                    b.Property<string>("ShortDescription")
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("SHORT_DESCRIPTION");

                    b.Property<string>("Syntax")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("SYNTAX");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("OPERATORS_BT");

                    b.UseTptMappingStrategy();
                });

            modelBuilder.Entity("Model.Entities.OperatorCodeExamples", b =>
                {
                    b.Property<int>("OperatorId")
                        .HasColumnType("int")
                        .HasColumnName("OPERATOR_ID");

                    b.Property<int>("CodeExampleId")
                        .HasColumnType("int")
                        .HasColumnName("CODE_EXAMPLE_ID");

                    b.HasKey("OperatorId", "CodeExampleId");

                    b.HasIndex("CodeExampleId");

                    b.ToTable("OPERATOR_HAS_CODE_EXAMPLES");
                });

            modelBuilder.Entity("Model.Entities.AggregationOperator", b =>
                {
                    b.HasBaseType("Model.Entities.Operator");

                    b.Property<int>("Type")
                        .HasColumnType("int")
                        .HasColumnName("TYPE");

                    b.ToTable("AGGREGATION_OPERATORS_ST");
                });

            modelBuilder.Entity("Model.Entities.AggregationStage", b =>
                {
                    b.HasBaseType("Model.Entities.Operator");

                    b.ToTable("AGGREGATION_STAGES_ST");
                });

            modelBuilder.Entity("Model.Entities.OperatorCodeExamples", b =>
                {
                    b.HasOne("Model.Entities.CodeExample", "CodeExample")
                        .WithMany()
                        .HasForeignKey("CodeExampleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Model.Entities.Operator", "Operator")
                        .WithMany("CodeExamples")
                        .HasForeignKey("OperatorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CodeExample");

                    b.Navigation("Operator");
                });

            modelBuilder.Entity("Model.Entities.AggregationOperator", b =>
                {
                    b.HasOne("Model.Entities.Operator", null)
                        .WithOne()
                        .HasForeignKey("Model.Entities.AggregationOperator", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Model.Entities.AggregationStage", b =>
                {
                    b.HasOne("Model.Entities.Operator", null)
                        .WithOne()
                        .HasForeignKey("Model.Entities.AggregationStage", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Model.Entities.Operator", b =>
                {
                    b.Navigation("CodeExamples");
                });
#pragma warning restore 612, 618
        }
    }
}

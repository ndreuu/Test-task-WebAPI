﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TestTaskSolution.Data;

#nullable disable

namespace TestTaskSolution.Migrations
{
    [DbContext(typeof(APIDbContext))]
    partial class APIDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("TestTaskSolution.Models.Result", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<double>("AvarageIndex")
                        .HasColumnType("float");

                    b.Property<double>("AvarageTime")
                        .HasColumnType("float");

                    b.Property<int>("CountOfRecords")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateFirstOperation")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("DeltaTime")
                        .HasColumnType("decimal(20,0)");

                    b.Property<string>("FileName")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<double>("MaxIndex")
                        .HasColumnType("float");

                    b.Property<double>("MedianIndex")
                        .HasColumnType("float");

                    b.Property<double>("MinIndex")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("AvarageIndex");

                    b.HasIndex("AvarageTime");

                    b.HasIndex("DateFirstOperation");

                    b.HasIndex("FileName");

                    b.ToTable("Results");
                });

            modelBuilder.Entity("TestTaskSolution.Models.Value", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("FileName")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<double>("Index")
                        .HasColumnType("float");

                    b.Property<decimal>("Time")
                        .HasColumnType("decimal(20,0)");

                    b.HasKey("Id");

                    b.HasIndex("FileName");

                    b.ToTable("Values");
                });
#pragma warning restore 612, 618
        }
    }
}

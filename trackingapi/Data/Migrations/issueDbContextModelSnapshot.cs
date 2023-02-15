﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using trackingapi.Data;

#nullable disable

namespace trackingapi.Data.Migrations
{
    [DbContext(typeof(issueDbContext))]
    partial class issueDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("trackingapi.Model.issue", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<DateTime?>("completed")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("created")
                        .HasColumnType("datetime2");

                    b.Property<string>("issueDescription")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("issueName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("issueType")
                        .HasColumnType("int");

                    b.Property<int>("priority")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.ToTable("Issues");
                });
#pragma warning restore 612, 618
        }
    }
}

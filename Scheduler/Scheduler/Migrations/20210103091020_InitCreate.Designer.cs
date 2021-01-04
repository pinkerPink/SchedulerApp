﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Scheduler.Models;

namespace Scheduler.Migrations
{
    [DbContext(typeof(TaskDetailContext))]
    [Migration("20210103091020_InitCreate")]
    partial class InitCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.1");

            modelBuilder.Entity("Scheduler.Models.TaskDetail", b =>
                {
                    b.Property<int>("TaskDetailId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("TaskDescription")
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("TaskDetailId");

                    b.ToTable("TaskDetails");
                });
#pragma warning restore 612, 618
        }
    }
}

﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;
using vs_web_mvc.Models;

namespace vswebmvc.Migrations
{
    [DbContext(typeof(ToDoContext))]
    partial class ToDoContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.1-rtm-125")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("vs_web_mvc.Models.Schedule", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("PrivateSchedule");

                    b.Property<long>("PrivateScheduleSize");

                    b.Property<string>("PublicSchedule");

                    b.Property<long>("PublicScheduleSize");

                    b.Property<string>("Title");

                    b.Property<DateTime>("UploadDT");

                    b.HasKey("ID");

                    b.ToTable("Schedule");
                });

            modelBuilder.Entity("vs_web_mvc.Models.ToDoItem", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Category");

                    b.Property<string>("Description");

                    b.Property<decimal>("EstimatedHour");

                    b.Property<DateTime>("ModifiedOn");

                    b.Property<string>("Title");

                    b.HasKey("ID");

                    b.ToTable("ToDoItem");
                });
#pragma warning restore 612, 618
        }
    }
}

﻿// <auto-generated />
using AngularFullCRUD.DataHelpers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace AngularFullCRUD.Migrations
{
    [DbContext(typeof(MyDbContext))]
    partial class MyDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.3");

            modelBuilder.Entity("AngularFullCRUD.DataHelpers.Product", b =>
                {
                    b.Property<int>("ProduceID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<int>("Price")
                        .HasColumnType("INTEGER");

                    b.HasKey("ProduceID");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            ProduceID = 1,
                            Description = "Oranges",
                            Price = 4
                        },
                        new
                        {
                            ProduceID = 2,
                            Description = "Apples",
                            Price = 3
                        },
                        new
                        {
                            ProduceID = 3,
                            Description = "Pears",
                            Price = 5
                        });
                });
#pragma warning restore 612, 618
        }
    }
}

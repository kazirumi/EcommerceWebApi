﻿// <auto-generated />
using AngularAndAsp.NetCoreWebApiEcommerce;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace AngularAndAsp.NetCoreWebApiEcommerce.Migrations
{
    [DbContext(typeof(ApplicationDBContext))]
    [Migration("20201110022033_ProductTable")]
    partial class ProductTable
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("AngularAndAsp.NetCoreWebApiEcommerce.Models.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description");

                    b.Property<string>("Image");

                    b.Property<bool>("IsAvailable");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<string>("ProductColor")
                        .IsRequired();

                    b.Property<int>("ProductTypeId");

                    b.Property<int>("Quantity");

                    b.Property<int>("QuantityTypeID");

                    b.Property<int>("SpecialTagId");

                    b.Property<decimal>("price");

                    b.HasKey("Id");

                    b.HasIndex("ProductTypeId");

                    b.HasIndex("QuantityTypeID");

                    b.HasIndex("SpecialTagId");

                    b.ToTable("Product");
                });

            modelBuilder.Entity("AngularAndAsp.NetCoreWebApiEcommerce.Models.ProductType", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ProductTypeName")
                        .IsRequired();

                    b.HasKey("ID");

                    b.ToTable("ProductTypes");
                });

            modelBuilder.Entity("AngularAndAsp.NetCoreWebApiEcommerce.Models.QuantityType", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("SpecialTagName")
                        .IsRequired();

                    b.HasKey("ID");

                    b.ToTable("QuantityType");
                });

            modelBuilder.Entity("AngularAndAsp.NetCoreWebApiEcommerce.Models.SpecialTag", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("SpecialTagName")
                        .IsRequired();

                    b.HasKey("ID");

                    b.ToTable("SpecialTag");
                });

            modelBuilder.Entity("AngularAndAsp.NetCoreWebApiEcommerce.Models.Product", b =>
                {
                    b.HasOne("AngularAndAsp.NetCoreWebApiEcommerce.Models.ProductType", "producttype")
                        .WithMany()
                        .HasForeignKey("ProductTypeId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("AngularAndAsp.NetCoreWebApiEcommerce.Models.QuantityType", "QuantityType")
                        .WithMany()
                        .HasForeignKey("QuantityTypeID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("AngularAndAsp.NetCoreWebApiEcommerce.Models.SpecialTag", "SpecialTag")
                        .WithMany()
                        .HasForeignKey("SpecialTagId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}

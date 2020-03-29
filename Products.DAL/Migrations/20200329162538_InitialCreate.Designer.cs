﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Products.DAL;

namespace Products.DAL.Migrations
{
    [DbContext(typeof(ProductsContext))]
    [Migration("20200329162538_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.14-servicing-32113")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Products.Models.DataStore.Item", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .IsRequired();

                    b.Property<int>("SellerId");

                    b.HasKey("Id");

                    b.HasIndex("SellerId");

                    b.ToTable("Items");

                    b.HasData(
                        new { Id = 1, Description = "My first thing", SellerId = 1 },
                        new { Id = 2, Description = "My second thing", SellerId = 1 },
                        new { Id = 3, Description = "His only thing", SellerId = 2 }
                    );
                });

            modelBuilder.Entity("Products.Models.DataStore.Seller", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("Sellers");

                    b.HasData(
                        new { Id = 1, Name = "Me" },
                        new { Id = 2, Name = "Him" }
                    );
                });

            modelBuilder.Entity("Products.Models.DataStore.Item", b =>
                {
                    b.HasOne("Products.Models.DataStore.Seller", "Seller")
                        .WithMany("Items")
                        .HasForeignKey("SellerId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}

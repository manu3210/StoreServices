﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using StoreServices.Api.ShoppingCart.Persistance;

#nullable disable

namespace StoreServices.Api.ShoppingCart.Migrations
{
    [DbContext(typeof(CartContext))]
    partial class CartContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0-preview.2.22153.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("StoreServices.Api.ShoppingCart.Model.CartDetail", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("CartSessionId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("SelectedProduct")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CartSessionId");

                    b.ToTable("CartDetails");
                });

            modelBuilder.Entity("StoreServices.Api.ShoppingCart.Model.CartSession", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime?>("Date")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("CartSessions");
                });

            modelBuilder.Entity("StoreServices.Api.ShoppingCart.Model.CartDetail", b =>
                {
                    b.HasOne("StoreServices.Api.ShoppingCart.Model.CartSession", null)
                        .WithMany("CartDetails")
                        .HasForeignKey("CartSessionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("StoreServices.Api.ShoppingCart.Model.CartSession", b =>
                {
                    b.Navigation("CartDetails");
                });
#pragma warning restore 612, 618
        }
    }
}

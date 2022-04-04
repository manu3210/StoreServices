﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using StoreServices.Api.Author.Persistance;

#nullable disable

namespace StoreServices.Api.Author.Migrations
{
    [DbContext(typeof(AuthorContext))]
    [Migration("20220331174441_MigrationPostgressFirst")]
    partial class MigrationPostgressFirst
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0-preview.2.22153.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("StoreServices.Api.Author.Model.AcademyLevel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("AcademyLevelGuid")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("BookAuthorId")
                        .HasColumnType("integer");

                    b.Property<DateTime?>("GradeDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Institute")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("BookAuthorId");

                    b.ToTable("AcademyLevels");
                });

            modelBuilder.Entity("StoreServices.Api.Author.Model.BookAuthor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("BookAuthorGuid")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime?>("DateOfBirth")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("BookAuthors");
                });

            modelBuilder.Entity("StoreServices.Api.Author.Model.AcademyLevel", b =>
                {
                    b.HasOne("StoreServices.Api.Author.Model.BookAuthor", "BookAuthor")
                        .WithMany("AcademyLevels")
                        .HasForeignKey("BookAuthorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("BookAuthor");
                });

            modelBuilder.Entity("StoreServices.Api.Author.Model.BookAuthor", b =>
                {
                    b.Navigation("AcademyLevels");
                });
#pragma warning restore 612, 618
        }
    }
}

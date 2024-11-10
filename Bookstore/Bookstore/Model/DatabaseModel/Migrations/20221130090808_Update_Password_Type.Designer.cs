﻿// <auto-generated />
using System;
using Bookstore.Model.DatabaseModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Bookstore.Model.DatabaseModel.Migrations
{
    [DbContext(typeof(BookstoreDbContext))]
    [Migration("20221130090808_Update_Password_Type")]
    partial class Update_Password_Type
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.10");

            modelBuilder.Entity("AuthorBook", b =>
                {
                    b.Property<int>("AuthorsId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("BooksId")
                        .HasColumnType("INTEGER");

                    b.HasKey("AuthorsId", "BooksId");

                    b.HasIndex("BooksId");

                    b.ToTable("AuthorBook");
                });

            modelBuilder.Entity("Bookstore.Model.DatabaseModel.Article", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("Amount")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<double>("Price")
                        .HasColumnType("REAL");

                    b.HasKey("Id");

                    b.ToTable("Articles");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Article");
                });

            modelBuilder.Entity("Bookstore.Model.DatabaseModel.Author", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Authors");
                });

            modelBuilder.Entity("Bookstore.Model.DatabaseModel.Bill", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("DateTimeOfPurchase")
                        .HasColumnType("TEXT");

                    b.Property<int>("EmployeeId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("EmployeeId");

                    b.ToTable("Bills");
                });

            modelBuilder.Entity("Bookstore.Model.DatabaseModel.BillItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("Amount")
                        .HasColumnType("INTEGER");

                    b.Property<int>("ArticleId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("BillId")
                        .HasColumnType("INTEGER");

                    b.Property<double>("Price")
                        .HasColumnType("REAL");

                    b.HasKey("Id");

                    b.HasIndex("ArticleId");

                    b.HasIndex("BillId");

                    b.ToTable("BillItems");
                });

            modelBuilder.Entity("Bookstore.Model.DatabaseModel.Employee", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<bool>("IsAdmin")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("UIN")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("Bookstore.Model.DatabaseModel.Language", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Languages");
                });

            modelBuilder.Entity("Bookstore.Model.DatabaseModel.Publisher", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Publishers");
                });

            modelBuilder.Entity("Bookstore.Model.DatabaseModel.Book", b =>
                {
                    b.HasBaseType("Bookstore.Model.DatabaseModel.Article");

                    b.Property<string>("ISBN")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("LanguageId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("PublisherId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("YearOfIssue")
                        .HasColumnType("INTEGER");

                    b.Property<int>("YearOfPublication")
                        .HasColumnType("INTEGER");

                    b.HasIndex("LanguageId");

                    b.HasIndex("PublisherId");

                    b.HasDiscriminator().HasValue("Book");
                });

            modelBuilder.Entity("AuthorBook", b =>
                {
                    b.HasOne("Bookstore.Model.DatabaseModel.Author", null)
                        .WithMany()
                        .HasForeignKey("AuthorsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Bookstore.Model.DatabaseModel.Book", null)
                        .WithMany()
                        .HasForeignKey("BooksId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Bookstore.Model.DatabaseModel.Bill", b =>
                {
                    b.HasOne("Bookstore.Model.DatabaseModel.Employee", "Employee")
                        .WithMany("Bills")
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Employee");
                });

            modelBuilder.Entity("Bookstore.Model.DatabaseModel.BillItem", b =>
                {
                    b.HasOne("Bookstore.Model.DatabaseModel.Article", "Article")
                        .WithMany("BillItems")
                        .HasForeignKey("ArticleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Bookstore.Model.DatabaseModel.Bill", "Bill")
                        .WithMany("BillItems")
                        .HasForeignKey("BillId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Article");

                    b.Navigation("Bill");
                });

            modelBuilder.Entity("Bookstore.Model.DatabaseModel.Book", b =>
                {
                    b.HasOne("Bookstore.Model.DatabaseModel.Language", "Language")
                        .WithMany("Books")
                        .HasForeignKey("LanguageId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Bookstore.Model.DatabaseModel.Publisher", "Publisher")
                        .WithMany("Books")
                        .HasForeignKey("PublisherId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Language");

                    b.Navigation("Publisher");
                });

            modelBuilder.Entity("Bookstore.Model.DatabaseModel.Article", b =>
                {
                    b.Navigation("BillItems");
                });

            modelBuilder.Entity("Bookstore.Model.DatabaseModel.Bill", b =>
                {
                    b.Navigation("BillItems");
                });

            modelBuilder.Entity("Bookstore.Model.DatabaseModel.Employee", b =>
                {
                    b.Navigation("Bills");
                });

            modelBuilder.Entity("Bookstore.Model.DatabaseModel.Language", b =>
                {
                    b.Navigation("Books");
                });

            modelBuilder.Entity("Bookstore.Model.DatabaseModel.Publisher", b =>
                {
                    b.Navigation("Books");
                });
#pragma warning restore 612, 618
        }
    }
}
﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using studentFreelance.Data;

#nullable disable

namespace studentFreelance.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20221014170239_initial")]
    partial class initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Name")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("studentFreelance.Models.Booking", b =>
                {
                    b.Property<int>("booking_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("booking_Id"), 1L, 1);

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Id")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("amount")
                        .HasColumnType("int");

                    b.Property<bool>("payment_status")
                        .HasColumnType("bit");

                    b.Property<int>("product_id")
                        .HasColumnType("int");

                    b.Property<int?>("productsproductid")
                        .HasColumnType("int");

                    b.Property<int>("quantity")
                        .HasColumnType("int");

                    b.Property<bool>("type")
                        .HasColumnType("bit");

                    b.HasKey("booking_Id");

                    b.HasIndex("productsproductid");

                    b.ToTable("Bookings");
                });

            modelBuilder.Entity("studentFreelance.Models.Products", b =>
                {
                    b.Property<int>("productid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("productid"), 1L, 1);

                    b.Property<int>("amount")
                        .HasColumnType("int");

                    b.Property<string>("image")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("productDesc")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("productnamec")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)");

                    b.Property<int>("quantity")
                        .HasColumnType("int");

                    b.HasKey("productid");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("studentFreelance.Models.spoorts", b =>
                {
                    b.Property<string>("sportts")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("sport_img")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("venue_name")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("sportts");

                    b.HasIndex("venue_name");

                    b.ToTable("spoorts");
                });

            modelBuilder.Entity("studentFreelance.Models.sports", b =>
                {
                    b.Property<int>("sports_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("sports_Id"), 1L, 1);

                    b.Property<int>("amount")
                        .HasColumnType("int");

                    b.Property<string>("slot_name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("sportts")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("userid")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("venue_name")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("sports_Id");

                    b.HasIndex("sportts");

                    b.HasIndex("venue_name");

                    b.ToTable("sports");
                });

            modelBuilder.Entity("studentFreelance.Models.timming", b =>
                {
                    b.Property<int>("t_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("t_Id"), 1L, 1);

                    b.Property<bool>("s1")
                        .HasColumnType("bit");

                    b.Property<bool>("s10")
                        .HasColumnType("bit");

                    b.Property<bool>("s11")
                        .HasColumnType("bit");

                    b.Property<bool>("s12")
                        .HasColumnType("bit");

                    b.Property<bool>("s13")
                        .HasColumnType("bit");

                    b.Property<bool>("s14")
                        .HasColumnType("bit");

                    b.Property<bool>("s15")
                        .HasColumnType("bit");

                    b.Property<bool>("s16")
                        .HasColumnType("bit");

                    b.Property<bool>("s17")
                        .HasColumnType("bit");

                    b.Property<bool>("s18")
                        .HasColumnType("bit");

                    b.Property<bool>("s19")
                        .HasColumnType("bit");

                    b.Property<bool>("s2")
                        .HasColumnType("bit");

                    b.Property<bool>("s3")
                        .HasColumnType("bit");

                    b.Property<bool>("s4")
                        .HasColumnType("bit");

                    b.Property<bool>("s5")
                        .HasColumnType("bit");

                    b.Property<bool>("s6")
                        .HasColumnType("bit");

                    b.Property<bool>("s7")
                        .HasColumnType("bit");

                    b.Property<bool>("s8")
                        .HasColumnType("bit");

                    b.Property<bool>("s9")
                        .HasColumnType("bit");

                    b.Property<DateTime>("s_date")
                        .HasColumnType("datetime2");

                    b.Property<int?>("sports_Id")
                        .HasColumnType("int");

                    b.HasKey("t_Id");

                    b.HasIndex("sports_Id");

                    b.ToTable("timmings");
                });

            modelBuilder.Entity("studentFreelance.Models.venue", b =>
                {
                    b.Property<string>("venue_name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Id")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("venue_desc")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("venue_location")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("venue_pic")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("venue_name");

                    b.ToTable("venue");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("studentFreelance.Models.Booking", b =>
                {
                    b.HasOne("studentFreelance.Models.Products", "products")
                        .WithMany()
                        .HasForeignKey("productsproductid");

                    b.Navigation("products");
                });

            modelBuilder.Entity("studentFreelance.Models.spoorts", b =>
                {
                    b.HasOne("studentFreelance.Models.venue", null)
                        .WithMany("Spoorts")
                        .HasForeignKey("venue_name");
                });

            modelBuilder.Entity("studentFreelance.Models.sports", b =>
                {
                    b.HasOne("studentFreelance.Models.spoorts", "spoorts")
                        .WithMany()
                        .HasForeignKey("sportts")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("studentFreelance.Models.venue", "venue")
                        .WithMany("Sports")
                        .HasForeignKey("venue_name")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("spoorts");

                    b.Navigation("venue");
                });

            modelBuilder.Entity("studentFreelance.Models.timming", b =>
                {
                    b.HasOne("studentFreelance.Models.sports", null)
                        .WithMany("Timmings")
                        .HasForeignKey("sports_Id");
                });

            modelBuilder.Entity("studentFreelance.Models.sports", b =>
                {
                    b.Navigation("Timmings");
                });

            modelBuilder.Entity("studentFreelance.Models.venue", b =>
                {
                    b.Navigation("Spoorts");

                    b.Navigation("Sports");
                });
#pragma warning restore 612, 618
        }
    }
}

﻿// <auto-generated />
using System;
using CinemaProject;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CinemaProject.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.15")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("CinemaProject.CinemaHall", b =>
                {
                    b.Property<int>("CinemaHallID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CinemaHallID"));

                    b.Property<int>("HallTypeID")
                        .HasColumnType("int");

                    b.Property<int>("NumberOfSeats")
                        .HasColumnType("int");

                    b.HasKey("CinemaHallID");

                    b.HasIndex("HallTypeID");

                    b.ToTable("Halls", (string)null);
                });

            modelBuilder.Entity("CinemaProject.Discount", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<double>("DiscountPercent")
                        .HasColumnType("float");

                    b.Property<int>("FilmID")
                        .HasColumnType("int");

                    b.Property<double>("RegUsersDiscountPercent")
                        .HasColumnType("float");

                    b.HasKey("ID");

                    b.HasIndex("FilmID")
                        .IsUnique();

                    b.ToTable("Discounts", (string)null);
                });

            modelBuilder.Entity("CinemaProject.Film", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<int>("Age_restrictions")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Director")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("DiscountID")
                        .HasColumnType("int");

                    b.Property<int>("Duration")
                        .HasColumnType("int");

                    b.Property<string>("Genre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Release_year")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.ToTable("Films", (string)null);
                });

            modelBuilder.Entity("CinemaProject.HallType", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("HallName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("HallTypes", (string)null);

                    b.HasData(
                        new
                        {
                            ID = 1,
                            HallName = "Common"
                        },
                        new
                        {
                            ID = 2,
                            HallName = "VIP"
                        });
                });

            modelBuilder.Entity("CinemaProject.Sale", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<int>("NumberOfTickets")
                        .HasColumnType("int");

                    b.Property<double>("PaymentAmount")
                        .HasColumnType("float");

                    b.Property<DateTime>("SaleDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("UserID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("UserID");

                    b.ToTable("Sales", (string)null);
                });

            modelBuilder.Entity("CinemaProject.Session", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<DateTime>("DateTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("FilmID")
                        .HasColumnType("int");

                    b.Property<int>("HallID")
                        .HasColumnType("int");

                    b.Property<int>("SessionStatusID")
                        .HasColumnType("int");

                    b.Property<double>("TicketPrice")
                        .HasColumnType("float");

                    b.HasKey("ID");

                    b.HasIndex("FilmID");

                    b.HasIndex("HallID");

                    b.HasIndex("SessionStatusID");

                    b.ToTable("Sessions", (string)null);
                });

            modelBuilder.Entity("CinemaProject.SessionStatus", b =>
                {
                    b.Property<int>("SessionStatusID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SessionStatusID"));

                    b.Property<string>("SessionStatusName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("SessionStatusID");

                    b.ToTable("SessionStatuses", (string)null);

                    b.HasData(
                        new
                        {
                            SessionStatusID = 1,
                            SessionStatusName = "Active"
                        },
                        new
                        {
                            SessionStatusID = 2,
                            SessionStatusName = "Canceled"
                        });
                });

            modelBuilder.Entity("CinemaProject.Ticket", b =>
                {
                    b.Property<int>("TicketID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TicketID"));

                    b.Property<int>("Seat")
                        .HasColumnType("int");

                    b.Property<int>("SessionID")
                        .HasColumnType("int");

                    b.Property<double>("TicketPrice")
                        .HasColumnType("float");

                    b.Property<int>("TicketStatusID")
                        .HasColumnType("int");

                    b.HasKey("TicketID");

                    b.HasIndex("SessionID");

                    b.HasIndex("TicketStatusID");

                    b.ToTable("Tickets", (string)null);
                });

            modelBuilder.Entity("CinemaProject.TicketStatus", b =>
                {
                    b.Property<int>("TicketStatusID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TicketStatusID"));

                    b.Property<string>("TicketStatusName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("TicketStatusID");

                    b.ToTable("TicketStatuses", (string)null);

                    b.HasData(
                        new
                        {
                            TicketStatusID = 1,
                            TicketStatusName = "Bought"
                        },
                        new
                        {
                            TicketStatusID = 2,
                            TicketStatusName = "Reserved"
                        },
                        new
                        {
                            TicketStatusID = 3,
                            TicketStatusName = "Returned"
                        });
                });

            modelBuilder.Entity("CinemaProject.User", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<int>("Bonuses")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserTypeID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("UserTypeID");

                    b.ToTable("Users", (string)null);
                });

            modelBuilder.Entity("CinemaProject.UserType", b =>
                {
                    b.Property<int>("UserTypeID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserTypeID"));

                    b.Property<string>("UserTypeName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserTypeID");

                    b.ToTable("UserTypes", (string)null);

                    b.HasData(
                        new
                        {
                            UserTypeID = 1,
                            UserTypeName = "Common user"
                        },
                        new
                        {
                            UserTypeID = 2,
                            UserTypeName = "Administrator"
                        });
                });

            modelBuilder.Entity("CinemaProject.CinemaHall", b =>
                {
                    b.HasOne("CinemaProject.HallType", "HallType")
                        .WithMany("CinemaHalls")
                        .HasForeignKey("HallTypeID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("HallType");
                });

            modelBuilder.Entity("CinemaProject.Discount", b =>
                {
                    b.HasOne("CinemaProject.Film", "Film")
                        .WithOne("Discount")
                        .HasForeignKey("CinemaProject.Discount", "FilmID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Film");
                });

            modelBuilder.Entity("CinemaProject.Sale", b =>
                {
                    b.HasOne("CinemaProject.User", "User")
                        .WithMany("Sales")
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("CinemaProject.Session", b =>
                {
                    b.HasOne("CinemaProject.Film", "Film")
                        .WithMany("Sessions")
                        .HasForeignKey("FilmID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CinemaProject.CinemaHall", "Hall")
                        .WithMany("Sessions")
                        .HasForeignKey("HallID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CinemaProject.SessionStatus", "SessionStatus")
                        .WithMany("Sessions")
                        .HasForeignKey("SessionStatusID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Film");

                    b.Navigation("Hall");

                    b.Navigation("SessionStatus");
                });

            modelBuilder.Entity("CinemaProject.Ticket", b =>
                {
                    b.HasOne("CinemaProject.Session", "Session")
                        .WithMany()
                        .HasForeignKey("SessionID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CinemaProject.TicketStatus", "Status")
                        .WithMany("Tickets")
                        .HasForeignKey("TicketStatusID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Session");

                    b.Navigation("Status");
                });

            modelBuilder.Entity("CinemaProject.User", b =>
                {
                    b.HasOne("CinemaProject.UserType", "Type")
                        .WithMany("Users")
                        .HasForeignKey("UserTypeID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Type");
                });

            modelBuilder.Entity("CinemaProject.CinemaHall", b =>
                {
                    b.Navigation("Sessions");
                });

            modelBuilder.Entity("CinemaProject.Film", b =>
                {
                    b.Navigation("Discount")
                        .IsRequired();

                    b.Navigation("Sessions");
                });

            modelBuilder.Entity("CinemaProject.HallType", b =>
                {
                    b.Navigation("CinemaHalls");
                });

            modelBuilder.Entity("CinemaProject.SessionStatus", b =>
                {
                    b.Navigation("Sessions");
                });

            modelBuilder.Entity("CinemaProject.TicketStatus", b =>
                {
                    b.Navigation("Tickets");
                });

            modelBuilder.Entity("CinemaProject.User", b =>
                {
                    b.Navigation("Sales");
                });

            modelBuilder.Entity("CinemaProject.UserType", b =>
                {
                    b.Navigation("Users");
                });
#pragma warning restore 612, 618
        }
    }
}

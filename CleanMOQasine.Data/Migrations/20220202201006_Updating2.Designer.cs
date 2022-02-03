﻿// <auto-generated />
using System;
using CleanMOQasine.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CleanMOQasine.Data.Migrations
{
    [DbContext(typeof(CleanMOQasineContext))]
    [Migration("20220202201006_Updating2")]
    partial class Updating2
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("CleaningAdditionCleaningType", b =>
                {
                    b.Property<int>("CleaningAdditionsId")
                        .HasColumnType("int");

                    b.Property<int>("CleaningTypesId")
                        .HasColumnType("int");

                    b.HasKey("CleaningAdditionsId", "CleaningTypesId");

                    b.HasIndex("CleaningTypesId");

                    b.ToTable("CleaningAdditionCleaningType");
                });

            modelBuilder.Entity("CleaningAdditionOrder", b =>
                {
                    b.Property<int>("CleaningAdditionsId")
                        .HasColumnType("int");

                    b.Property<int>("OrdersId")
                        .HasColumnType("int");

                    b.HasKey("CleaningAdditionsId", "OrdersId");

                    b.HasIndex("OrdersId");

                    b.ToTable("CleaningAdditionOrder");
                });

            modelBuilder.Entity("CleaningAdditionUser", b =>
                {
                    b.Property<int>("CleaningAdditionsId")
                        .HasColumnType("int");

                    b.Property<int>("UsersId")
                        .HasColumnType("int");

                    b.HasKey("CleaningAdditionsId", "UsersId");

                    b.HasIndex("UsersId");

                    b.ToTable("CleaningAdditionUser");
                });

            modelBuilder.Entity("CleanMOQasine.Data.Entities.CleaningAddition", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<TimeSpan>("Duration")
                        .HasColumnType("time");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.ToTable("CleaningAddition");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Duration = new TimeSpan(0, 0, 30, 0, 0),
                            IsDeleted = false,
                            Name = "Помыть пол",
                            Price = 500m
                        },
                        new
                        {
                            Id = 2,
                            Duration = new TimeSpan(0, 0, 30, 0, 0),
                            IsDeleted = false,
                            Name = "Почистить ковёр",
                            Price = 700m
                        },
                        new
                        {
                            Id = 3,
                            Duration = new TimeSpan(0, 1, 0, 0, 0),
                            IsDeleted = false,
                            Name = "Почистить мебель",
                            Price = 900m
                        },
                        new
                        {
                            Id = 4,
                            Duration = new TimeSpan(0, 0, 40, 0, 0),
                            IsDeleted = false,
                            Name = "Протереть пыль",
                            Price = 500m
                        },
                        new
                        {
                            Id = 5,
                            Duration = new TimeSpan(0, 0, 20, 0, 0),
                            IsDeleted = false,
                            Name = "Помыть зеркала",
                            Price = 400m
                        },
                        new
                        {
                            Id = 6,
                            Duration = new TimeSpan(0, 0, 15, 0, 0),
                            IsDeleted = false,
                            Name = "Застелить постель",
                            Price = 200m
                        },
                        new
                        {
                            Id = 7,
                            Duration = new TimeSpan(0, 0, 30, 0, 0),
                            IsDeleted = false,
                            Name = "Сложить вещи",
                            Price = 400m
                        },
                        new
                        {
                            Id = 8,
                            Duration = new TimeSpan(0, 0, 15, 0, 0),
                            IsDeleted = false,
                            Name = "Вынести мусор",
                            Price = 200m
                        },
                        new
                        {
                            Id = 9,
                            Duration = new TimeSpan(0, 0, 20, 0, 0),
                            IsDeleted = false,
                            Name = "Помыть люстру",
                            Price = 600m
                        },
                        new
                        {
                            Id = 10,
                            Duration = new TimeSpan(0, 0, 20, 0, 0),
                            IsDeleted = false,
                            Name = "Дезинфекция",
                            Price = 500m
                        },
                        new
                        {
                            Id = 11,
                            Duration = new TimeSpan(0, 0, 30, 0, 0),
                            IsDeleted = false,
                            Name = "Убраться в гардеробной",
                            Price = 600m
                        },
                        new
                        {
                            Id = 12,
                            Duration = new TimeSpan(0, 0, 15, 0, 0),
                            IsDeleted = false,
                            Name = "Помыть окно изнутри",
                            Price = 400m
                        },
                        new
                        {
                            Id = 13,
                            Duration = new TimeSpan(0, 0, 45, 0, 0),
                            IsDeleted = false,
                            Name = "Помыть окна на балконе изнутри",
                            Price = 700m
                        },
                        new
                        {
                            Id = 14,
                            Duration = new TimeSpan(0, 0, 35, 0, 0),
                            IsDeleted = false,
                            Name = "Убрать балкон",
                            Price = 600m
                        },
                        new
                        {
                            Id = 15,
                            Duration = new TimeSpan(0, 1, 0, 0, 0),
                            IsDeleted = false,
                            Name = "Погладить вещи",
                            Price = 600m
                        },
                        new
                        {
                            Id = 16,
                            Duration = new TimeSpan(0, 0, 40, 0, 0),
                            IsDeleted = false,
                            Name = "Доставить ключи",
                            Price = 300m
                        },
                        new
                        {
                            Id = 17,
                            Duration = new TimeSpan(0, 0, 40, 0, 0),
                            IsDeleted = false,
                            Name = "Забрать ключи",
                            Price = 300m
                        },
                        new
                        {
                            Id = 18,
                            Duration = new TimeSpan(0, 0, 15, 0, 0),
                            IsDeleted = false,
                            Name = "Помыть раковину",
                            Price = 400m
                        },
                        new
                        {
                            Id = 19,
                            Duration = new TimeSpan(0, 0, 15, 0, 0),
                            IsDeleted = false,
                            Name = "Помыть столешницу",
                            Price = 200m
                        },
                        new
                        {
                            Id = 20,
                            Duration = new TimeSpan(0, 0, 25, 0, 0),
                            IsDeleted = false,
                            Name = "Помыть плиту",
                            Price = 600m
                        },
                        new
                        {
                            Id = 21,
                            Duration = new TimeSpan(0, 0, 30, 0, 0),
                            IsDeleted = false,
                            Name = "Помыть обеденный стол",
                            Price = 500m
                        },
                        new
                        {
                            Id = 22,
                            Duration = new TimeSpan(0, 0, 50, 0, 0),
                            IsDeleted = false,
                            Name = "Помыть посуду",
                            Price = 600m
                        },
                        new
                        {
                            Id = 23,
                            Duration = new TimeSpan(0, 0, 40, 0, 0),
                            IsDeleted = false,
                            Name = "Помыть холодильник",
                            Price = 500m
                        },
                        new
                        {
                            Id = 24,
                            Duration = new TimeSpan(0, 0, 30, 0, 0),
                            IsDeleted = false,
                            Name = "Помыть духовку",
                            Price = 400m
                        },
                        new
                        {
                            Id = 25,
                            Duration = new TimeSpan(0, 0, 20, 0, 0),
                            IsDeleted = false,
                            Name = "Помыть микроволновку",
                            Price = 300m
                        },
                        new
                        {
                            Id = 26,
                            Duration = new TimeSpan(0, 1, 0, 0, 0),
                            IsDeleted = false,
                            Name = "Помыть шкафы на кухне",
                            Price = 800m
                        },
                        new
                        {
                            Id = 27,
                            Duration = new TimeSpan(0, 0, 40, 0, 0),
                            IsDeleted = false,
                            Name = "Помыть ванну или душевую",
                            Price = 800m
                        },
                        new
                        {
                            Id = 28,
                            Duration = new TimeSpan(0, 0, 25, 0, 0),
                            IsDeleted = false,
                            Name = "Помыть унитаз",
                            Price = 500m
                        },
                        new
                        {
                            Id = 29,
                            Duration = new TimeSpan(0, 0, 20, 0, 0),
                            IsDeleted = false,
                            Name = "Помыть биде",
                            Price = 300m
                        },
                        new
                        {
                            Id = 30,
                            Duration = new TimeSpan(0, 0, 10, 0, 0),
                            IsDeleted = false,
                            Name = "Помыть лоток",
                            Price = 200m
                        },
                        new
                        {
                            Id = 31,
                            Duration = new TimeSpan(0, 0, 30, 0, 0),
                            IsDeleted = false,
                            Name = "Убрать что-то ещё",
                            Price = 400m
                        },
                        new
                        {
                            Id = 32,
                            Duration = new TimeSpan(0, 1, 0, 0, 0),
                            IsDeleted = false,
                            Name = "Ебануть дробью",
                            Price = 0m
                        });
                });

            modelBuilder.Entity("CleanMOQasine.Data.Entities.CleaningType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.ToTable("CleaningType");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            IsDeleted = false,
                            Name = "Поддерживающая",
                            Price = 3000m
                        },
                        new
                        {
                            Id = 2,
                            IsDeleted = false,
                            Name = "Генеральная",
                            Price = 6000m
                        },
                        new
                        {
                            Id = 3,
                            IsDeleted = false,
                            Name = "После ремонта",
                            Price = 8000m
                        },
                        new
                        {
                            Id = 4,
                            IsDeleted = false,
                            Name = "Мытье окон",
                            Price = 2000m
                        });
                });

            modelBuilder.Entity("CleanMOQasine.Data.Entities.Grade", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Comment")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsAnonymous")
                        .HasColumnType("bit");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<int>("Rating")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Grade");
                });

            modelBuilder.Entity("CleanMOQasine.Data.Entities.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CleaningTypeId")
                        .HasColumnType("int");

                    b.Property<int>("ClientId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<int>("GradeId")
                        .HasColumnType("int");

                    b.Property<bool>("IsCompleted")
                        .HasColumnType("bit");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<TimeSpan>("TotalDuration")
                        .HasColumnType("time");

                    b.Property<decimal>("TotalPrice")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("CleaningTypeId");

                    b.HasIndex("GradeId")
                        .IsUnique();

                    b.ToTable("Order");
                });

            modelBuilder.Entity("CleanMOQasine.Data.Entities.Payment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<decimal>("Amount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<int>("OrderId")
                        .HasColumnType("int");

                    b.Property<DateTime>("PaymentDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("OrderId");

                    b.ToTable("Payment");
                });

            modelBuilder.Entity("CleanMOQasine.Data.Entities.Room", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.ToTable("Room");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            IsDeleted = false,
                            Name = "Жилая комната",
                            Price = 1100m
                        },
                        new
                        {
                            Id = 2,
                            IsDeleted = false,
                            Name = "Гостиная",
                            Price = 1300m
                        },
                        new
                        {
                            Id = 3,
                            IsDeleted = false,
                            Name = "Кухня",
                            Price = 1300m
                        },
                        new
                        {
                            Id = 4,
                            IsDeleted = false,
                            Name = "Санузел",
                            Price = 800m
                        },
                        new
                        {
                            Id = 5,
                            IsDeleted = false,
                            Name = "Гараж",
                            Price = 1700m
                        });
                });

            modelBuilder.Entity("CleanMOQasine.Data.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Login")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double?>("Rank")
                        .HasColumnType("float");

                    b.Property<int>("Role")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("User");
                });

            modelBuilder.Entity("CleanMOQasine.Data.Entities.WorkingTime", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("Day")
                        .HasColumnType("int");

                    b.Property<DateTime>("EndTime")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<DateTime>("StartTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("WorkingTime");
                });

            modelBuilder.Entity("OrderRoom", b =>
                {
                    b.Property<int>("OrdersId")
                        .HasColumnType("int");

                    b.Property<int>("RoomsId")
                        .HasColumnType("int");

                    b.HasKey("OrdersId", "RoomsId");

                    b.HasIndex("RoomsId");

                    b.ToTable("OrderRoom");
                });

            modelBuilder.Entity("OrderUser", b =>
                {
                    b.Property<int>("InvolvedUsersId")
                        .HasColumnType("int");

                    b.Property<int>("OrdersId")
                        .HasColumnType("int");

                    b.HasKey("InvolvedUsersId", "OrdersId");

                    b.HasIndex("OrdersId");

                    b.ToTable("OrderUser");
                });

            modelBuilder.Entity("CleaningAdditionCleaningType", b =>
                {
                    b.HasOne("CleanMOQasine.Data.Entities.CleaningAddition", null)
                        .WithMany()
                        .HasForeignKey("CleaningAdditionsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CleanMOQasine.Data.Entities.CleaningType", null)
                        .WithMany()
                        .HasForeignKey("CleaningTypesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("CleaningAdditionOrder", b =>
                {
                    b.HasOne("CleanMOQasine.Data.Entities.CleaningAddition", null)
                        .WithMany()
                        .HasForeignKey("CleaningAdditionsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CleanMOQasine.Data.Entities.Order", null)
                        .WithMany()
                        .HasForeignKey("OrdersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("CleaningAdditionUser", b =>
                {
                    b.HasOne("CleanMOQasine.Data.Entities.CleaningAddition", null)
                        .WithMany()
                        .HasForeignKey("CleaningAdditionsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CleanMOQasine.Data.Entities.User", null)
                        .WithMany()
                        .HasForeignKey("UsersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("CleanMOQasine.Data.Entities.Order", b =>
                {
                    b.HasOne("CleanMOQasine.Data.Entities.CleaningType", "CleaningType")
                        .WithMany("Order")
                        .HasForeignKey("CleaningTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CleanMOQasine.Data.Entities.Grade", "Grade")
                        .WithOne("Order")
                        .HasForeignKey("CleanMOQasine.Data.Entities.Order", "GradeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CleaningType");

                    b.Navigation("Grade");
                });

            modelBuilder.Entity("CleanMOQasine.Data.Entities.Payment", b =>
                {
                    b.HasOne("CleanMOQasine.Data.Entities.Order", "Order")
                        .WithMany("Payments")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Order");
                });

            modelBuilder.Entity("CleanMOQasine.Data.Entities.WorkingTime", b =>
                {
                    b.HasOne("CleanMOQasine.Data.Entities.User", "User")
                        .WithMany("WorkingTime")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("OrderRoom", b =>
                {
                    b.HasOne("CleanMOQasine.Data.Entities.Order", null)
                        .WithMany()
                        .HasForeignKey("OrdersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CleanMOQasine.Data.Entities.Room", null)
                        .WithMany()
                        .HasForeignKey("RoomsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("OrderUser", b =>
                {
                    b.HasOne("CleanMOQasine.Data.Entities.User", null)
                        .WithMany()
                        .HasForeignKey("InvolvedUsersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CleanMOQasine.Data.Entities.Order", null)
                        .WithMany()
                        .HasForeignKey("OrdersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("CleanMOQasine.Data.Entities.CleaningType", b =>
                {
                    b.Navigation("Order");
                });

            modelBuilder.Entity("CleanMOQasine.Data.Entities.Grade", b =>
                {
                    b.Navigation("Order")
                        .IsRequired();
                });

            modelBuilder.Entity("CleanMOQasine.Data.Entities.Order", b =>
                {
                    b.Navigation("Payments");
                });

            modelBuilder.Entity("CleanMOQasine.Data.Entities.User", b =>
                {
                    b.Navigation("WorkingTime");
                });
#pragma warning restore 612, 618
        }
    }
}
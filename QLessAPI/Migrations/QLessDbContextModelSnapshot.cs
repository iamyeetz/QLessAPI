﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using QLessAPI.Models;

namespace QLessAPI.Migrations
{
    [DbContext(typeof(QLessDbContext))]
    partial class QLessDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("QLessAPI.Models.CardType", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("Discount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Name")
                        .HasColumnType("varchar(20)");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("nvarchar(1)");

                    b.HasKey("id");

                    b.ToTable("CardType");
                });

            modelBuilder.Entity("QLessAPI.Models.DiscountCardDetails", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("GovernmentIdNumber")
                        .HasColumnType("varchar(14)");

                    b.Property<string>("GovernmentIdType")
                        .HasColumnType("varchar(50)");

                    b.Property<int>("TransportCardId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TransportCardId")
                        .IsUnique();

                    b.ToTable("DiscountCardDetails");
                });

            modelBuilder.Entity("QLessAPI.Models.Transport", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("Cost")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("MrtLine")
                        .HasColumnType("int");

                    b.Property<int>("TransportCardId")
                        .HasColumnType("int");

                    b.Property<DateTime>("TrasportDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("TransportCardId");

                    b.ToTable("Transport");
                });

            modelBuilder.Entity("QLessAPI.TransportCard", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CardTypeId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DateRegistered")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("ExpirationDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("LastDateUsed")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("Load")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("CardTypeId");

                    b.ToTable("TransportCard");
                });

            modelBuilder.Entity("QLessAPI.Models.DiscountCardDetails", b =>
                {
                    b.HasOne("QLessAPI.TransportCard", null)
                        .WithOne("DiscountCardDetails")
                        .HasForeignKey("QLessAPI.Models.DiscountCardDetails", "TransportCardId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("QLessAPI.Models.Transport", b =>
                {
                    b.HasOne("QLessAPI.TransportCard", null)
                        .WithMany("Transports")
                        .HasForeignKey("TransportCardId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("QLessAPI.TransportCard", b =>
                {
                    b.HasOne("QLessAPI.Models.CardType", "CardType")
                        .WithMany()
                        .HasForeignKey("CardTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
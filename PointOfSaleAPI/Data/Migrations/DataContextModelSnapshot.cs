﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PointOfSaleAPI.Data;

namespace PointOfSaleAPI.Data.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.3");

            modelBuilder.Entity("PointOfSaleAPI.Entities.ColorSelection", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<decimal>("Cost")
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<string>("HexCode")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("ColorSelections");
                });

            modelBuilder.Entity("PointOfSaleAPI.Entities.HddItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<decimal>("Cost")
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<string>("HddSize")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<string>("SideNotation")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("HddItems");
                });

            modelBuilder.Entity("PointOfSaleAPI.Entities.LaptopItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Brand")
                        .HasColumnType("TEXT");

                    b.Property<decimal>("Cost")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("LaptopItems");
                });

            modelBuilder.Entity("PointOfSaleAPI.Entities.RamItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<decimal>("Cost")
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<string>("RamGeneration")
                        .HasColumnType("TEXT");

                    b.Property<string>("RamSize")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("RamItems");
                });

            modelBuilder.Entity("PointOfSaleAPI.Entities.SalesItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("ColorId")
                        .HasColumnType("INTEGER");

                    b.Property<decimal>("CostExcVat")
                        .HasColumnType("TEXT");

                    b.Property<decimal>("CostIncVat")
                        .HasColumnType("TEXT");

                    b.Property<int>("HddId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("LaptopId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("RamId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("ColorId");

                    b.HasIndex("HddId");

                    b.HasIndex("LaptopId");

                    b.HasIndex("RamId");

                    b.ToTable("SalesItems");
                });

            modelBuilder.Entity("PointOfSaleAPI.Entities.SalesItem", b =>
                {
                    b.HasOne("PointOfSaleAPI.Entities.ColorSelection", "Color")
                        .WithMany()
                        .HasForeignKey("ColorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PointOfSaleAPI.Entities.HddItem", "Hdd")
                        .WithMany()
                        .HasForeignKey("HddId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PointOfSaleAPI.Entities.LaptopItem", "Laptop")
                        .WithMany()
                        .HasForeignKey("LaptopId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PointOfSaleAPI.Entities.RamItem", "Ram")
                        .WithMany()
                        .HasForeignKey("RamId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Color");

                    b.Navigation("Hdd");

                    b.Navigation("Laptop");

                    b.Navigation("Ram");
                });
#pragma warning restore 612, 618
        }
    }
}

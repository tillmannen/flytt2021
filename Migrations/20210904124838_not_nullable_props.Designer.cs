﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using flytt2021.Data.Database;

namespace flytt2021.Migrations
{
    [DbContext(typeof(FlyttDbContext))]
    [Migration("20210904124838_not_nullable_props")]
    partial class not_nullable_props
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.8")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("flytt2021.Data.Entities.BoxOwner", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("MoveId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("MoveId");

                    b.ToTable("BoxOwners");
                });

            modelBuilder.Entity("flytt2021.Data.Entities.DestinationFloor", b =>
                {
                    b.Property<int>("DestinationFloorId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("BackgroundColorcode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Colorcode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("MoveId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("DestinationFloorId");

                    b.HasIndex("MoveId");

                    b.ToTable("DestinationFloor");
                });

            modelBuilder.Entity("flytt2021.Data.Entities.Move", b =>
                {
                    b.Property<int>("MoveId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CreatedByUserName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedDateTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("FromFriendlyName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("MoveDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("ToFriendlyName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("MoveId");

                    b.ToTable("Move");
                });

            modelBuilder.Entity("flytt2021.Data.Entities.Movingbox", b =>
                {
                    b.Property<int>("MovingboxId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BoxOwnerId")
                        .HasColumnType("int");

                    b.Property<string>("Contents")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Destination")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("DestinationFloorEnum")
                        .HasColumnType("int");

                    b.Property<int>("DestinationFloorId")
                        .HasColumnType("int");

                    b.Property<bool>("IsUnpacked")
                        .HasColumnType("bit");

                    b.Property<string>("Marking")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("MoveId")
                        .HasColumnType("int");

                    b.Property<int>("PackerId")
                        .HasColumnType("int");

                    b.HasKey("MovingboxId");

                    b.HasIndex("BoxOwnerId");

                    b.HasIndex("DestinationFloorId");

                    b.HasIndex("MoveId");

                    b.HasIndex("PackerId");

                    b.ToTable("Movingboxes");
                });

            modelBuilder.Entity("flytt2021.Data.Entities.Packer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("MoveId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("MoveId");

                    b.ToTable("Packers");
                });

            modelBuilder.Entity("flytt2021.Data.Entities.BoxOwner", b =>
                {
                    b.HasOne("flytt2021.Data.Entities.Move", null)
                        .WithMany("BoxOwners")
                        .HasForeignKey("MoveId");
                });

            modelBuilder.Entity("flytt2021.Data.Entities.DestinationFloor", b =>
                {
                    b.HasOne("flytt2021.Data.Entities.Move", null)
                        .WithMany("DestinationFloors")
                        .HasForeignKey("MoveId");
                });

            modelBuilder.Entity("flytt2021.Data.Entities.Movingbox", b =>
                {
                    b.HasOne("flytt2021.Data.Entities.BoxOwner", "BoxOwner")
                        .WithMany()
                        .HasForeignKey("BoxOwnerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("flytt2021.Data.Entities.DestinationFloor", "DestinationFloor")
                        .WithMany()
                        .HasForeignKey("DestinationFloorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("flytt2021.Data.Entities.Move", "Move")
                        .WithMany("MovingBoxes")
                        .HasForeignKey("MoveId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("flytt2021.Data.Entities.Packer", "Packer")
                        .WithMany()
                        .HasForeignKey("PackerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("BoxOwner");

                    b.Navigation("DestinationFloor");

                    b.Navigation("Move");

                    b.Navigation("Packer");
                });

            modelBuilder.Entity("flytt2021.Data.Entities.Packer", b =>
                {
                    b.HasOne("flytt2021.Data.Entities.Move", null)
                        .WithMany("Packers")
                        .HasForeignKey("MoveId");
                });

            modelBuilder.Entity("flytt2021.Data.Entities.Move", b =>
                {
                    b.Navigation("BoxOwners");

                    b.Navigation("DestinationFloors");

                    b.Navigation("MovingBoxes");

                    b.Navigation("Packers");
                });
#pragma warning restore 612, 618
        }
    }
}

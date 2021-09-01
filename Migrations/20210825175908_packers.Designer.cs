﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using flytt2021.Data.Database;

namespace flytt2021.Migrations
{
    [DbContext(typeof(FlyttDbContext))]
    [Migration("20210825175908_packers")]
    partial class packers
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.8");

            modelBuilder.Entity("flytt2021.Data.BoxOwner", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("BoxOwners");
                });

            modelBuilder.Entity("flytt2021.Data.Movingbox", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int?>("BoxOwnerId")
                        .HasColumnType("int");

                    b.Property<string>("Contents")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Destination")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("DestinationFloor")
                        .HasColumnType("int");

                    b.Property<bool>("IsUnpacked")
                        .HasColumnType("bit");

                    b.Property<string>("Marking")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("PackerId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("BoxOwnerId");

                    b.HasIndex("PackerId");

                    b.ToTable("Movingboxes");
                });

            modelBuilder.Entity("flytt2021.Data.Packer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Packers");
                });

            modelBuilder.Entity("flytt2021.Data.Movingbox", b =>
                {
                    b.HasOne("flytt2021.Data.BoxOwner", "BoxOwner")
                        .WithMany()
                        .HasForeignKey("BoxOwnerId");

                    b.HasOne("flytt2021.Data.Packer", "Packer")
                        .WithMany()
                        .HasForeignKey("PackerId");

                    b.Navigation("BoxOwner");

                    b.Navigation("Packer");
                });
#pragma warning restore 612, 618
        }
    }
}

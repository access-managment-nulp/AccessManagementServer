﻿// <auto-generated />
using AccessManagementApp.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace AccessManagementApp.Migrations
{
    [DbContext(typeof(AccessManagementDbContext))]
    partial class AccessManagementDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.14")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("AccessAccessGroup", b =>
                {
                    b.Property<int>("AccessGroupsId")
                        .HasColumnType("int");

                    b.Property<int>("AccessesId")
                        .HasColumnType("int");

                    b.HasKey("AccessGroupsId", "AccessesId");

                    b.HasIndex("AccessesId");

                    b.ToTable("AccessAccessGroup");
                });

            modelBuilder.Entity("AccessGroupSpeciality", b =>
                {
                    b.Property<int>("AccessGroupsId")
                        .HasColumnType("int");

                    b.Property<int>("SpecialitiesId")
                        .HasColumnType("int");

                    b.HasKey("AccessGroupsId", "SpecialitiesId");

                    b.HasIndex("SpecialitiesId");

                    b.ToTable("AccessGroupSpeciality");
                });

            modelBuilder.Entity("AccessManagementApp.Repository.Models.Access", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("aName");

                    b.HasKey("Id");

                    b.ToTable("Access");
                });

            modelBuilder.Entity("AccessManagementApp.Repository.Models.AccessGroup", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("aName");

                    b.HasKey("Id");

                    b.ToTable("AccessGroup");
                });

            modelBuilder.Entity("AccessManagementApp.Repository.Models.Speciality", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("sName");

                    b.HasKey("Id");

                    b.ToTable("Speciality");
                });

            modelBuilder.Entity("AccessManagementApp.Repository.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("AccessSpeciality", b =>
                {
                    b.Property<int>("AccessesId")
                        .HasColumnType("int");

                    b.Property<int>("SpecialitiesId")
                        .HasColumnType("int");

                    b.HasKey("AccessesId", "SpecialitiesId");

                    b.HasIndex("SpecialitiesId");

                    b.ToTable("AccessSpeciality");
                });

            modelBuilder.Entity("AccessAccessGroup", b =>
                {
                    b.HasOne("AccessManagementApp.Repository.Models.AccessGroup", null)
                        .WithMany()
                        .HasForeignKey("AccessGroupsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AccessManagementApp.Repository.Models.Access", null)
                        .WithMany()
                        .HasForeignKey("AccessesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("AccessGroupSpeciality", b =>
                {
                    b.HasOne("AccessManagementApp.Repository.Models.AccessGroup", null)
                        .WithMany()
                        .HasForeignKey("AccessGroupsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AccessManagementApp.Repository.Models.Speciality", null)
                        .WithMany()
                        .HasForeignKey("SpecialitiesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("AccessSpeciality", b =>
                {
                    b.HasOne("AccessManagementApp.Repository.Models.Access", null)
                        .WithMany()
                        .HasForeignKey("AccessesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AccessManagementApp.Repository.Models.Speciality", null)
                        .WithMany()
                        .HasForeignKey("SpecialitiesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}

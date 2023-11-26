﻿// <auto-generated />
using AccessManagementApp.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace AccessManagementApp.Migrations
{
    [DbContext(typeof(AccessManagementDbContext))]
    [Migration("20231126192310_InitMigration")]
    partial class InitMigration
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.14")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

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

                    b.HasKey("Id")
                        .HasName("PK__Access__3213E83FAE6CDF7F");

                    b.ToTable("Access");
                });

            modelBuilder.Entity("AccessManagementApp.Repository.Models.AccessGroup", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("AccessId")
                        .HasColumnType("int")
                        .HasColumnName("accessId");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("aName");

                    b.HasKey("Id")
                        .HasName("PK__AccessGr__3213E83FE5DCC860");

                    b.HasIndex("AccessId");

                    b.ToTable("AccessGroup");
                });

            modelBuilder.Entity("AccessManagementApp.Repository.Models.Speciality", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("AccessGroupId")
                        .HasColumnType("int")
                        .HasColumnName("accessGroupId");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("sName");

                    b.HasKey("Id")
                        .HasName("PK__Speciali__3213E83FC4FF255A");

                    b.HasIndex("AccessGroupId");

                    b.ToTable("Speciality");
                });

            modelBuilder.Entity("AccessManagementApp.Repository.Models.AccessGroup", b =>
                {
                    b.HasOne("AccessManagementApp.Repository.Models.Access", "Access")
                        .WithMany("AccessGroups")
                        .HasForeignKey("AccessId")
                        .IsRequired()
                        .HasConstraintName("FK__AccessGro__acces__267ABA7A");

                    b.Navigation("Access");
                });

            modelBuilder.Entity("AccessManagementApp.Repository.Models.Speciality", b =>
                {
                    b.HasOne("AccessManagementApp.Repository.Models.AccessGroup", "AccessGroup")
                        .WithMany("Specialities")
                        .HasForeignKey("AccessGroupId")
                        .IsRequired()
                        .HasConstraintName("FK__Specialit__acces__29572725");

                    b.Navigation("AccessGroup");
                });

            modelBuilder.Entity("AccessManagementApp.Repository.Models.Access", b =>
                {
                    b.Navigation("AccessGroups");
                });

            modelBuilder.Entity("AccessManagementApp.Repository.Models.AccessGroup", b =>
                {
                    b.Navigation("Specialities");
                });
#pragma warning restore 612, 618
        }
    }
}

using System;
using System.Collections.Generic;
using AccessManagementApp.Repository.Models;
using Microsoft.EntityFrameworkCore;

namespace AccessManagementApp.Repository;

public partial class AccessManagementDbContext : DbContext
{
    public AccessManagementDbContext()
    {
    }

    public AccessManagementDbContext(DbContextOptions<AccessManagementDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Access> Accesses { get; set; }

    public virtual DbSet<AccessGroup> AccessGroups { get; set; }

    public virtual DbSet<Speciality> Specialities { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=DESKTOP-QAU2I64;Initial Catalog=accessmanagementDB;Integrated Security=True;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Access>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Access__3213E83FAE6CDF7F");
        });

        modelBuilder.Entity<AccessGroup>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__AccessGr__3213E83FE5DCC860");

            entity.HasOne(d => d.Access).WithMany(p => p.AccessGroups)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__AccessGro__acces__267ABA7A");
        });

        modelBuilder.Entity<Speciality>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Speciali__3213E83FC4FF255A");

            entity.HasOne(d => d.AccessGroup).WithMany(p => p.Specialities)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Specialit__acces__29572725");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

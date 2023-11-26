using System;
using System.Collections.Generic;
using AccessManagementApp.Repository.Models;
using Microsoft.EntityFrameworkCore;

namespace AccessManagementApp.Repository;

public partial class AccessManagementDbContext : DbContext
{
    public AccessManagementDbContext(DbContextOptions<AccessManagementDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Access> Accesses { get; set; }
    public virtual DbSet<AccessGroup> AccessGroups { get; set; }
    public virtual DbSet<Speciality> Specialities { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
        IConfigurationRoot configuration = new ConfigurationBuilder()
            .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
            .AddJsonFile("appsettings.json")
            .Build();
        optionsBuilder.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Access>(entity =>
        {
            entity.HasKey(e => e.Id);
        });

        modelBuilder.Entity<AccessGroup>(entity =>
        {
            entity.HasKey(e => e.Id);

            entity.HasMany(d => d.Accesses).WithMany(p => p.AccessGroups);
        });

        modelBuilder.Entity<Speciality>(entity =>
        {
            entity.HasKey(e => e.Id);

            entity.HasMany(d => d.Accesses).WithMany(p => p.Specialities);
            entity.HasMany(d => d.AccessGroups).WithMany(p => p.Specialities);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

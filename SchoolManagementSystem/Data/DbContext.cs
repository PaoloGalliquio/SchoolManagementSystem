using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using SchoolManagementSystem.Data.Models;

namespace SchoolManagementSystem.Data;

public partial class DbContext : Microsoft.EntityFrameworkCore.DbContext
{
    public DbContext()
    {
    }

    public DbContext(DbContextOptions<DbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Country> Countries { get; set; }

    public virtual DbSet<School> Schools { get; set; }

    public virtual DbSet<Student> Students { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Server=GAP\\SQLEXPRESS; DataBase=SchoolManagementSystem;Integrated Security=true; TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Country>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__country__3213E83F651195F7");

            entity.ToTable("country");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CountryCode)
                .HasMaxLength(2)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("country_code");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .HasColumnName("name");
        });

        modelBuilder.Entity<School>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__school__3213E83F53544E9A");

            entity.ToTable("school");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.IdCountry).HasColumnName("id_country");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .HasColumnName("name");

            entity.HasOne(d => d.IdCountryNavigation).WithMany(p => p.Schools)
                .HasForeignKey(d => d.IdCountry)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_school_country");
        });

        modelBuilder.Entity<Student>(entity =>
        {
            entity.HasKey(e => e.IdentityCard).HasName("PK__student__4943C3B54EA17D82");

            entity.ToTable("student");

            entity.Property(e => e.IdentityCard)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("identity_card");
            entity.Property(e => e.DateOfBirth).HasColumnName("date_of_birth");
            entity.Property(e => e.IdSchool).HasColumnName("id_school");
            entity.Property(e => e.Names)
                .HasMaxLength(50)
                .HasColumnName("names");
            entity.Property(e => e.Surnames)
                .HasMaxLength(50)
                .HasColumnName("surnames");

            entity.HasOne(d => d.IdSchoolNavigation).WithMany(p => p.Students)
                .HasForeignKey(d => d.IdSchool)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_student_school");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

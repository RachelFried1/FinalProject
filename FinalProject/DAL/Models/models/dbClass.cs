using System;
using System.Collections.Generic;
using DAL.Models.models;
using Microsoft.EntityFrameworkCore;

namespace DAL.Models.models;
public partial class dbClass : DbContext
{
    public dbClass()
    {
    }

    public dbClass(DbContextOptions<dbClass> options)
        : base(options)
    {
    }

    public virtual DbSet<Company> Companies { get; set; }

    public virtual DbSet<Job> Jobs { get; set; }

    public virtual DbSet<JobOffer> JobOffers { get; set; }

    public virtual DbSet<JobSeeker> JobSeekers { get; set; }

    public virtual DbSet<UserPassword> UserPasswords { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\Public\\Documents\\Documents\\FinalProject\\FinalProject\\DAL\\Models\\Data\\DB.mdf;Integrated Security=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Company>(entity =>
        {
            entity.HasKey(e => e.Code).HasName("PK__Company__A25C5AA6DBADD1B8");

            entity.ToTable("Company");

            entity.Property(e => e.Code).ValueGeneratedNever();
            entity.Property(e => e.Email).HasMaxLength(50);
            entity.Property(e => e.Name).HasMaxLength(50);
        });

        modelBuilder.Entity<Job>(entity =>
        {
            entity.HasKey(e => e.Code).HasName("PK__tmp_ms_x__A25C5AA656C24301");

            entity.ToTable("Job");

            entity.Property(e => e.Code).ValueGeneratedNever();
            entity.Property(e => e.CompanyId).HasColumnName("CompanyID");
            entity.Property(e => e.Country).HasMaxLength(50);
            entity.Property(e => e.Field).HasMaxLength(50);

            entity.HasOne(d => d.Company).WithMany(p => p.Jobs)
                .HasForeignKey(d => d.CompanyId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Job_ToTable");
        });

        modelBuilder.Entity<JobOffer>(entity =>
        {
            entity.HasKey(e => e.OffersCode).HasName("PK__JobOffer__F4BD6BD8585C6A1F");

            entity.Property(e => e.OffersCode).ValueGeneratedNever();
            entity.Property(e => e.ApplicationDate).HasColumnType("datetime");

            entity.HasOne(d => d.Candidate).WithMany(p => p.JobOffers)
                .HasForeignKey(d => d.CandidateId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_JobOffers_ToTable");

            entity.HasOne(d => d.JobCodeNavigation).WithMany(p => p.JobOffers)
                .HasForeignKey(d => d.JobCode)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_JobOffers_ToTable_1");
        });

        modelBuilder.Entity<JobSeeker>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__tmp_ms_x__3214EC07B4ACE1BA");

            entity.ToTable("JobSeeker");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Country).HasMaxLength(50);
            entity.Property(e => e.Email).HasMaxLength(50);
            entity.Property(e => e.Field)
                .HasMaxLength(10)
                .IsFixedLength();
            entity.Property(e => e.Name).HasMaxLength(50);
            entity.Property(e => e.SirName).HasMaxLength(50);
        });

        modelBuilder.Entity<UserPassword>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__UserPass__3214EC0729E95629");

            entity.ToTable("UserPassword");

            entity.Property(e => e.PasswordHash).HasMaxLength(255);
            entity.Property(e => e.UserType).HasMaxLength(50);

            entity.HasOne(d => d.User).WithMany(p => p.UserPasswords)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK_UserPasswords_Company");

            entity.HasOne(d => d.UserNavigation).WithMany(p => p.UserPasswords)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK_UserPasswords_JobSeeker");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

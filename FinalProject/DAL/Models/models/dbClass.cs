using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DAL.Models;

public partial class dbClass : DbContext
{
    public dbClass()
    {
    }

    public dbClass(DbContextOptions<dbClass> options)
        : base(options)
    {
    }

    public virtual DbSet<Job> Jobs { get; set; }

    public virtual DbSet<JobOffer> JobOffers { get; set; }

    public virtual DbSet<JobSeeker> JobSeekers { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=H:\\FinalProject\\FinalProject\\DAL\\Models\\Data\\DB.mdf;Integrated Security=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Job>(entity =>
        {
            entity.HasKey(e => e.Code).HasName("PK__Job__3214EC070C71B0D9");

            entity.ToTable("Job");

            entity.Property(e => e.Code).ValueGeneratedNever();
            entity.Property(e => e.CompanyName).HasMaxLength(50);
            entity.Property(e => e.Country).HasMaxLength(50);
            entity.Property(e => e.Email).HasMaxLength(50);
            entity.Property(e => e.Field).HasMaxLength(50);
        });

        modelBuilder.Entity<JobOffer>(entity =>
        {
            entity.HasKey(e => e.OffersCode).HasName("PK__JobOffer__F4BD6BD8585C6A1F");

            entity.Property(e => e.OffersCode).ValueGeneratedNever();

            entity.HasOne(d => d.Candidate).WithMany(p => p.JobOffers)
                .HasForeignKey(d => d.CandidateId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_JobOffers_ToTable");

            entity.HasOne(d => d.JobMatch).WithMany(p => p.JobOffers)
                .HasForeignKey(d => d.JobCode)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_JobOffers_ToTable_1");
        });

        modelBuilder.Entity<JobSeeker>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__JobSeeke__3214EC0757476095");

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

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

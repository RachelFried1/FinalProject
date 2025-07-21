using Microsoft.EntityFrameworkCore;

namespace DAL.Models.models
{
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
        public virtual DbSet<CompanyPassword> CompanyPasswords { get; set; }
        public virtual DbSet<JobSeekerPassword> JobSeekerPasswords { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Company>(entity =>
            {
                entity.HasKey(e => e.Code).HasName("PK__Company__A25C5AA6DBADD1B8");
                entity.ToTable("Company");
                entity.Property(e => e.Code).ValueGeneratedNever();
                entity.Property(e => e.Email).HasMaxLength(50);
                entity.Property(e => e.Name).HasMaxLength(50);
                entity.HasIndex(e => e.Email).IsUnique();

                entity.HasOne(e => e.UserPassword)
                    .WithOne(p => p.Company)
                    .HasForeignKey<CompanyPassword>(p => p.CompanyId);
            });

            modelBuilder.Entity<Job>(entity =>
            {
                entity.HasKey(e => e.Code).HasName("PK__tmp_ms_x__A25C5AA656C24301");
                entity.ToTable("Job");
                entity.HasIndex(e => e.CompanyId, "IX_Job_CompanyID");
                entity.Property(e => e.Code).ValueGeneratedNever();
                entity.Property(e => e.CompanyId).HasColumnName("CompanyID");
                entity.Property(e => e.Country).HasMaxLength(50);

                entity.HasOne(d => d.Company).WithMany(p => p.Jobs)
                    .HasForeignKey(d => d.CompanyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Job_ToTable");
            });

            modelBuilder.Entity<JobOffer>(entity =>
            {
                entity.HasKey(e => e.OffersCode).HasName("PK__JobOffer__F4BD6BD8585C6A1F");
                entity.ToTable("JobOffer");
                entity.HasIndex(e => e.CandidateId, "IX_JobOffer_CandidateId");
                entity.HasIndex(e => e.JobCode, "IX_JobOffer_JobCode");
                entity.Property(e => e.OffersCode).ValueGeneratedNever();
                entity.Property(e => e.ApplicationDate).HasColumnType("datetime");

                entity.HasOne(d => d.Candidate).WithMany(p => p.JobOffers)
                    .HasForeignKey(d => d.CandidateId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_JobOffer_ToTable");

                entity.HasOne(d => d.JobCodeNavigation).WithMany(p => p.JobOffers)
                    .HasForeignKey(d => d.JobCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_JobOffer_ToTable_1");
            });

            modelBuilder.Entity<JobSeeker>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK__tmp_ms_x__3214EC07B4ACE1BA");
                entity.ToTable("JobSeeker");
                entity.Property(e => e.Id).ValueGeneratedNever();
                entity.Property(e => e.Country).HasMaxLength(50);
                entity.Property(e => e.Email).HasMaxLength(50);
                entity.Property(e => e.Name).HasMaxLength(50);
                entity.Property(e => e.SirName).HasMaxLength(50);
                entity.HasIndex(e => e.Email).IsUnique();

                entity.HasOne(e => e.UserPassword)
                    .WithOne(p => p.JobSeeker)
                    .HasForeignKey<JobSeekerPassword>(p => p.JobSeekerId);
            });

            modelBuilder.Entity<CompanyPassword>(entity =>
            {
                entity.HasKey(e => e.CompanyId);
                entity.Property(e => e.PasswordHash).IsRequired();
            });

            modelBuilder.Entity<JobSeekerPassword>(entity =>
            {
                entity.HasKey(e => e.JobSeekerId);
                entity.Property(e => e.PasswordHash).IsRequired();
            });

            OnModelCreatingPartial(modelBuilder);
        }
        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

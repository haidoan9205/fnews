using DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace DAL
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ApplicantSkill>().HasKey(a => new { a.ApplcantId, a.SkillId });
            modelBuilder.Entity<JobRequest>().HasKey(j => new { j.ApplicantId, j.JobId });

            modelBuilder.Entity<ApplicantSkill>()
                .HasOne(a => a.Applicant)
                .WithMany(ap => ap.ApplicantSkills)
                .HasForeignKey(a => a.ApplcantId);

            modelBuilder.Entity<ApplicantSkill>()
                .HasOne(a => a.Skill)
                .WithMany(ap => ap.ApplicantSkills)
                .HasForeignKey(a => a.SkillId);

            modelBuilder.Entity<JobRequest>()
                .HasOne(a => a.Applicant)
                .WithMany(ap => ap.JobRequests)
                .HasForeignKey(a => a.ApplicantId);

            modelBuilder.Entity<JobRequest>()
                .HasOne(a => a.Job)
                .WithMany(ap => ap.JobRequests)
                .HasForeignKey(a => a.JobId);

            modelBuilder.Entity<Applicant>()
                .HasIndex(a => a.Email)
                .IsUnique();
        }

        public DbSet<Applicant> Applicant { get; set; }
        public DbSet<Admin> Admin { get; set; }
        public DbSet<Company> Company { get; set; }
        public DbSet<Job> Job { get; set; }
        public DbSet<JobType> JobType { get; set; }
        public DbSet<PayType> PayType { get; set; }
        public DbSet<Skill> Skill { get; set; }
    }
}
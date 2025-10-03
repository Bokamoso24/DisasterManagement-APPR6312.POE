using Microsoft.EntityFrameworkCore;
using DisasterManagementApp.Models;
using System.Data;
using DisasterManagement.Models;

namespace DisasterManagementApp.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options) { }

        public DbSet<Role> Roles { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Volunteer> Volunteers { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<VolunteerAssignment> VolunteerAssignments { get; set; }
        public DbSet<Donation> Donations { get; set; }
        public DbSet<Resource> Resources { get; set; }
        public DbSet<Report> Reports { get; set; }
        public DbSet<ReportLink> ReportLinks { get; set; }
        public DbSet<Incident> Incidents { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // map table/column names to match your existing SQL if needed
            modelBuilder.Entity<User>().ToTable("Users").HasKey(u => u.UserID);
            modelBuilder.Entity<Role>().ToTable("Roles").HasKey(r => r.RoleID);
            modelBuilder.Entity<Volunteer>().ToTable("Volunteers").HasKey(v => v.VolunteerID);
            modelBuilder.Entity<Project>().ToTable("Projects").HasKey(p => p.ProjectID);
            modelBuilder.Entity<VolunteerAssignment>().ToTable("VolunteerAssignments").HasKey(va => va.AssignmentID);
            modelBuilder.Entity<Donation>().ToTable("Donations").HasKey(d => d.DonationID);
            modelBuilder.Entity<Resource>().ToTable("Resources").HasKey(r => r.ResourceID);
            modelBuilder.Entity<Report>().ToTable("Reports").HasKey(r => r.ReportID);
            modelBuilder.Entity<ReportLink>().ToTable("ReportLinks").HasKey(rl => rl.ReportLinkID);
            modelBuilder.Entity<Incident>().ToTable("Incidents").HasKey(i => i.IncidentID);

            // relationships
            modelBuilder.Entity<User>()
                .HasOne<Role>()
                .WithMany()
                .HasForeignKey(u => u.RoleID)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Volunteer>()
                .HasOne<User>()
                .WithOne()
                .HasForeignKey<Volunteer>(v => v.VolunteerID);

            modelBuilder.Entity<Resource>()
                .HasOne<Donation>()
                .WithMany()
                .HasForeignKey(r => r.DonationID);

            modelBuilder.Entity<VolunteerAssignment>()
                .HasOne<Project>()
                .WithMany()
                .HasForeignKey(va => va.ProjectID);

            // (Add other Fluent API mapping as needed)
            base.OnModelCreating(modelBuilder);
        }
    }
}

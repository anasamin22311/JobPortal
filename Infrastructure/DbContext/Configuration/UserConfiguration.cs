using JobPortal.Domain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace JobPortal.Infrastructure.DbContext.Configuration
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            // One-to-many relationship between User and Application
            builder.HasMany(u => u.JobApplicationsAsCandidate) // Rename this to avoid conflict
                .WithOne(a => a.Candidate)
                .HasForeignKey(a => a.CandidateID);

            builder.HasMany(u => u.JobApplicationsAsEmployer)
                .WithOne(a => a.Employer)
                .HasForeignKey(a => a.EmployerID);

            // One-to-many relationship between User and Notification
            builder.HasMany(u => u.Notifications)
                .WithOne(n => n.Sender)
                .HasForeignKey(n => n.SenderID);

            // One-to-many relationship between User and Feedback
            builder.HasMany(u => u.Feedbacks)
                .WithOne(f => f.Sender)
                .HasForeignKey(f => f.SenderID);

            // Many-to-many relationship between User and Skill
            builder.HasMany(u => u.Skills)
                .WithMany(s => s.Candidates)
                .UsingEntity(j => j.ToTable("UserSkills"));
        }
    }
}

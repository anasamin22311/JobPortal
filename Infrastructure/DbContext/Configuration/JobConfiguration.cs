using JobPortal.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JobPortal.Infrastructure.DbContext.Configuration
{
    public class JobConfiguration : IEntityTypeConfiguration<Job>
    {
        public void Configure(EntityTypeBuilder<Job> builder)
        {
            // Many-to-many relationship between Job and Industry
            builder.HasMany(j => j.Industries)
                .WithMany(i => i.Jobs)
                .UsingEntity(j => j.ToTable("JobIndustries"));

            // Many-to-many relationship between Job and ExperienceLevel
            builder
                .HasMany(j => j.ExperienceLevels)
                .WithMany(e => e.Jobs)
                .UsingEntity(j => j.ToTable("JobExperienceLevels"));

            // Many-to-many relationship between Job and EducationLevel
            builder.HasMany(j => j.EducationLevels)
                .WithMany(e => e.Jobs)
                .UsingEntity(j => j.ToTable("JobEducationLevels"));

            // Many-to-many relationship between Job and Company
            builder
                .HasMany(j => j.Companies)
                .WithMany(c => c.Jobs)
                .UsingEntity(j => j.ToTable("JobCompanies"));

            // Many-to-many relationship between Job and Tag
            builder
                .HasMany(j => j.Tags)
                .WithMany(t => t.Jobs)
                .UsingEntity(j => j.ToTable("JobTags"));
            // Many-to-many relationship between Job and Skill
            builder
                .HasMany(j => j.Skills)
                .WithMany(s => s.Jobs)
                .UsingEntity(j => j.ToTable("JobSkills"));

            // Many-to-many relationship between Job and Category
            builder
                .HasMany(j => j.Categories)
                .WithMany(c => c.Jobs)
                .UsingEntity(j => j.ToTable("JobCategories"));
            // One-to-many relationship between Job and Application
            builder
                .HasMany(j => j.JobApplications)
                .WithOne(a => a.Job)
                .HasForeignKey(a => a.JobID);
        }
    }
}
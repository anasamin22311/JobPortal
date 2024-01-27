using JobPortal.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JobPortal.Infrastructure.DbContext.Configuration
{
    public class EmployerConfiguration : IEntityTypeConfiguration<Employer>
    {
        public void Configure(EntityTypeBuilder<Employer> builder)
        {


            // One-to-one relationship between Employer and User
            builder.HasOne(e => e.User)
                   .WithOne(u => u.Employer)
                   .HasForeignKey<Employer>(e => e.EmployerId);

            // One-to-many relationship between Employer and Job
            builder.HasMany(e => e.JobListings)
                   .WithOne(j => j.Employer)
                   .HasForeignKey(j => j.EmployerId);

            // One-to-many relationship between Employer and Application
            builder.HasMany(e => e.JobApplicationsAsEmployer)
                   .WithOne(a => a.Employer)
                   .HasForeignKey(a => a.EmployerId);
            // Add other Employer relationships as needed
        }

    }
}

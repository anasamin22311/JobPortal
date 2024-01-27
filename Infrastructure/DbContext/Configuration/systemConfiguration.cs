using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using JobPortal.Domain;
namespace JobPortal.Infrastructure.DbContext.Configuration
{
    public class systemConfiguration : IEntityTypeConfiguration<system>
    {
        public void Configure(EntityTypeBuilder<system> builder)
        {
            // One-to-many relationship between system and Notification
                builder.HasMany(s => s.Notifications)
                .WithOne(n => n.system)
                .HasForeignKey(n => n.SystemId);
            // One-to-many relationship between system and Feedback
            builder.HasMany(s => s.Feedbacks)
                .WithOne(f => f.System)
                .HasForeignKey(f => f.SystemId);
        }
    }
}


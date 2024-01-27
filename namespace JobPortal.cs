namespace JobPortal.Models
{
    public enum ApplicationStatus { Pending, Accepted, Rejected }
}

using JobPortal.Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace JobPortal.Domain
{
    public class Category : BaseEntity { [Required] public string CategoryName { get; set; } public string Description { get; set; } public ICollection<Job> Jobs { get; set; } }

    public class Company : BaseEntity { [Required] public string CompanyName { get; set; } [Required] public int IndustryID { get; set; } [Required] public int LocationID { get; set; } [Required] public int Size { get; set; } public string Description { get; set; } public Industry Industry { get; set; } public Location Location { get; set; } public ICollection<Employer> Employers { get; set; } public ICollection<Job> Jobs { get; set; } }

    public class EducationLevel : BaseEntity { [Required] public string EducationLevelName { get; set; } [StringLength(500)] public string Description { get; set; } public ICollection<Job> Jobs { get; set; } }

    public class Employer { public int EmployerID { get; set; } [Required] [StringLength(100, MinimumLength = 3)] public string CompanyName { get; set; } [Required] [StringLength(15, MinimumLength = 9, ErrorMessage = "Please enter a valid contact number.")] public string Contact { get; set; } public User User { get; set; } public ICollection<Job> JobListings { get; set; } public ICollection<JobApplication> JobApplications { get; set; } }

    public class ExperienceLevel : BaseEntity { [Required] public string ExperienceLevelName { get; set; } [StringLength(500)] public string Description { get; set; } public ICollection<Job> Jobs { get; set; } }

    public class Feedback : BaseEntity { [Required] public int SenderID { get; set; } [Required] public int ReceiverID { get; set; } [Required] public string Message { get; set; } [DataType(DataType.DateTime)] public DateTime Timestamp { get; set; } public User Sender { get; set; } public User Receiver { get; set; } public System System { get; set; } }

    public class Industry : BaseEntity { [Required] [StringLength(100, MinimumLength = 3)] public string IndustryName { get; set; } [StringLength(500)] public string Description { get; set; } public ICollection<Job> Jobs { get; set; } }

    public partial class Job : BaseEntity { [Required] public string Title { get; set; } [Required] public string Description { get; set; } [Required] public int LocationID { get; set; } public int? SalaryRangeID { get; set; } [Required] public string Requirements { get; set; } [DataType(DataType.Date)] public DateTime DatePosted { get; set; } [DataType(DataType.Date)] public DateTime Deadline { get; set; } public Location Location { get; set; } public SalaryRange SalaryRange { get; set; } public Employer Employer { get; set; } public ICollection<JobApplication> JobApplications { get; set; } public ICollection<Category> Categories { get; set; } public ICollection<Industry> Industries { get; set; } public ICollection<ExperienceLevel> ExperienceLevels { get; set; } public ICollection<EducationLevel> EducationLevels { get; set; } public ICollection<Company> Companies { get; set; } public ICollection<Tag> Tags { get; set; } }

    public class JobApplication : BaseEntity { [Required] public int CandidateID { get; set; } [Required] public int JobID { get; set; } [Required] public string Resume { get; set; } [DataType(DataType.MultilineText)] public string CoverLetter { get; set; } [Required] public ApplicationStatus ApplicationStatus { get; set; } public User Candidate { get; set; } public Job Job { get; set; } }

    public class Location : BaseEntity { [Required] public string LocationName { get; set; } [Required] [StringLength(50)] public string Region { get; set; } [Required] [StringLength(50)] public string Country { get; set; } public ICollection<Job> Jobs { get; set; } }

    public class Notification : BaseEntity { [Required] public int SenderID { get; set; } [Required] public int ReceiverID { get; set; } [Required] public string Message { get; set; } [DataType(DataType.DateTime)] public DateTime Timestamp { get; set; } [Required] public Status Status { get; set; } public User Sender { get; set; } public User Receiver { get; set; } public System System { get; set; } }

    public enum Role { Candidate, Employer }

    public class SalaryRange : BaseEntity { [Required] [Range(0, 1000000, ErrorMessage = "MinimumSalary must be between 0 and 1,000,000")] public decimal MinimumSalary { get; set; } [Required] [Range(0, 1000000, ErrorMessage = "MaximumSalary must be between 0 and 1,000,000")] public decimal MaximumSalary { get; set; } public ICollection<Job> Jobs { get; set; } }

    public class Skill : BaseEntity { [Required] public string SkillName { get; set; } [Required] public SkillLevel SkillLevel { get; set; } public ICollection<User> Candidates { get; set; } public ICollection<Job> Jobs { get; set; } }

    public enum SkillLevel { Beginner, Intermediate, Advanced, Expert }

    public enum Status { Unread, Read }

    public class System : BaseEntity { [Required] public string ConfigurationSettings { get; set; } [Required] public string Logs { get; set; } public ICollection<Feedback> Feedbacks { get; set; } public ICollection<Notification> Notifications { get; set; } }

    public class Tag : BaseEntity { [Required] public string TagName { get; set; } }

    using Microsoft.AspNetCore.Identity;
    using System.ComponentModel.DataAnnotations;

    public class User : IdentityUser { [Required] public Role Role { get; set; } [Required] [StringLength(100, MinimumLength = 3)] public string Name { get; set; } [Required] [StringLength(15, MinimumLength = 9, ErrorMessage = "Please enter a valid contact number.")] public string Contact { get; set; } public ICollection<JobApplication> JobApplications { get; set; } public ICollection<Feedback> Feedbacks { get; set; } public ICollection<Notification> Notifications { get; set; } public int? EmployerId { get; set; } public Employer Employer { get; set; } }
    public class BaseEntity{public int id { get; set; }}
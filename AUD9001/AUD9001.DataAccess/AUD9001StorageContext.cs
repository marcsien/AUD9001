using AUD9001.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace AUD9001.DataAccess
{
    public class AUD9001StorageContext : DbContext
    {
        public AUD9001StorageContext(DbContextOptions<AUD9001StorageContext> opt ) : base(opt)
        {

        }

        public DbSet<Process> Processes { get; set; }
        public DbSet<Resource> Resources { get; set; }
        public DbSet<AcceptanceCriteria> AcceptanceCriterias { get; set; }
        public DbSet<Action> Actions { get; set; }
        public DbSet<Attachment> Attachments { get; set; }
        public DbSet<Attension> Attensions { get; set; }
        public DbSet<Audit> Audits { get; set; }
        public DbSet<AuditType> AuditTypes { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Document> Documents { get; set; }
        public DbSet<DocVersion> DocVersions { get; set; }
        public DbSet<Expectation> Expectations { get; set; }
        public DbSet<Factor> Factors { get; set; }
        public DbSet<Inconsistency> Inconsistencies { get; set; }
        public DbSet<Input> Inputs { get; set; }
        public DbSet<InterestedPerson> InterestedPeople { get; set; }
        public DbSet<ManagementReview> ManagementReviews { get; set; }
        public DbSet<Observation> Observations { get; set; }
        public DbSet<Output> Outputs { get; set; }
        public DbSet<Permission> Permissions { get; set; }
        public DbSet<ProcessRequirement> ProcessRequirements { get; set; }
        public DbSet<RecommendedAction> RecommendedActions { get; set; }
        public DbSet<Requirement> Requirements { get; set; }
        public DbSet<ResourceType> ResourceTypes { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<StrategicPositionAnalysis> StrategicPositionAnalyses { get; set; }
        public DbSet<Target> Targets { get; set; }
        public DbSet<User> Users { get; set; }


}
}

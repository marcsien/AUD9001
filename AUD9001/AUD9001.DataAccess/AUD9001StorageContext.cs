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
        public DbSet<Attention> Attensions { get; set; }
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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = 1,
                    Name = "Marcin",
                    Surname = "Sienicki",
                    Position = "Developer",
                    Login = "marcsien",
                    Password = "1234",
                    Email = "tst@tst.pl",
                });





            modelBuilder.Entity<Company>().HasData(
                new Company
                {
                    Id = 1,
                    Name = "FirmaTestowa",
                    Description = "Testowa Firma",
                    Address = "Graniczna 1",
                    Owner = "Marcin Sienicki"
                });





            modelBuilder.Entity<Process>().HasData(
                new Process
                {
                    Id = 1,
                    Name = "Produkcja",
                    Description = "Proces produkcyjny",
                    CompanyId = 1
                },
                new Process
                {
                    Id = 2,
                    Name = "Kontrola Jakości",
                    Description = "Proces kontrolujący jakość",
                    CompanyId = 1
                } 
                );





            modelBuilder.Entity<Input>().HasData(
                new Input { Id = 1, Name = "DummyInput1", AdditionDate = System.DateTime.Now, Description = "DummyInputDescription1", ProcessId = 1 },
                new Input { Id = 2, Name = "DummyInput2", AdditionDate = System.DateTime.Now, Description = "DummyInputDescription2", ProcessId = 1 },
                new Input { Id = 3, Name = "DummyInput3", AdditionDate = System.DateTime.Now, Description = "DummyInputDescription3", ProcessId = 1 },
                new Input { Id = 4, Name = "DummyInput4", AdditionDate = System.DateTime.Now, Description = "DummyInputDescription4", ProcessId = 2 },
                new Input { Id = 5, Name = "DummyInput5", AdditionDate = System.DateTime.Now, Description = "DummyInputDescription5", ProcessId = 2 },
                new Input { Id = 6, Name = "DummyInput6", AdditionDate = System.DateTime.Now, Description = "DummyInputDescription6", ProcessId = 2 }
                );





            modelBuilder.Entity<Output>().HasData(
                new Output { Id = 1, Name = "DummyOutput1", AdditionDate = System.DateTime.Now, Description = "DummyOutputDescription1", ProcessId = 1 },
                new Output { Id = 2, Name = "DummyOutput1", AdditionDate = System.DateTime.Now, Description = "DummyOutputDescription1", ProcessId = 1 },
                new Output { Id = 3, Name = "DummyOutput1", AdditionDate = System.DateTime.Now, Description = "DummyOutputDescription1", ProcessId = 1 },
                new Output { Id = 4, Name = "DummyOutput1", AdditionDate = System.DateTime.Now, Description = "DummyOutputDescription1", ProcessId = 2 },
                new Output { Id = 5, Name = "DummyOutput1", AdditionDate = System.DateTime.Now, Description = "DummyOutputDescription1", ProcessId = 2 },
                new Output { Id = 6, Name = "DummyOutput1", AdditionDate = System.DateTime.Now, Description = "DummyOutputDescription1", ProcessId = 2 }
                );






            modelBuilder.Entity<ManagementReview>().HasData(
                new ManagementReview { Id = 1, Date = System.DateTime.Now, Number = 1, CompanyId = 1},
                new ManagementReview { Id = 2, Date = System.DateTime.Now, Number = 2, CompanyId = 1 },
                new ManagementReview { Id = 3, Date = System.DateTime.Now, Number = 3, CompanyId = 1 }
                );


        }
    }
}

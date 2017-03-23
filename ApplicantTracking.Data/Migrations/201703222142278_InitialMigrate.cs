namespace ApplicantTracking.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialMigrate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Applicants",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FullName = c.String(),
                        JobTitle = c.String(),
                        HiringStatus = c.String(),
                        AppliedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.JobPosts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        JobTitle = c.String(),
                        Description = c.String(),
                        DateCreated = c.DateTime(nullable: false),
                        IsClosed = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.JobPostApplicants",
                c => new
                    {
                        JobPostId = c.Int(nullable: false),
                        ApplicantId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.JobPostId, t.ApplicantId })
                .ForeignKey("dbo.JobPosts", t => t.JobPostId, cascadeDelete: true)
                .ForeignKey("dbo.Applicants", t => t.ApplicantId, cascadeDelete: true)
                .Index(t => t.JobPostId)
                .Index(t => t.ApplicantId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.JobPostApplicants", "ApplicantId", "dbo.Applicants");
            DropForeignKey("dbo.JobPostApplicants", "JobPostId", "dbo.JobPosts");
            DropIndex("dbo.JobPostApplicants", new[] { "ApplicantId" });
            DropIndex("dbo.JobPostApplicants", new[] { "JobPostId" });
            DropTable("dbo.JobPostApplicants");
            DropTable("dbo.JobPosts");
            DropTable("dbo.Applicants");
        }
    }
}

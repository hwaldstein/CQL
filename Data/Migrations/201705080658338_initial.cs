namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CourseSections",
                c => new
                    {
                        Key = c.Long(nullable: false, identity: true),
                        CourseSectionId = c.Long(nullable: false),
                        Department = c.Int(nullable: false),
                        CourseNumber = c.Int(nullable: false),
                        CourseTitle = c.String(),
                        IsEngineeringBeCreative = c.Boolean(nullable: false),
                        IsHistoricalPerspectives = c.Boolean(nullable: false),
                        IsInternationalAndGlobalIssues = c.Boolean(nullable: false),
                        IsInterpretationOfLiterature = c.Boolean(nullable: false),
                        IsLiteraryVisualAndPerformingArts = c.Boolean(nullable: false),
                        IsNaturalSciencesLabOnly = c.Boolean(nullable: false),
                        IsNaturalSciencesWithLab = c.Boolean(nullable: false),
                        IsNaturalSciencesWithoutLab = c.Boolean(nullable: false),
                        IsQuantitativeOrFormalReasoning = c.Boolean(nullable: false),
                        IsRhetoric = c.Boolean(nullable: false),
                        IsRhetoricSpeech = c.Boolean(nullable: false),
                        IsRhetoricWriting = c.Boolean(nullable: false),
                        IsSocialSciences = c.Boolean(nullable: false),
                        IsValuesSocietyAndDiversity = c.Boolean(nullable: false),
                        IsWorldLanguagesFirstLevelProficiency = c.Boolean(nullable: false),
                        IsWorldLanguagesSecondLevelProficiency = c.Boolean(nullable: false),
                        IsWorldLanguagesFourthLevelProficiency = c.Boolean(nullable: false),
                        IsHonors = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Key)
                .Index(t => t.CourseSectionId, unique: true);
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.CourseSections", new[] { "CourseSectionId" });
            DropTable("dbo.CourseSections");
        }
    }
}

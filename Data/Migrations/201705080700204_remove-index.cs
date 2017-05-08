namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removeindex : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.CourseSections", new[] { "CourseSectionId" });
        }
        
        public override void Down()
        {
            CreateIndex("dbo.CourseSections", "CourseSectionId", unique: true);
        }
    }
}

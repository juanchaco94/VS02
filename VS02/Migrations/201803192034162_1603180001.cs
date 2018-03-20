namespace VS02.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _1603180001 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.trainingPrograms", "name", c => c.String(nullable: false, maxLength: 100));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.trainingPrograms", "name", c => c.String(nullable: false, maxLength: 30));
        }
    }
}

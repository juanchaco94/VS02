namespace VS02.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class VS0001 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.data", "description", c => c.String(maxLength: 30));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.data", "description", c => c.String(nullable: false, maxLength: 30));
        }
    }
}

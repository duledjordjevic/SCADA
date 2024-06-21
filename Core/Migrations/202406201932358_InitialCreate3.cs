namespace Core.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate3 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.TagEntities", "Type", c => c.String(unicode: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.TagEntities", "Type", c => c.Int(nullable: false));
        }
    }
}

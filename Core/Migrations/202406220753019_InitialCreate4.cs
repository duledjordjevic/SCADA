namespace Core.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class InitialCreate4 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ActivatedAlarms", "Value", c => c.Double(nullable: false));
        }

        public override void Down()
        {
            DropColumn("dbo.ActivatedAlarms", "Value");
        }
    }
}

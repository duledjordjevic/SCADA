namespace Core.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class InitialCreate1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ActivatedAlarms",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    Alarm_PriorityType = c.Int(nullable: false),
                    Alarm_Priority = c.Int(nullable: false),
                    Alarm_Threshold = c.Double(nullable: false),
                    Alarm_TagName = c.String(unicode: false),
                    TriggeredOn = c.DateTime(nullable: false, precision: 0),
                })
                .PrimaryKey(t => t.Id);

        }

        public override void Down()
        {
            DropTable("dbo.ActivatedAlarms");
        }
    }
}

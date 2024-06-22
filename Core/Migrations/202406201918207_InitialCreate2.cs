namespace Core.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class InitialCreate2 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TagEntities",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    Type = c.Int(nullable: false),
                    TagName = c.String(unicode: false),
                    Value = c.Double(nullable: false),
                    Timestamp = c.DateTime(nullable: false, precision: 0),
                })
                .PrimaryKey(t => t.Id);

        }

        public override void Down()
        {
            DropTable("dbo.TagEntities");
        }
    }
}

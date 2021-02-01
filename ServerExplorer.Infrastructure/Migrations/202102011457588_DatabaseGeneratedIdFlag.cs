namespace ServerExplorer.Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DatabaseGeneratedIdFlag : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Servers");
            AlterColumn("dbo.Servers", "Id", c => c.Guid(nullable: false, identity: true));
            AddPrimaryKey("dbo.Servers", "Id");
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.Servers");
            AlterColumn("dbo.Servers", "Id", c => c.Guid(nullable: false));
            AddPrimaryKey("dbo.Servers", "Id");
        }
    }
}

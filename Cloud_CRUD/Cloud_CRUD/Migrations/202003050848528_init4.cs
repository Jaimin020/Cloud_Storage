namespace Cloud_CRUD.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init4 : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Files");
            AlterColumn("dbo.Files", "Id", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Files", "Id");
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.Files");
            AlterColumn("dbo.Files", "Id", c => c.String(nullable: false, maxLength: 128));
            AddPrimaryKey("dbo.Files", "Id");
        }
    }
}

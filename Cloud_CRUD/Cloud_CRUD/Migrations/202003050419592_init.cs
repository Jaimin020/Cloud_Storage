namespace Cloud_CRUD.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Files",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        name = c.String(nullable: false),
                        extention = c.String(nullable: false),
                        data = c.Byte(nullable: false),
                        user_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.User_Details", t => t.user_Id)
                .Index(t => t.user_Id);
            
            CreateTable(
                "dbo.User_Details",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        name = c.String(nullable: false),
                        Email = c.String(nullable: false),
                        Password = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Files", "user_Id", "dbo.User_Details");
            DropIndex("dbo.Files", new[] { "user_Id" });
            DropTable("dbo.User_Details");
            DropTable("dbo.Files");
        }
    }
}

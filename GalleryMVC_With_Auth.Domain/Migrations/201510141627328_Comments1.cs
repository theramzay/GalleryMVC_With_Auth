namespace GalleryMVC_With_Auth.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Comments1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Comments", "User_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Comments", new[] { "User_Id" });
            DropColumn("dbo.Comments", "UserId");
            RenameColumn(table: "dbo.Comments", name: "User_Id", newName: "UserId");
            AlterColumn("dbo.Comments", "UserId", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.Comments", "UserId", c => c.String(nullable: false, maxLength: 128));
            CreateIndex("dbo.Comments", "UserId");
            AddForeignKey("dbo.Comments", "UserId", "dbo.AspNetUsers", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Comments", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.Comments", new[] { "UserId" });
            AlterColumn("dbo.Comments", "UserId", c => c.String(maxLength: 128));
            AlterColumn("dbo.Comments", "UserId", c => c.Int(nullable: false));
            RenameColumn(table: "dbo.Comments", name: "UserId", newName: "User_Id");
            AddColumn("dbo.Comments", "UserId", c => c.Int(nullable: false));
            CreateIndex("dbo.Comments", "User_Id");
            AddForeignKey("dbo.Comments", "User_Id", "dbo.AspNetUsers", "Id");
        }
    }
}

namespace GalleryMVC_With_Auth.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Comments : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Comments", "User_Id", c => c.String(maxLength: 128));
            AlterColumn("dbo.Comments", "UserId", c => c.Int(nullable: false));
            AlterColumn("dbo.Comments", "PictureID", c => c.Int(nullable: false));
            CreateIndex("dbo.Comments", "PictureID");
            CreateIndex("dbo.Comments", "User_Id");
            AddForeignKey("dbo.Comments", "PictureID", "dbo.Pictures", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Comments", "User_Id", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Comments", "User_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Comments", "PictureID", "dbo.Pictures");
            DropIndex("dbo.Comments", new[] { "User_Id" });
            DropIndex("dbo.Comments", new[] { "PictureID" });
            AlterColumn("dbo.Comments", "PictureID", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.Comments", "UserId", c => c.String(nullable: false, maxLength: 128));
            DropColumn("dbo.Comments", "User_Id");
        }
    }
}

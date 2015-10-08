namespace GalleryMVC_With_Auth.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Tags_Update : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Pictures", "TagId", "dbo.Tags");
            DropIndex("dbo.Pictures", new[] { "TagId" });
            CreateTable(
                "dbo.TagPictures",
                c => new
                    {
                        Tag_Id = c.Int(nullable: false),
                        Picture_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Tag_Id, t.Picture_Id })
                .ForeignKey("dbo.Tags", t => t.Tag_Id, cascadeDelete: true)
                .ForeignKey("dbo.Pictures", t => t.Picture_Id, cascadeDelete: true)
                .Index(t => t.Tag_Id)
                .Index(t => t.Picture_Id);
            
            DropColumn("dbo.Pictures", "TagId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Pictures", "TagId", c => c.Int());
            DropForeignKey("dbo.TagPictures", "Picture_Id", "dbo.Pictures");
            DropForeignKey("dbo.TagPictures", "Tag_Id", "dbo.Tags");
            DropIndex("dbo.TagPictures", new[] { "Picture_Id" });
            DropIndex("dbo.TagPictures", new[] { "Tag_Id" });
            DropTable("dbo.TagPictures");
            CreateIndex("dbo.Pictures", "TagId");
            AddForeignKey("dbo.Pictures", "TagId", "dbo.Tags", "Id");
        }
    }
}

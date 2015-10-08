namespace GalleryMVC_With_Auth.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Tags_Update_Nav1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.TagPictures", "Tag_Id", "dbo.Tags");
            DropForeignKey("dbo.TagPictures", "Picture_Id", "dbo.Pictures");
            DropIndex("dbo.TagPictures", new[] { "Tag_Id" });
            DropIndex("dbo.TagPictures", new[] { "Picture_Id" });
            AddColumn("dbo.Pictures", "TagsId", c => c.Int(nullable: false));
            AddColumn("dbo.Pictures", "Tag_Id", c => c.Int());
            AddColumn("dbo.Pictures", "Tag_Id1", c => c.Int());
            AddColumn("dbo.Tags", "Picture_Id", c => c.Int());
            CreateIndex("dbo.Pictures", "Tag_Id");
            CreateIndex("dbo.Pictures", "Tag_Id1");
            CreateIndex("dbo.Tags", "Picture_Id");
            AddForeignKey("dbo.Pictures", "Tag_Id", "dbo.Tags", "Id");
            AddForeignKey("dbo.Pictures", "Tag_Id1", "dbo.Tags", "Id");
            AddForeignKey("dbo.Tags", "Picture_Id", "dbo.Pictures", "Id");
            DropColumn("dbo.Pictures", "TagsName");
            DropColumn("dbo.Tags", "PictureId");
            DropTable("dbo.TagPictures");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.TagPictures",
                c => new
                    {
                        Tag_Id = c.Int(nullable: false),
                        Picture_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Tag_Id, t.Picture_Id });
            
            AddColumn("dbo.Tags", "PictureId", c => c.Int(nullable: false));
            AddColumn("dbo.Pictures", "TagsName", c => c.String());
            DropForeignKey("dbo.Tags", "Picture_Id", "dbo.Pictures");
            DropForeignKey("dbo.Pictures", "Tag_Id1", "dbo.Tags");
            DropForeignKey("dbo.Pictures", "Tag_Id", "dbo.Tags");
            DropIndex("dbo.Tags", new[] { "Picture_Id" });
            DropIndex("dbo.Pictures", new[] { "Tag_Id1" });
            DropIndex("dbo.Pictures", new[] { "Tag_Id" });
            DropColumn("dbo.Tags", "Picture_Id");
            DropColumn("dbo.Pictures", "Tag_Id1");
            DropColumn("dbo.Pictures", "Tag_Id");
            DropColumn("dbo.Pictures", "TagsId");
            CreateIndex("dbo.TagPictures", "Picture_Id");
            CreateIndex("dbo.TagPictures", "Tag_Id");
            AddForeignKey("dbo.TagPictures", "Picture_Id", "dbo.Pictures", "Id", cascadeDelete: true);
            AddForeignKey("dbo.TagPictures", "Tag_Id", "dbo.Tags", "Id", cascadeDelete: true);
        }
    }
}

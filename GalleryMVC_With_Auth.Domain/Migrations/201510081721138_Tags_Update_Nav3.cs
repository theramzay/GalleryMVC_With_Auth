namespace GalleryMVC_With_Auth.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Tags_Update_Nav3 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Pictures", "Tag_Id", "dbo.Tags");
            DropForeignKey("dbo.Tags", "Picture_Id", "dbo.Pictures");
            DropIndex("dbo.Pictures", new[] { "Tag_Id" });
            DropIndex("dbo.Tags", new[] { "Picture_Id" });
            RenameColumn(table: "dbo.Pictures", name: "Tag_Id1", newName: "TagId");
            RenameIndex(table: "dbo.Pictures", name: "IX_Tag_Id1", newName: "IX_TagId");
            DropColumn("dbo.Pictures", "Tag_Id");
            DropColumn("dbo.Tags", "Picture_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Tags", "Picture_Id", c => c.Int());
            AddColumn("dbo.Pictures", "Tag_Id", c => c.Int());
            RenameIndex(table: "dbo.Pictures", name: "IX_TagId", newName: "IX_Tag_Id1");
            RenameColumn(table: "dbo.Pictures", name: "TagId", newName: "Tag_Id1");
            CreateIndex("dbo.Tags", "Picture_Id");
            CreateIndex("dbo.Pictures", "Tag_Id");
            AddForeignKey("dbo.Tags", "Picture_Id", "dbo.Pictures", "Id");
            AddForeignKey("dbo.Pictures", "Tag_Id", "dbo.Tags", "Id");
        }
    }
}

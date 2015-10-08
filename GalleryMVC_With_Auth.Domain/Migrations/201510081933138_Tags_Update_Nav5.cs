namespace GalleryMVC_With_Auth.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Tags_Update_Nav5 : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Pictures", name: "Tag_Id", newName: "TagId");
            RenameIndex(table: "dbo.Pictures", name: "IX_Tag_Id", newName: "IX_TagId");
            DropColumn("dbo.Pictures", "TagName");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Pictures", "TagName", c => c.String());
            RenameIndex(table: "dbo.Pictures", name: "IX_TagId", newName: "IX_Tag_Id");
            RenameColumn(table: "dbo.Pictures", name: "TagId", newName: "Tag_Id");
        }
    }
}

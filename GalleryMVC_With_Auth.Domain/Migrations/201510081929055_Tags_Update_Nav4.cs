namespace GalleryMVC_With_Auth.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Tags_Update_Nav4 : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Pictures", name: "TagId", newName: "Tag_Id");
            RenameIndex(table: "dbo.Pictures", name: "IX_TagId", newName: "IX_Tag_Id");
            AddColumn("dbo.Pictures", "TagName", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Pictures", "TagName");
            RenameIndex(table: "dbo.Pictures", name: "IX_Tag_Id", newName: "IX_TagId");
            RenameColumn(table: "dbo.Pictures", name: "Tag_Id", newName: "TagId");
        }
    }
}

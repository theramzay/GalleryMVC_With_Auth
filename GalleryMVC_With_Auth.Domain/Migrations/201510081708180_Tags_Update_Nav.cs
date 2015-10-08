namespace GalleryMVC_With_Auth.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Tags_Update_Nav : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Pictures", "TagsName", c => c.String());
            AddColumn("dbo.Tags", "PictureId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Tags", "PictureId");
            DropColumn("dbo.Pictures", "TagsName");
        }
    }
}

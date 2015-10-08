namespace GalleryMVC_With_Auth.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Tags_Update_Nav2 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Pictures", "TagsId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Pictures", "TagsId", c => c.Int(nullable: false));
        }
    }
}

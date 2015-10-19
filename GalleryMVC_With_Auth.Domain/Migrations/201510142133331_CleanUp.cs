namespace GalleryMVC_With_Auth.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CleanUp : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Pictures", "Category");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Pictures", "Category", c => c.String(nullable: false, maxLength: 50));
        }
    }
}

namespace GalleryMVC_With_Auth.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Comments2 : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Comments");
            AlterColumn("dbo.Comments", "Id", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Comments", "Id");
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.Comments");
            AlterColumn("dbo.Comments", "Id", c => c.String(nullable: false, maxLength: 128));
            AddPrimaryKey("dbo.Comments", "Id");
        }
    }
}

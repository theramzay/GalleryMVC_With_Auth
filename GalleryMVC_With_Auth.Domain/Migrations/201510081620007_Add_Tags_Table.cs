namespace GalleryMVC_With_Auth.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Add_Tags_Table : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Tags",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Pictures", "TagId", c => c.Int());
            CreateIndex("dbo.Pictures", "TagId");
            AddForeignKey("dbo.Pictures", "TagId", "dbo.Tags", "Id");
            DropColumn("dbo.Pictures", "Tag");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Pictures", "Tag", c => c.String(nullable: false, maxLength: 50));
            DropForeignKey("dbo.Pictures", "TagId", "dbo.Tags");
            DropIndex("dbo.Pictures", new[] { "TagId" });
            DropColumn("dbo.Pictures", "TagId");
            DropTable("dbo.Tags");
        }
    }
}

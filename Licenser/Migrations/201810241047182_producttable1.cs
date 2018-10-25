namespace Licenser.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class producttable1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Product",
                c => new
                    {
                        ProductId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Description = c.String(nullable: false),
                        HomePageUrl = c.String(),
                        DownloadUrl = c.String(),
                        Version = c.Int(nullable: false),
                        Status = c.String(),
                    })
                .PrimaryKey(t => t.ProductId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Product");
        }
    }
}

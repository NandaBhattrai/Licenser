namespace Licenser.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class productupdate : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Product", "Description", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Product", "Description", c => c.String(nullable: false));
        }
    }
}

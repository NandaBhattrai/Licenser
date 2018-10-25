namespace Licenser.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class productupdate1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Product", "Version", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Product", "Version", c => c.Int(nullable: false));
        }
    }
}

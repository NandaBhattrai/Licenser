namespace Licenser.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class studentdel : DbMigration
    {
        public override void Up()
        {
            DropTable("dbo.Student");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Student",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        DoB = c.DateTime(nullable: false),
                        Gender = c.Int(nullable: false),
                        Flag = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
    }
}

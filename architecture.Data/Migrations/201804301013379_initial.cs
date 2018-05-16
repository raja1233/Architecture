namespace architecture.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.People",
                c => new
                    {
                        PId = c.Long(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 300),
                        Age = c.Int(nullable: false),
                        dateOfBirth = c.DateTime(nullable: false),
                        IsDeleted = c.Boolean(),
                    })
                .PrimaryKey(t => t.PId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.People");
        }
    }
}

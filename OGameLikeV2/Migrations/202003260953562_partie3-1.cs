namespace OGameLikeV2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class partie31 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Buildings",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Name = c.String(maxLength: 20),
                        Level = c.Int(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Resources", "ResourceGenerator_Id", c => c.Long());
            CreateIndex("dbo.Resources", "ResourceGenerator_Id");
            AddForeignKey("dbo.Resources", "ResourceGenerator_Id", "dbo.Buildings", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Resources", "ResourceGenerator_Id", "dbo.Buildings");
            DropIndex("dbo.Resources", new[] { "ResourceGenerator_Id" });
            DropColumn("dbo.Resources", "ResourceGenerator_Id");
            DropTable("dbo.Buildings");
        }
    }
}

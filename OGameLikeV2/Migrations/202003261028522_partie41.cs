namespace OGameLikeV2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class partie41 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Configurations",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        SystemSolarNbr = c.Int(),
                        PlanetPerSolarSystem = c.Int(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Buildings", "Configuration_Id", c => c.Long());
            AddColumn("dbo.Resources", "Configuration_Id", c => c.Long());
            CreateIndex("dbo.Buildings", "Configuration_Id");
            CreateIndex("dbo.Resources", "Configuration_Id");
            AddForeignKey("dbo.Buildings", "Configuration_Id", "dbo.Configurations", "Id");
            AddForeignKey("dbo.Resources", "Configuration_Id", "dbo.Configurations", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Resources", "Configuration_Id", "dbo.Configurations");
            DropForeignKey("dbo.Buildings", "Configuration_Id", "dbo.Configurations");
            DropIndex("dbo.Resources", new[] { "Configuration_Id" });
            DropIndex("dbo.Buildings", new[] { "Configuration_Id" });
            DropColumn("dbo.Resources", "Configuration_Id");
            DropColumn("dbo.Buildings", "Configuration_Id");
            DropTable("dbo.Configurations");
        }
    }
}

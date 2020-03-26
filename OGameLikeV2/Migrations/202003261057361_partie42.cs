namespace OGameLikeV2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class partie42 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Buildings", "Configuration_Id", "dbo.Configurations");
            DropForeignKey("dbo.Resources", "Configuration_Id", "dbo.Configurations");
            DropIndex("dbo.Buildings", new[] { "Configuration_Id" });
            DropIndex("dbo.Resources", new[] { "Configuration_Id" });
            CreateTable(
                "dbo.ConfigJSONs",
                c => new
                    {
                        Key = c.String(nullable: false, maxLength: 128),
                        Data = c.String(),
                    })
                .PrimaryKey(t => t.Key);
            
            DropColumn("dbo.Buildings", "Configuration_Id");
            DropColumn("dbo.Resources", "Configuration_Id");
            DropTable("dbo.Configurations");
        }
        
        public override void Down()
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
            
            AddColumn("dbo.Resources", "Configuration_Id", c => c.Long());
            AddColumn("dbo.Buildings", "Configuration_Id", c => c.Long());
            DropTable("dbo.ConfigJSONs");
            CreateIndex("dbo.Resources", "Configuration_Id");
            CreateIndex("dbo.Buildings", "Configuration_Id");
            AddForeignKey("dbo.Resources", "Configuration_Id", "dbo.Configurations", "Id");
            AddForeignKey("dbo.Buildings", "Configuration_Id", "dbo.Configurations", "Id");
        }
    }
}

namespace GuestlogixDal.Migrations
{
    using System.Data.Entity.Migrations;
    
    public partial class InitialContext : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Airlines",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Code2 = c.String(),
                        Code3 = c.String(),
                        Country = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Routes",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        AirlineId = c.String(maxLength: 128),
                        Origin = c.String(maxLength: 128),
                        Destination = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Airlines", t => t.AirlineId)
                .ForeignKey("dbo.Airports", t => t.Destination)
                .ForeignKey("dbo.Airports", t => t.Origin)
                .Index(t => t.AirlineId)
                .Index(t => t.Origin)
                .Index(t => t.Destination);
            
            CreateTable(
                "dbo.Airports",
                c => new
                    {
                        Iata3 = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                        City = c.String(),
                        Country = c.String(),
                        Longitude = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Latitude = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Iata3);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Routes", "Origin", "dbo.Airports");
            DropForeignKey("dbo.Routes", "Destination", "dbo.Airports");
            DropForeignKey("dbo.Routes", "AirlineId", "dbo.Airlines");
            DropIndex("dbo.Routes", new[] { "Destination" });
            DropIndex("dbo.Routes", new[] { "Origin" });
            DropIndex("dbo.Routes", new[] { "AirlineId" });
            DropTable("dbo.Airports");
            DropTable("dbo.Routes");
            DropTable("dbo.Airlines");
        }
    }
}

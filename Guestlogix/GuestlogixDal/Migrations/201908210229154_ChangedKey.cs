namespace GuestlogixDal.Migrations
{
    using System.Data.Entity.Migrations;
    
    public partial class ChangedKey : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Routes", "AirlineId", "dbo.Airlines");
            DropPrimaryKey("dbo.Airlines");
            AlterColumn("dbo.Airlines", "Id", c => c.String());
            AlterColumn("dbo.Airlines", "Code2", c => c.String(nullable: false, maxLength: 128));
            AddPrimaryKey("dbo.Airlines", "Code2");
            AddForeignKey("dbo.Routes", "AirlineId", "dbo.Airlines", "Code2");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Routes", "AirlineId", "dbo.Airlines");
            DropPrimaryKey("dbo.Airlines");
            AlterColumn("dbo.Airlines", "Code2", c => c.String());
            AlterColumn("dbo.Airlines", "Id", c => c.String(nullable: false, maxLength: 128));
            AddPrimaryKey("dbo.Airlines", "Id");
            AddForeignKey("dbo.Routes", "AirlineId", "dbo.Airlines", "Id");
        }
    }
}

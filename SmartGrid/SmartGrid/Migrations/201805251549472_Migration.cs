namespace SmartGrid.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Migration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.SmartGrid",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Type = c.String(unicode: false),
                        Smartmeter = c.String(unicode: false),
                        ProduktionsType = c.String(unicode: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.SmartGrid");
        }
    }
}

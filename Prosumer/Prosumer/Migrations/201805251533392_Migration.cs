namespace Prosumer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Migration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.00:00",
                c => new
                {
                    Id = c.Int(nullable: false),
                    Consume = c.String(unicode: false),
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Prosumers", t => t.Id)
                .Index(t => t.Id);

            CreateTable(
                "dbo.Prosumers",
                c => new
                {
                    Id = c.Int(nullable: false),
                })
                .PrimaryKey(t => t.Id);

            CreateTable(
                "dbo.01:00",
                c => new
                {
                    Id = c.Int(nullable: false),
                    Consume = c.String(unicode: false),
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Prosumers", t => t.Id)
                .Index(t => t.Id);

            CreateTable(
                "dbo.02:00",
                c => new
                {
                    Id = c.Int(nullable: false),
                    Consume = c.String(unicode: false),
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Prosumers", t => t.Id)
                .Index(t => t.Id);

            CreateTable(
                "dbo.03:00",
                c => new
                {
                    Id = c.Int(nullable: false),
                    Consume = c.String(unicode: false),
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Prosumers", t => t.Id)
                .Index(t => t.Id);

            CreateTable(
                "dbo.04:00",
                c => new
                {
                    Id = c.Int(nullable: false),
                    Consume = c.String(unicode: false),
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Prosumers", t => t.Id)
                .Index(t => t.Id);

            CreateTable(
                "dbo.05:00",
                c => new
                {
                    Id = c.Int(nullable: false),
                    Consume = c.String(unicode: false),
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Prosumers", t => t.Id)
                .Index(t => t.Id);

            CreateTable(
                "dbo.06:00",
                c => new
                {
                    Id = c.Int(nullable: false),
                    Consume = c.String(unicode: false),
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Prosumers", t => t.Id)
                .Index(t => t.Id);

            CreateTable(
                "dbo.07:00",
                c => new
                {
                    Id = c.Int(nullable: false),
                    Consume = c.String(unicode: false),
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Prosumers", t => t.Id)
                .Index(t => t.Id);

            CreateTable(
                "dbo.08:00",
                c => new
                {
                    Id = c.Int(nullable: false),
                    Consume = c.String(unicode: false),
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Prosumers", t => t.Id)
                .Index(t => t.Id);

            CreateTable(
                "dbo.09:00",
                c => new
                {
                    Id = c.Int(nullable: false),
                    Consume = c.String(unicode: false),
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Prosumers", t => t.Id)
                .Index(t => t.Id);

            CreateTable(
                "dbo.10:00",
                c => new
                {
                    Id = c.Int(nullable: false),
                    Consume = c.String(unicode: false),
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Prosumers", t => t.Id)
                .Index(t => t.Id);

            CreateTable(
                "dbo.11:00",
                c => new
                {
                    Id = c.Int(nullable: false),
                    Consume = c.String(unicode: false),
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Prosumers", t => t.Id)
                .Index(t => t.Id);

            CreateTable(
                "dbo.12:00",
                c => new
                {
                    Id = c.Int(nullable: false),
                    Consume = c.String(unicode: false),
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Prosumers", t => t.Id)
                .Index(t => t.Id);

            CreateTable(
                "dbo.13:00",
                c => new
                {
                    Id = c.Int(nullable: false),
                    Consume = c.String(unicode: false),
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Prosumers", t => t.Id)
                .Index(t => t.Id);

            CreateTable(
                "dbo.14:00",
                c => new
                {
                    Id = c.Int(nullable: false),
                    Consume = c.String(unicode: false),
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Prosumers", t => t.Id)
                .Index(t => t.Id);

            CreateTable(
                "dbo.15:00",
                c => new
                {
                    Id = c.Int(nullable: false),
                    Consume = c.String(unicode: false),
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Prosumers", t => t.Id)
                .Index(t => t.Id);

            CreateTable(
                "dbo.16:00",
                c => new
                {
                    Id = c.Int(nullable: false),
                    Consume = c.String(unicode: false),
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Prosumers", t => t.Id)
                .Index(t => t.Id);

            CreateTable(
                "dbo.17:00",
                c => new
                {
                    Id = c.Int(nullable: false),
                    Consume = c.String(unicode: false),
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Prosumers", t => t.Id)
                .Index(t => t.Id);

            CreateTable(
                "dbo.18:00",
                c => new
                {
                    Id = c.Int(nullable: false),
                    Consume = c.String(unicode: false),
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Prosumers", t => t.Id)
                .Index(t => t.Id);

            CreateTable(
                "dbo.19:00",
                c => new
                {
                    Id = c.Int(nullable: false),
                    Consume = c.String(unicode: false),
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Prosumers", t => t.Id)
                .Index(t => t.Id);

            CreateTable(
                "dbo.20:00",
                c => new
                {
                    Id = c.Int(nullable: false),
                    Consume = c.String(unicode: false),
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Prosumers", t => t.Id)
                .Index(t => t.Id);

            CreateTable(
                "dbo.21:00",
                c => new
                {
                    Id = c.Int(nullable: false),
                    Consume = c.String(unicode: false),
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Prosumers", t => t.Id)
                .Index(t => t.Id);

            CreateTable(
                "dbo.22:00",
                c => new
                {
                    Id = c.Int(nullable: false),
                    Consume = c.String(unicode: false),
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Prosumers", t => t.Id)
                .Index(t => t.Id);

            CreateTable(
                "dbo.23:00",
                c => new
                {
                    Id = c.Int(nullable: false),
                    Consume = c.String(unicode: false),
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Prosumers", t => t.Id)
                .Index(t => t.Id);

        }
        
        public override void Down()
        {
            DropForeignKey("dbo.23:00", "Id", "dbo.Prosumers");
            DropForeignKey("dbo.22:00", "Id", "dbo.Prosumers");
            DropForeignKey("dbo.21:00", "Id", "dbo.Prosumers");
            DropForeignKey("dbo.20:00", "Id", "dbo.Prosumers");
            DropForeignKey("dbo.19:00", "Id", "dbo.Prosumers");
            DropForeignKey("dbo.18:00", "Id", "dbo.Prosumers");
            DropForeignKey("dbo.17:00", "Id", "dbo.Prosumers");
            DropForeignKey("dbo.16:00", "Id", "dbo.Prosumers");
            DropForeignKey("dbo.15:00", "Id", "dbo.Prosumers");
            DropForeignKey("dbo.14:00", "Id", "dbo.Prosumers");
            DropForeignKey("dbo.13:00", "Id", "dbo.Prosumers");
            DropForeignKey("dbo.12:00", "Id", "dbo.Prosumers");
            DropForeignKey("dbo.11:00", "Id", "dbo.Prosumers");
            DropForeignKey("dbo.10:00", "Id", "dbo.Prosumers");
            DropForeignKey("dbo.09:00", "Id", "dbo.Prosumers");
            DropForeignKey("dbo.08:00", "Id", "dbo.Prosumers");
            DropForeignKey("dbo.07:00", "Id", "dbo.Prosumers");
            DropForeignKey("dbo.06:00", "Id", "dbo.Prosumers");
            DropForeignKey("dbo.05:00", "Id", "dbo.Prosumers");
            DropForeignKey("dbo.04:00", "Id", "dbo.Prosumers");
            DropForeignKey("dbo.03:00", "Id", "dbo.Prosumers");
            DropForeignKey("dbo.02:00", "Id", "dbo.Prosumers");
            DropForeignKey("dbo.01:00", "Id", "dbo.Prosumers");
            DropForeignKey("dbo.00:00", "Id", "dbo.Prosumers");
            DropIndex("dbo.23:00", new[] { "Id" });
            DropIndex("dbo.22:00", new[] { "Id" });
            DropIndex("dbo.21:00", new[] { "Id" });
            DropIndex("dbo.20:00", new[] { "Id" });
            DropIndex("dbo.19:00", new[] { "Id" });
            DropIndex("dbo.18:00", new[] { "Id" });
            DropIndex("dbo.17:00", new[] { "Id" });
            DropIndex("dbo.16:00", new[] { "Id" });
            DropIndex("dbo.15:00", new[] { "Id" });
            DropIndex("dbo.14:00", new[] { "Id" });
            DropIndex("dbo.13:00", new[] { "Id" });
            DropIndex("dbo.12:00", new[] { "Id" });
            DropIndex("dbo.11:00", new[] { "Id" });
            DropIndex("dbo.10:00", new[] { "Id" });
            DropIndex("dbo.09:00", new[] { "Id" });
            DropIndex("dbo.08:00", new[] { "Id" });
            DropIndex("dbo.07:00", new[] { "Id" });
            DropIndex("dbo.06:00", new[] { "Id" });
            DropIndex("dbo.05:00", new[] { "Id" });
            DropIndex("dbo.04:00", new[] { "Id" });
            DropIndex("dbo.03:00", new[] { "Id" });
            DropIndex("dbo.02:00", new[] { "Id" });
            DropIndex("dbo.01:00", new[] { "Id" });
            DropIndex("dbo.00:00", new[] { "Id" });
            DropTable("dbo.23:00");
            DropTable("dbo.22:00");
            DropTable("dbo.21:00");
            DropTable("dbo.20:00");
            DropTable("dbo.19:00");
            DropTable("dbo.18:00");
            DropTable("dbo.17:00");
            DropTable("dbo.16:00");
            DropTable("dbo.15:00");
            DropTable("dbo.14:00");
            DropTable("dbo.13:00");
            DropTable("dbo.12:00");
            DropTable("dbo.11:00");
            DropTable("dbo.10:00");
            DropTable("dbo.09:00");
            DropTable("dbo.08:00");
            DropTable("dbo.07:00");
            DropTable("dbo.06:00");
            DropTable("dbo.05:00");
            DropTable("dbo.04:00");
            DropTable("dbo.03:00");
            DropTable("dbo.02:00");
            DropTable("dbo.01:00");
            DropTable("dbo.Prosumers");
            DropTable("dbo.00:00");
        }
    }
}

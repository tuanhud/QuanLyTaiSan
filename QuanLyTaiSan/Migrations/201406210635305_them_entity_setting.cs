namespace QuanLyTaiSan.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class them_entity_setting : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.SETTINGS",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        key = c.String(nullable: false, maxLength: 100),
                        value = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .Index(t => t.key, unique: true);
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.SETTINGS", new[] { "key" });
            DropTable("dbo.SETTINGS");
        }
    }
}

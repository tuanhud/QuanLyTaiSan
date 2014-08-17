namespace QuanLyTaiSan.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class permission_framework : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.PERMISSIONS", new[] { "key" });
            CreateTable(
                "dbo.TANG_PERMISSION",
                c => new
                    {
                        id1 = c.Int(nullable: false),
                        id2 = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.id1, t.id2 })
                .ForeignKey("dbo.TANGS", t => t.id1, cascadeDelete: true)
                .ForeignKey("dbo.PERMISSIONS", t => t.id2, cascadeDelete: true)
                .Index(t => t.id1)
                .Index(t => t.id2);
            
            CreateTable(
                "dbo.PHONG_PERMISSION",
                c => new
                    {
                        id1 = c.Int(nullable: false),
                        id2 = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.id1, t.id2 })
                .ForeignKey("dbo.PHONGS", t => t.id1, cascadeDelete: true)
                .ForeignKey("dbo.PERMISSIONS", t => t.id2, cascadeDelete: true)
                .Index(t => t.id1)
                .Index(t => t.id2);
            
            CreateTable(
                "dbo.DAY_PERMISSION",
                c => new
                    {
                        id1 = c.Int(nullable: false),
                        id2 = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.id1, t.id2 })
                .ForeignKey("dbo.DAYS", t => t.id1, cascadeDelete: true)
                .ForeignKey("dbo.PERMISSIONS", t => t.id2, cascadeDelete: true)
                .Index(t => t.id1)
                .Index(t => t.id2);
            
            CreateTable(
                "dbo.COSO_PERMISSION",
                c => new
                    {
                        id1 = c.Int(nullable: false),
                        id2 = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.id1, t.id2 })
                .ForeignKey("dbo.COSOS", t => t.id1, cascadeDelete: true)
                .ForeignKey("dbo.PERMISSIONS", t => t.id2, cascadeDelete: true)
                .Index(t => t.id1)
                .Index(t => t.id2);
            
            AddColumn("dbo.PERMISSIONS", "stand_alone", c => c.Boolean(nullable: false));
            AddColumn("dbo.PERMISSIONS", "allow_or_deny", c => c.Boolean(nullable: false));
            AddColumn("dbo.PERMISSIONS", "recursive_to_child", c => c.Boolean(nullable: false));
            AddColumn("dbo.PERMISSIONS", "can_view", c => c.Boolean(nullable: false));
            AddColumn("dbo.PERMISSIONS", "can_edit", c => c.Boolean(nullable: false));
            AlterColumn("dbo.PERMISSIONS", "key", c => c.String());
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.COSO_PERMISSION", "id2", "dbo.PERMISSIONS");
            DropForeignKey("dbo.COSO_PERMISSION", "id1", "dbo.COSOS");
            DropForeignKey("dbo.DAY_PERMISSION", "id2", "dbo.PERMISSIONS");
            DropForeignKey("dbo.DAY_PERMISSION", "id1", "dbo.DAYS");
            DropForeignKey("dbo.PHONG_PERMISSION", "id2", "dbo.PERMISSIONS");
            DropForeignKey("dbo.PHONG_PERMISSION", "id1", "dbo.PHONGS");
            DropForeignKey("dbo.TANG_PERMISSION", "id2", "dbo.PERMISSIONS");
            DropForeignKey("dbo.TANG_PERMISSION", "id1", "dbo.TANGS");
            DropIndex("dbo.COSO_PERMISSION", new[] { "id2" });
            DropIndex("dbo.COSO_PERMISSION", new[] { "id1" });
            DropIndex("dbo.DAY_PERMISSION", new[] { "id2" });
            DropIndex("dbo.DAY_PERMISSION", new[] { "id1" });
            DropIndex("dbo.PHONG_PERMISSION", new[] { "id2" });
            DropIndex("dbo.PHONG_PERMISSION", new[] { "id1" });
            DropIndex("dbo.TANG_PERMISSION", new[] { "id2" });
            DropIndex("dbo.TANG_PERMISSION", new[] { "id1" });
            AlterColumn("dbo.PERMISSIONS", "key", c => c.String(nullable: false, maxLength: 100));
            DropColumn("dbo.PERMISSIONS", "can_edit");
            DropColumn("dbo.PERMISSIONS", "can_view");
            DropColumn("dbo.PERMISSIONS", "recursive_to_child");
            DropColumn("dbo.PERMISSIONS", "allow_or_deny");
            DropColumn("dbo.PERMISSIONS", "stand_alone");
            DropTable("dbo.COSO_PERMISSION");
            DropTable("dbo.DAY_PERMISSION");
            DropTable("dbo.PHONG_PERMISSION");
            DropTable("dbo.TANG_PERMISSION");
            CreateIndex("dbo.PERMISSIONS", "key", unique: true);
        }
    }
}

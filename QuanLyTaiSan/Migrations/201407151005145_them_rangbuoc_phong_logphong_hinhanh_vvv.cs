namespace QuanLyTaiSan.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class them_rangbuoc_phong_logphong_hinhanh_vvv : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.LOGPHONGS",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        ngay = c.DateTime(nullable: false),
                        tinhtrang_id = c.Int(nullable: false),
                        phong_id = c.Int(nullable: false),
                        quantrivien_id = c.Int(),
                        subId = c.String(),
                        mota = c.String(),
                        date_create = c.DateTime(),
                        date_modified = c.DateTime(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.QUANTRIVIENS", t => t.quantrivien_id)
                .ForeignKey("dbo.PHONGS", t => t.phong_id)
                .ForeignKey("dbo.TINHTRANGS", t => t.tinhtrang_id)
                .Index(t => t.ngay, unique: true, name: "nothing")
                .Index(t => t.tinhtrang_id)
                .Index(t => t.phong_id)
                .Index(t => t.quantrivien_id);
            
            AddColumn("dbo.HINHANHS", "logphong_id", c => c.Int());
            AddColumn("dbo.HINHANHS", "logthietbi_id", c => c.Int());
            AddColumn("dbo.PHONGS", "tinhtrang_id", c => c.Int());
            AddColumn("dbo.LOGTHIETBIS", "quantrivien_id", c => c.Int());
            CreateIndex("dbo.HINHANHS", "logphong_id");
            CreateIndex("dbo.HINHANHS", "logthietbi_id");
            CreateIndex("dbo.PHONGS", "tinhtrang_id");
            CreateIndex("dbo.LOGTHIETBIS", "quantrivien_id");
            AddForeignKey("dbo.HINHANHS", "logphong_id", "dbo.LOGPHONGS", "id");
            AddForeignKey("dbo.HINHANHS", "logthietbi_id", "dbo.LOGTHIETBIS", "id");
            AddForeignKey("dbo.LOGTHIETBIS", "quantrivien_id", "dbo.QUANTRIVIENS", "id");
            AddForeignKey("dbo.PHONGS", "tinhtrang_id", "dbo.TINHTRANGS", "id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.LOGPHONGS", "tinhtrang_id", "dbo.TINHTRANGS");
            DropForeignKey("dbo.LOGPHONGS", "phong_id", "dbo.PHONGS");
            DropForeignKey("dbo.PHONGS", "tinhtrang_id", "dbo.TINHTRANGS");
            DropForeignKey("dbo.LOGTHIETBIS", "quantrivien_id", "dbo.QUANTRIVIENS");
            DropForeignKey("dbo.LOGPHONGS", "quantrivien_id", "dbo.QUANTRIVIENS");
            DropForeignKey("dbo.HINHANHS", "logthietbi_id", "dbo.LOGTHIETBIS");
            DropForeignKey("dbo.HINHANHS", "logphong_id", "dbo.LOGPHONGS");
            DropIndex("dbo.LOGTHIETBIS", new[] { "quantrivien_id" });
            DropIndex("dbo.PHONGS", new[] { "tinhtrang_id" });
            DropIndex("dbo.LOGPHONGS", new[] { "quantrivien_id" });
            DropIndex("dbo.LOGPHONGS", new[] { "phong_id" });
            DropIndex("dbo.LOGPHONGS", new[] { "tinhtrang_id" });
            DropIndex("dbo.LOGPHONGS", "nothing");
            DropIndex("dbo.HINHANHS", new[] { "logthietbi_id" });
            DropIndex("dbo.HINHANHS", new[] { "logphong_id" });
            DropColumn("dbo.LOGTHIETBIS", "quantrivien_id");
            DropColumn("dbo.PHONGS", "tinhtrang_id");
            DropColumn("dbo.HINHANHS", "logthietbi_id");
            DropColumn("dbo.HINHANHS", "logphong_id");
            DropTable("dbo.LOGPHONGS");
        }
    }
}

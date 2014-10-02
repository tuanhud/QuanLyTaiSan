namespace TSCD.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dinhNghiaLaiSuTangGiamTaiSan : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.LOGTAISANS", newName: "LOGTANGGIAMTAISANS");
            CreateTable(
                "dbo.LOGSUATAISANS",
                c => new
                    {
                        id = c.Guid(nullable: false, identity: true),
                        ghichu = c.String(),
                        soluong = c.Int(nullable: false),
                        ngay = c.DateTime(),
                        chungtu_sohieu = c.String(),
                        chungtu_ngay = c.DateTime(),
                        cttaisan_parent_id = c.Guid(),
                        quantrivien_id = c.Guid(nullable: false),
                        taisan_id = c.Guid(nullable: false),
                        donviquanly_id = c.Guid(),
                        donvisudung_id = c.Guid(),
                        tinhtrang_id = c.Guid(nullable: false),
                        vitri_id = c.Guid(),
                        phong_id = c.Guid(),
                        subId = c.String(),
                        order = c.Long(),
                        mota = c.String(),
                        date_create = c.DateTime(),
                        date_modified = c.DateTime(),
                    })
                .PrimaryKey(t => t.id)
                .Index(t => t.cttaisan_parent_id)
                .Index(t => t.quantrivien_id)
                .Index(t => t.taisan_id)
                .Index(t => t.donviquanly_id)
                .Index(t => t.donvisudung_id)
                .Index(t => t.tinhtrang_id)
                .Index(t => t.vitri_id)
                .Index(t => t.phong_id);
            
            AddColumn("dbo.LOGTANGGIAMTAISANS", "tang_giam", c => c.Int(nullable: false));
            AddColumn("dbo.LOGTANGGIAMTAISANS", "tang_giam_donvi", c => c.Int(nullable: false));
            AddColumn("dbo.LOGTANGGIAMTAISANS", "chuyenden_chuyendi", c => c.Int(nullable: false));
            AddColumn("dbo.TINHTRANGS", "giam_taisan", c => c.Boolean(nullable: false));
            DropColumn("dbo.CTTAISANS", "isTang");
            DropColumn("dbo.CTTAISANS", "isChuyen");
            DropColumn("dbo.LOGTANGGIAMTAISANS", "isTang");
            DropColumn("dbo.LOGTANGGIAMTAISANS", "isChuyen");
        }
        
        public override void Down()
        {
            AddColumn("dbo.LOGTANGGIAMTAISANS", "isChuyen", c => c.Boolean(nullable: false));
            AddColumn("dbo.LOGTANGGIAMTAISANS", "isTang", c => c.Boolean(nullable: false));
            AddColumn("dbo.CTTAISANS", "isChuyen", c => c.Boolean(nullable: false));
            AddColumn("dbo.CTTAISANS", "isTang", c => c.Boolean(nullable: false));
            DropIndex("dbo.LOGSUATAISANS", new[] { "phong_id" });
            DropIndex("dbo.LOGSUATAISANS", new[] { "vitri_id" });
            DropIndex("dbo.LOGSUATAISANS", new[] { "tinhtrang_id" });
            DropIndex("dbo.LOGSUATAISANS", new[] { "donvisudung_id" });
            DropIndex("dbo.LOGSUATAISANS", new[] { "donviquanly_id" });
            DropIndex("dbo.LOGSUATAISANS", new[] { "taisan_id" });
            DropIndex("dbo.LOGSUATAISANS", new[] { "quantrivien_id" });
            DropIndex("dbo.LOGSUATAISANS", new[] { "cttaisan_parent_id" });
            DropColumn("dbo.TINHTRANGS", "giam_taisan");
            DropColumn("dbo.LOGTANGGIAMTAISANS", "chuyenden_chuyendi");
            DropColumn("dbo.LOGTANGGIAMTAISANS", "tang_giam_donvi");
            DropColumn("dbo.LOGTANGGIAMTAISANS", "tang_giam");
            DropTable("dbo.LOGSUATAISANS");
            RenameTable(name: "dbo.LOGTANGGIAMTAISANS", newName: "LOGTAISANS");
        }
    }
}

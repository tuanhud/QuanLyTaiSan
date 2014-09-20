namespace PTB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TCSD_base_vBeta : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TSCD_CHUTHE",
                c => new
                    {
                        id = c.Guid(nullable: false, identity: true),
                        ten = c.String(nullable: false),
                        parent_id = c.Guid(),
                        loaichuthe_id = c.Guid(nullable: false),
                        subId = c.String(),
                        order = c.Long(),
                        mota = c.String(),
                        date_create = c.DateTime(),
                        date_modified = c.DateTime(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.TSCD_CHUTHE", t => t.parent_id)
                .ForeignKey("dbo.TSCD_LOAICHUTHE", t => t.loaichuthe_id)
                .Index(t => t.parent_id)
                .Index(t => t.loaichuthe_id);
            
            CreateTable(
                "dbo.TSCD_CTTAISAN",
                c => new
                    {
                        id = c.Guid(nullable: false, identity: true),
                        soluong = c.Int(nullable: false),
                        nguongoc = c.String(),
                        ngay = c.DateTime(),
                        chungtu_sohieu = c.String(),
                        chungtu_ngay = c.DateTime(),
                        chuthequanly_id = c.Guid(nullable: false),
                        chuthesudung_id = c.Guid(nullable: false),
                        tinhtrang_id = c.Guid(nullable: false),
                        vitri_id = c.Guid(),
                        phong_id = c.Guid(),
                        taisan_id = c.Guid(nullable: false),
                        subId = c.String(),
                        order = c.Long(),
                        mota = c.String(),
                        date_create = c.DateTime(),
                        date_modified = c.DateTime(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.TSCD_CHUTHE", t => t.chuthequanly_id)
                .ForeignKey("dbo.TSCD_CHUTHE", t => t.chuthesudung_id)
                .ForeignKey("dbo.PHONGS", t => t.phong_id)
                .ForeignKey("dbo.TSCD_TAISAN", t => t.taisan_id)
                .ForeignKey("dbo.TINHTRANGS", t => t.tinhtrang_id)
                .ForeignKey("dbo.VITRIS", t => t.vitri_id)
                .Index(t => t.chuthequanly_id)
                .Index(t => t.chuthesudung_id)
                .Index(t => t.tinhtrang_id)
                .Index(t => t.vitri_id)
                .Index(t => t.phong_id)
                .Index(t => t.taisan_id);
            
            CreateTable(
                "dbo.TSCD_LOGTAISAN",
                c => new
                    {
                        id = c.Guid(nullable: false, identity: true),
                        soluong = c.Int(nullable: false),
                        chungtu_sohieu = c.String(),
                        chungtu_ngay = c.DateTime(),
                        quantrivien_id = c.Guid(nullable: false),
                        taisan_id = c.Guid(nullable: false),
                        chuthequanly_id = c.Guid(nullable: false),
                        chuthesudung_id = c.Guid(nullable: false),
                        tinhtrang_id = c.Guid(nullable: false),
                        subId = c.String(),
                        order = c.Long(),
                        mota = c.String(),
                        date_create = c.DateTime(),
                        date_modified = c.DateTime(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.TSCD_CHUTHE", t => t.chuthequanly_id)
                .ForeignKey("dbo.TSCD_CHUTHE", t => t.chuthesudung_id)
                .ForeignKey("dbo.QUANTRIVIENS", t => t.quantrivien_id)
                .ForeignKey("dbo.TSCD_TAISAN", t => t.taisan_id)
                .ForeignKey("dbo.TINHTRANGS", t => t.tinhtrang_id)
                .Index(t => t.quantrivien_id)
                .Index(t => t.taisan_id)
                .Index(t => t.chuthequanly_id)
                .Index(t => t.chuthesudung_id)
                .Index(t => t.tinhtrang_id);
            
            CreateTable(
                "dbo.TSCD_TAISAN",
                c => new
                    {
                        id = c.Guid(nullable: false, identity: true),
                        ten = c.String(nullable: false),
                        dongia = c.Long(nullable: false),
                        sonamsudung = c.Int(),
                        parent_id = c.Guid(),
                        loaitaisan_id = c.Guid(nullable: false),
                        subId = c.String(),
                        order = c.Long(),
                        mota = c.String(),
                        date_create = c.DateTime(),
                        date_modified = c.DateTime(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.TSCD_TAISAN", t => t.parent_id)
                .ForeignKey("dbo.TSCD_LOAITAISAN", t => t.loaitaisan_id)
                .Index(t => t.parent_id)
                .Index(t => t.loaitaisan_id);
            
            CreateTable(
                "dbo.TSCD_LOAITAISAN",
                c => new
                    {
                        id = c.Guid(nullable: false, identity: true),
                        huuhinh = c.Boolean(nullable: false),
                        ten = c.String(nullable: false, maxLength: 255),
                        donvitinh_id = c.Guid(),
                        parent_id = c.Guid(),
                        subId = c.String(),
                        order = c.Long(),
                        mota = c.String(),
                        date_create = c.DateTime(),
                        date_modified = c.DateTime(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.TSCD_LOAITAISAN", t => t.parent_id)
                .ForeignKey("dbo.TSCD_DONVITINH", t => t.donvitinh_id)
                .Index(t => t.ten, unique: true)
                .Index(t => t.donvitinh_id)
                .Index(t => t.parent_id);
            
            CreateTable(
                "dbo.TSCD_DONVITINH",
                c => new
                    {
                        id = c.Guid(nullable: false, identity: true),
                        ten = c.String(),
                        subId = c.String(),
                        order = c.Long(),
                        mota = c.String(),
                        date_create = c.DateTime(),
                        date_modified = c.DateTime(),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.TSCD_LOAICHUTHE",
                c => new
                    {
                        id = c.Guid(nullable: false, identity: true),
                        ten = c.String(nullable: false, maxLength: 255),
                        subId = c.String(),
                        order = c.Long(),
                        mota = c.String(),
                        date_create = c.DateTime(),
                        date_modified = c.DateTime(),
                    })
                .PrimaryKey(t => t.id)
                .Index(t => t.ten, unique: true);
            
            AddColumn("dbo.TINHTRANGS", "type", c => c.Int());
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TSCD_CHUTHE", "loaichuthe_id", "dbo.TSCD_LOAICHUTHE");
            DropForeignKey("dbo.TSCD_CTTAISAN", "vitri_id", "dbo.VITRIS");
            DropForeignKey("dbo.TSCD_CTTAISAN", "tinhtrang_id", "dbo.TINHTRANGS");
            DropForeignKey("dbo.TSCD_CTTAISAN", "taisan_id", "dbo.TSCD_TAISAN");
            DropForeignKey("dbo.TSCD_CTTAISAN", "phong_id", "dbo.PHONGS");
            DropForeignKey("dbo.TSCD_LOGTAISAN", "tinhtrang_id", "dbo.TINHTRANGS");
            DropForeignKey("dbo.TSCD_LOGTAISAN", "taisan_id", "dbo.TSCD_TAISAN");
            DropForeignKey("dbo.TSCD_TAISAN", "loaitaisan_id", "dbo.TSCD_LOAITAISAN");
            DropForeignKey("dbo.TSCD_LOAITAISAN", "donvitinh_id", "dbo.TSCD_DONVITINH");
            DropForeignKey("dbo.TSCD_LOAITAISAN", "parent_id", "dbo.TSCD_LOAITAISAN");
            DropForeignKey("dbo.TSCD_TAISAN", "parent_id", "dbo.TSCD_TAISAN");
            DropForeignKey("dbo.TSCD_LOGTAISAN", "quantrivien_id", "dbo.QUANTRIVIENS");
            DropForeignKey("dbo.TSCD_LOGTAISAN", "chuthesudung_id", "dbo.TSCD_CHUTHE");
            DropForeignKey("dbo.TSCD_LOGTAISAN", "chuthequanly_id", "dbo.TSCD_CHUTHE");
            DropForeignKey("dbo.TSCD_CTTAISAN", "chuthesudung_id", "dbo.TSCD_CHUTHE");
            DropForeignKey("dbo.TSCD_CTTAISAN", "chuthequanly_id", "dbo.TSCD_CHUTHE");
            DropForeignKey("dbo.TSCD_CHUTHE", "parent_id", "dbo.TSCD_CHUTHE");
            DropIndex("dbo.TSCD_LOAICHUTHE", new[] { "ten" });
            DropIndex("dbo.TSCD_LOAITAISAN", new[] { "parent_id" });
            DropIndex("dbo.TSCD_LOAITAISAN", new[] { "donvitinh_id" });
            DropIndex("dbo.TSCD_LOAITAISAN", new[] { "ten" });
            DropIndex("dbo.TSCD_TAISAN", new[] { "loaitaisan_id" });
            DropIndex("dbo.TSCD_TAISAN", new[] { "parent_id" });
            DropIndex("dbo.TSCD_LOGTAISAN", new[] { "tinhtrang_id" });
            DropIndex("dbo.TSCD_LOGTAISAN", new[] { "chuthesudung_id" });
            DropIndex("dbo.TSCD_LOGTAISAN", new[] { "chuthequanly_id" });
            DropIndex("dbo.TSCD_LOGTAISAN", new[] { "taisan_id" });
            DropIndex("dbo.TSCD_LOGTAISAN", new[] { "quantrivien_id" });
            DropIndex("dbo.TSCD_CTTAISAN", new[] { "taisan_id" });
            DropIndex("dbo.TSCD_CTTAISAN", new[] { "phong_id" });
            DropIndex("dbo.TSCD_CTTAISAN", new[] { "vitri_id" });
            DropIndex("dbo.TSCD_CTTAISAN", new[] { "tinhtrang_id" });
            DropIndex("dbo.TSCD_CTTAISAN", new[] { "chuthesudung_id" });
            DropIndex("dbo.TSCD_CTTAISAN", new[] { "chuthequanly_id" });
            DropIndex("dbo.TSCD_CHUTHE", new[] { "loaichuthe_id" });
            DropIndex("dbo.TSCD_CHUTHE", new[] { "parent_id" });
            DropColumn("dbo.TINHTRANGS", "type");
            DropTable("dbo.TSCD_LOAICHUTHE");
            DropTable("dbo.TSCD_DONVITINH");
            DropTable("dbo.TSCD_LOAITAISAN");
            DropTable("dbo.TSCD_TAISAN");
            DropTable("dbo.TSCD_LOGTAISAN");
            DropTable("dbo.TSCD_CTTAISAN");
            DropTable("dbo.TSCD_CHUTHE");
        }
    }
}

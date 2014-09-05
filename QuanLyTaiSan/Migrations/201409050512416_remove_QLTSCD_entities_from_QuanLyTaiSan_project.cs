namespace QuanLyTaiSan.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class remove_QLTSCD_entities_from_QuanLyTaiSan_project : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.TSCD_CHUTHE", "parent_id", "dbo.TSCD_CHUTHE");
            DropForeignKey("dbo.TSCD_CTTAISAN", "chuthequanly_id", "dbo.TSCD_CHUTHE");
            DropForeignKey("dbo.TSCD_CTTAISAN", "chuthesudung_id", "dbo.TSCD_CHUTHE");
            DropForeignKey("dbo.TSCD_LOGTAISAN", "chuthequanly_id", "dbo.TSCD_CHUTHE");
            DropForeignKey("dbo.TSCD_LOGTAISAN", "chuthesudung_id", "dbo.TSCD_CHUTHE");
            DropForeignKey("dbo.TSCD_LOGTAISAN", "quantrivien_id", "dbo.QUANTRIVIENS");
            DropForeignKey("dbo.TSCD_TAISAN", "parent_id", "dbo.TSCD_TAISAN");
            DropForeignKey("dbo.TSCD_LOAITAISAN", "parent_id", "dbo.TSCD_LOAITAISAN");
            DropForeignKey("dbo.TSCD_LOAITAISAN", "donvitinh_id", "dbo.TSCD_DONVITINH");
            DropForeignKey("dbo.TSCD_TAISAN", "loaitaisan_id", "dbo.TSCD_LOAITAISAN");
            DropForeignKey("dbo.TSCD_LOGTAISAN", "taisan_id", "dbo.TSCD_TAISAN");
            DropForeignKey("dbo.TSCD_LOGTAISAN", "tinhtrang_id", "dbo.TINHTRANGS");
            DropForeignKey("dbo.TSCD_CTTAISAN", "phong_id", "dbo.PHONGS");
            DropForeignKey("dbo.TSCD_CTTAISAN", "taisan_id", "dbo.TSCD_TAISAN");
            DropForeignKey("dbo.TSCD_CTTAISAN", "tinhtrang_id", "dbo.TINHTRANGS");
            DropForeignKey("dbo.TSCD_CTTAISAN", "vitri_id", "dbo.VITRIS");
            DropForeignKey("dbo.TSCD_CHUTHE", "loaichuthe_id", "dbo.TSCD_LOAICHUTHE");
            DropIndex("dbo.TSCD_CHUTHE", new[] { "parent_id" });
            DropIndex("dbo.TSCD_CHUTHE", new[] { "loaichuthe_id" });
            DropIndex("dbo.TSCD_CTTAISAN", new[] { "chuthequanly_id" });
            DropIndex("dbo.TSCD_CTTAISAN", new[] { "chuthesudung_id" });
            DropIndex("dbo.TSCD_CTTAISAN", new[] { "tinhtrang_id" });
            DropIndex("dbo.TSCD_CTTAISAN", new[] { "vitri_id" });
            DropIndex("dbo.TSCD_CTTAISAN", new[] { "phong_id" });
            DropIndex("dbo.TSCD_CTTAISAN", new[] { "taisan_id" });
            DropIndex("dbo.TSCD_LOGTAISAN", new[] { "quantrivien_id" });
            DropIndex("dbo.TSCD_LOGTAISAN", new[] { "taisan_id" });
            DropIndex("dbo.TSCD_LOGTAISAN", new[] { "chuthequanly_id" });
            DropIndex("dbo.TSCD_LOGTAISAN", new[] { "chuthesudung_id" });
            DropIndex("dbo.TSCD_LOGTAISAN", new[] { "tinhtrang_id" });
            DropIndex("dbo.TSCD_TAISAN", new[] { "parent_id" });
            DropIndex("dbo.TSCD_TAISAN", new[] { "loaitaisan_id" });
            DropIndex("dbo.TSCD_LOAITAISAN", new[] { "ten" });
            DropIndex("dbo.TSCD_LOAITAISAN", new[] { "donvitinh_id" });
            DropIndex("dbo.TSCD_LOAITAISAN", new[] { "parent_id" });
            DropIndex("dbo.TSCD_LOAICHUTHE", new[] { "ten" });
            DropTable("dbo.TSCD_CHUTHE");
            DropTable("dbo.TSCD_CTTAISAN");
            DropTable("dbo.TSCD_LOGTAISAN");
            DropTable("dbo.TSCD_TAISAN");
            DropTable("dbo.TSCD_LOAITAISAN");
            DropTable("dbo.TSCD_DONVITINH");
            DropTable("dbo.TSCD_LOAICHUTHE");
        }
        
        public override void Down()
        {
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
                .PrimaryKey(t => t.id);
            
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
                .PrimaryKey(t => t.id);
            
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
                .PrimaryKey(t => t.id);
            
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
                        chuthequanly_id = c.Guid(),
                        chuthesudung_id = c.Guid(),
                        tinhtrang_id = c.Guid(nullable: false),
                        subId = c.String(),
                        order = c.Long(),
                        mota = c.String(),
                        date_create = c.DateTime(),
                        date_modified = c.DateTime(),
                    })
                .PrimaryKey(t => t.id);
            
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
                        chuthequanly_id = c.Guid(),
                        chuthesudung_id = c.Guid(),
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
                .PrimaryKey(t => t.id);
            
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
                .PrimaryKey(t => t.id);
            
            CreateIndex("dbo.TSCD_LOAICHUTHE", "ten", unique: true);
            CreateIndex("dbo.TSCD_LOAITAISAN", "parent_id");
            CreateIndex("dbo.TSCD_LOAITAISAN", "donvitinh_id");
            CreateIndex("dbo.TSCD_LOAITAISAN", "ten", unique: true);
            CreateIndex("dbo.TSCD_TAISAN", "loaitaisan_id");
            CreateIndex("dbo.TSCD_TAISAN", "parent_id");
            CreateIndex("dbo.TSCD_LOGTAISAN", "tinhtrang_id");
            CreateIndex("dbo.TSCD_LOGTAISAN", "chuthesudung_id");
            CreateIndex("dbo.TSCD_LOGTAISAN", "chuthequanly_id");
            CreateIndex("dbo.TSCD_LOGTAISAN", "taisan_id");
            CreateIndex("dbo.TSCD_LOGTAISAN", "quantrivien_id");
            CreateIndex("dbo.TSCD_CTTAISAN", "taisan_id");
            CreateIndex("dbo.TSCD_CTTAISAN", "phong_id");
            CreateIndex("dbo.TSCD_CTTAISAN", "vitri_id");
            CreateIndex("dbo.TSCD_CTTAISAN", "tinhtrang_id");
            CreateIndex("dbo.TSCD_CTTAISAN", "chuthesudung_id");
            CreateIndex("dbo.TSCD_CTTAISAN", "chuthequanly_id");
            CreateIndex("dbo.TSCD_CHUTHE", "loaichuthe_id");
            CreateIndex("dbo.TSCD_CHUTHE", "parent_id");
            AddForeignKey("dbo.TSCD_CHUTHE", "loaichuthe_id", "dbo.TSCD_LOAICHUTHE", "id");
            AddForeignKey("dbo.TSCD_CTTAISAN", "vitri_id", "dbo.VITRIS", "id");
            AddForeignKey("dbo.TSCD_CTTAISAN", "tinhtrang_id", "dbo.TINHTRANGS", "id");
            AddForeignKey("dbo.TSCD_CTTAISAN", "taisan_id", "dbo.TSCD_TAISAN", "id");
            AddForeignKey("dbo.TSCD_CTTAISAN", "phong_id", "dbo.PHONGS", "id");
            AddForeignKey("dbo.TSCD_LOGTAISAN", "tinhtrang_id", "dbo.TINHTRANGS", "id");
            AddForeignKey("dbo.TSCD_LOGTAISAN", "taisan_id", "dbo.TSCD_TAISAN", "id");
            AddForeignKey("dbo.TSCD_TAISAN", "loaitaisan_id", "dbo.TSCD_LOAITAISAN", "id");
            AddForeignKey("dbo.TSCD_LOAITAISAN", "donvitinh_id", "dbo.TSCD_DONVITINH", "id");
            AddForeignKey("dbo.TSCD_LOAITAISAN", "parent_id", "dbo.TSCD_LOAITAISAN", "id");
            AddForeignKey("dbo.TSCD_TAISAN", "parent_id", "dbo.TSCD_TAISAN", "id");
            AddForeignKey("dbo.TSCD_LOGTAISAN", "quantrivien_id", "dbo.QUANTRIVIENS", "id");
            AddForeignKey("dbo.TSCD_LOGTAISAN", "chuthesudung_id", "dbo.TSCD_CHUTHE", "id");
            AddForeignKey("dbo.TSCD_LOGTAISAN", "chuthequanly_id", "dbo.TSCD_CHUTHE", "id");
            AddForeignKey("dbo.TSCD_CTTAISAN", "chuthesudung_id", "dbo.TSCD_CHUTHE", "id");
            AddForeignKey("dbo.TSCD_CTTAISAN", "chuthequanly_id", "dbo.TSCD_CHUTHE", "id");
            AddForeignKey("dbo.TSCD_CHUTHE", "parent_id", "dbo.TSCD_CHUTHE", "id");
        }
    }
}

namespace TSCD.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class basev1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.COSOS",
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
            
            CreateTable(
                "dbo.DAYS",
                c => new
                    {
                        id = c.Guid(nullable: false, identity: true),
                        ten = c.String(nullable: false),
                        coso_id = c.Guid(nullable: false),
                        subId = c.String(),
                        order = c.Long(),
                        mota = c.String(),
                        date_create = c.DateTime(),
                        date_modified = c.DateTime(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.COSOS", t => t.coso_id)
                .Index(t => t.coso_id);
            
            CreateTable(
                "dbo.TANGS",
                c => new
                    {
                        id = c.Guid(nullable: false, identity: true),
                        ten = c.String(nullable: false),
                        day_id = c.Guid(nullable: false),
                        subId = c.String(),
                        order = c.Long(),
                        mota = c.String(),
                        date_create = c.DateTime(),
                        date_modified = c.DateTime(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.DAYS", t => t.day_id)
                .Index(t => t.day_id);
            
            CreateTable(
                "dbo.VITRIS",
                c => new
                    {
                        id = c.Guid(nullable: false, identity: true),
                        coso_id = c.Guid(nullable: false),
                        day_id = c.Guid(),
                        tang_id = c.Guid(),
                        subId = c.String(),
                        order = c.Long(),
                        mota = c.String(),
                        date_create = c.DateTime(),
                        date_modified = c.DateTime(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.COSOS", t => t.coso_id)
                .ForeignKey("dbo.DAYS", t => t.day_id)
                .ForeignKey("dbo.TANGS", t => t.tang_id)
                .Index(t => t.coso_id)
                .Index(t => t.day_id)
                .Index(t => t.tang_id);
            
            CreateTable(
                "dbo.PHONGS",
                c => new
                    {
                        id = c.Guid(nullable: false, identity: true),
                        ten = c.String(nullable: false, maxLength: 255),
                        loaiphong_id = c.Guid(nullable: false),
                        vitri_id = c.Guid(nullable: false),
                        subId = c.String(),
                        order = c.Long(),
                        mota = c.String(),
                        date_create = c.DateTime(),
                        date_modified = c.DateTime(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.LOAIPHONGS", t => t.loaiphong_id)
                .ForeignKey("dbo.VITRIS", t => t.vitri_id)
                .Index(t => t.ten, unique: true, name: "nothing")
                .Index(t => t.loaiphong_id)
                .Index(t => t.vitri_id);
            
            CreateTable(
                "dbo.LOAIPHONGS",
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
            
            CreateTable(
                "dbo.CTTAISANS",
                c => new
                    {
                        id = c.Guid(nullable: false, identity: true),
                        ghichu = c.String(),
                        isTang = c.Boolean(nullable: false),
                        isChuyen = c.Boolean(nullable: false),
                        soluong = c.Int(nullable: false),
                        nguongoc = c.String(),
                        ngay = c.DateTime(),
                        chungtu_sohieu = c.String(),
                        chungtu_ngay = c.DateTime(),
                        donviquanly_id = c.Guid(),
                        donvisudung_id = c.Guid(),
                        tinhtrang_id = c.Guid(nullable: false),
                        vitri_id = c.Guid(),
                        phong_id = c.Guid(),
                        taisan_id = c.Guid(nullable: false),
                        parent_id = c.Guid(),
                        subId = c.String(),
                        order = c.Long(),
                        mota = c.String(),
                        date_create = c.DateTime(),
                        date_modified = c.DateTime(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.CTTAISANS", t => t.parent_id)
                .ForeignKey("dbo.DONVIS", t => t.donviquanly_id)
                .ForeignKey("dbo.DONVIS", t => t.donvisudung_id)
                .ForeignKey("dbo.PHONGS", t => t.phong_id)
                .ForeignKey("dbo.TAISANS", t => t.taisan_id)
                .ForeignKey("dbo.TINHTRANGS", t => t.tinhtrang_id)
                .ForeignKey("dbo.VITRIS", t => t.vitri_id)
                .Index(t => t.donviquanly_id)
                .Index(t => t.donvisudung_id)
                .Index(t => t.tinhtrang_id)
                .Index(t => t.vitri_id)
                .Index(t => t.phong_id)
                .Index(t => t.taisan_id)
                .Index(t => t.parent_id);
            
            CreateTable(
                "dbo.DONVIS",
                c => new
                    {
                        id = c.Guid(nullable: false, identity: true),
                        ten = c.String(nullable: false),
                        parent_id = c.Guid(),
                        loaidonvi_id = c.Guid(nullable: false),
                        subId = c.String(),
                        order = c.Long(),
                        mota = c.String(),
                        date_create = c.DateTime(),
                        date_modified = c.DateTime(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.DONVIS", t => t.parent_id)
                .ForeignKey("dbo.LOAIDONVIS", t => t.loaidonvi_id)
                .Index(t => t.parent_id)
                .Index(t => t.loaidonvi_id);
            
            CreateTable(
                "dbo.LOAIDONVIS",
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
            
            CreateTable(
                "dbo.LOGTAISANS",
                c => new
                    {
                        id = c.Guid(nullable: false, identity: true),
                        ghichu = c.String(),
                        isTang = c.Boolean(nullable: false),
                        isChuyen = c.Boolean(nullable: false),
                        soluong = c.Int(nullable: false),
                        chungtu_sohieu = c.String(),
                        chungtu_ngay = c.DateTime(),
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
                .ForeignKey("dbo.DONVIS", t => t.donviquanly_id)
                .ForeignKey("dbo.DONVIS", t => t.donvisudung_id)
                .ForeignKey("dbo.PHONGS", t => t.phong_id)
                .ForeignKey("dbo.QUANTRIVIENS", t => t.quantrivien_id)
                .ForeignKey("dbo.TAISANS", t => t.taisan_id)
                .ForeignKey("dbo.TINHTRANGS", t => t.tinhtrang_id)
                .ForeignKey("dbo.VITRIS", t => t.vitri_id)
                .Index(t => t.quantrivien_id)
                .Index(t => t.taisan_id)
                .Index(t => t.donviquanly_id)
                .Index(t => t.donvisudung_id)
                .Index(t => t.tinhtrang_id)
                .Index(t => t.vitri_id)
                .Index(t => t.phong_id);
            
            CreateTable(
                "dbo.QUANTRIVIENS",
                c => new
                    {
                        id = c.Guid(nullable: false, identity: true),
                        donvi = c.String(),
                        email = c.String(),
                        group_id = c.Guid(nullable: false),
                        hoten = c.String(nullable: false),
                        username = c.String(nullable: false, maxLength: 100),
                        password = c.String(nullable: false),
                        subId = c.String(),
                        order = c.Long(),
                        mota = c.String(),
                        date_create = c.DateTime(),
                        date_modified = c.DateTime(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.GROUPS", t => t.group_id)
                .Index(t => t.group_id)
                .Index(t => t.username, unique: true);
            
            CreateTable(
                "dbo.GROUPS",
                c => new
                    {
                        id = c.Guid(nullable: false, identity: true),
                        key = c.String(maxLength: 100),
                        ten = c.String(nullable: false, maxLength: 100),
                        subId = c.String(),
                        order = c.Long(),
                        mota = c.String(),
                        date_create = c.DateTime(),
                        date_modified = c.DateTime(),
                    })
                .PrimaryKey(t => t.id)
                .Index(t => t.ten, unique: true);
            
            CreateTable(
                "dbo.PERMISSIONS",
                c => new
                    {
                        id = c.Guid(nullable: false, identity: true),
                        key = c.String(),
                        stand_alone = c.Boolean(nullable: false),
                        allow_or_deny = c.Boolean(nullable: false),
                        recursive_to_child = c.Boolean(nullable: false),
                        can_view = c.Boolean(nullable: false),
                        can_edit = c.Boolean(nullable: false),
                        can_delete = c.Boolean(nullable: false),
                        can_add = c.Boolean(nullable: false),
                        subId = c.String(),
                        order = c.Long(),
                        mota = c.String(),
                        date_create = c.DateTime(),
                        date_modified = c.DateTime(),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.TAISANS",
                c => new
                    {
                        id = c.Guid(nullable: false, identity: true),
                        ten = c.String(nullable: false),
                        dongia = c.Long(nullable: false),
                        loaitaisan_id = c.Guid(nullable: false),
                        subId = c.String(),
                        order = c.Long(),
                        mota = c.String(),
                        date_create = c.DateTime(),
                        date_modified = c.DateTime(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.LOAITAISANS", t => t.loaitaisan_id)
                .Index(t => t.loaitaisan_id);
            
            CreateTable(
                "dbo.LOAITAISANS",
                c => new
                    {
                        id = c.Guid(nullable: false, identity: true),
                        huuhinh = c.Boolean(nullable: false),
                        ten = c.String(nullable: false, maxLength: 255),
                        sonamsudung = c.Int(nullable: false),
                        phantramhaomon = c.Int(nullable: false),
                        donvitinh_id = c.Guid(),
                        parent_id = c.Guid(),
                        subId = c.String(),
                        order = c.Long(),
                        mota = c.String(),
                        date_create = c.DateTime(),
                        date_modified = c.DateTime(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.LOAITAISANS", t => t.parent_id)
                .ForeignKey("dbo.DONVITINHS", t => t.donvitinh_id)
                .Index(t => t.ten, unique: true)
                .Index(t => t.donvitinh_id)
                .Index(t => t.parent_id);
            
            CreateTable(
                "dbo.DONVITINHS",
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
                "dbo.TINHTRANGS",
                c => new
                    {
                        id = c.Guid(nullable: false, identity: true),
                        key = c.String(maxLength: 100),
                        value = c.String(nullable: false, maxLength: 255),
                        subId = c.String(),
                        order = c.Long(),
                        mota = c.String(),
                        date_create = c.DateTime(),
                        date_modified = c.DateTime(),
                    })
                .PrimaryKey(t => t.id)
                .Index(t => t.key, unique: true)
                .Index(t => t.value, unique: true);
            
            CreateTable(
                "dbo.LOGHETHONGS",
                c => new
                    {
                        mota = c.String(nullable: false, maxLength: 128),
                        date_create = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => new { t.mota, t.date_create });
            
            CreateTable(
                "dbo.SETTINGS",
                c => new
                    {
                        id = c.Guid(nullable: false, identity: true),
                        key = c.String(nullable: false, maxLength: 100),
                        value = c.String(),
                        subId = c.String(),
                        order = c.Long(),
                        mota = c.String(),
                        date_create = c.DateTime(),
                        date_modified = c.DateTime(),
                    })
                .PrimaryKey(t => t.id)
                .Index(t => t.key, unique: true);
            
            CreateTable(
                "dbo.GROUP_PERMISSION",
                c => new
                    {
                        id1 = c.Guid(nullable: false),
                        id2 = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => new { t.id1, t.id2 })
                .ForeignKey("dbo.GROUPS", t => t.id1, cascadeDelete: true)
                .ForeignKey("dbo.PERMISSIONS", t => t.id2, cascadeDelete: true)
                .Index(t => t.id1)
                .Index(t => t.id2);
            
            CreateTable(
                "dbo.DONVI_PERMISSION",
                c => new
                    {
                        id1 = c.Guid(nullable: false),
                        id2 = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => new { t.id1, t.id2 })
                .ForeignKey("dbo.DONVIS", t => t.id1, cascadeDelete: true)
                .ForeignKey("dbo.PERMISSIONS", t => t.id2, cascadeDelete: true)
                .Index(t => t.id1)
                .Index(t => t.id2);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CTTAISANS", "vitri_id", "dbo.VITRIS");
            DropForeignKey("dbo.CTTAISANS", "tinhtrang_id", "dbo.TINHTRANGS");
            DropForeignKey("dbo.CTTAISANS", "taisan_id", "dbo.TAISANS");
            DropForeignKey("dbo.CTTAISANS", "phong_id", "dbo.PHONGS");
            DropForeignKey("dbo.CTTAISANS", "donvisudung_id", "dbo.DONVIS");
            DropForeignKey("dbo.CTTAISANS", "donviquanly_id", "dbo.DONVIS");
            DropForeignKey("dbo.DONVI_PERMISSION", "id2", "dbo.PERMISSIONS");
            DropForeignKey("dbo.DONVI_PERMISSION", "id1", "dbo.DONVIS");
            DropForeignKey("dbo.LOGTAISANS", "vitri_id", "dbo.VITRIS");
            DropForeignKey("dbo.LOGTAISANS", "tinhtrang_id", "dbo.TINHTRANGS");
            DropForeignKey("dbo.LOGTAISANS", "taisan_id", "dbo.TAISANS");
            DropForeignKey("dbo.TAISANS", "loaitaisan_id", "dbo.LOAITAISANS");
            DropForeignKey("dbo.LOAITAISANS", "donvitinh_id", "dbo.DONVITINHS");
            DropForeignKey("dbo.LOAITAISANS", "parent_id", "dbo.LOAITAISANS");
            DropForeignKey("dbo.LOGTAISANS", "quantrivien_id", "dbo.QUANTRIVIENS");
            DropForeignKey("dbo.QUANTRIVIENS", "group_id", "dbo.GROUPS");
            DropForeignKey("dbo.GROUP_PERMISSION", "id2", "dbo.PERMISSIONS");
            DropForeignKey("dbo.GROUP_PERMISSION", "id1", "dbo.GROUPS");
            DropForeignKey("dbo.LOGTAISANS", "phong_id", "dbo.PHONGS");
            DropForeignKey("dbo.LOGTAISANS", "donvisudung_id", "dbo.DONVIS");
            DropForeignKey("dbo.LOGTAISANS", "donviquanly_id", "dbo.DONVIS");
            DropForeignKey("dbo.DONVIS", "loaidonvi_id", "dbo.LOAIDONVIS");
            DropForeignKey("dbo.DONVIS", "parent_id", "dbo.DONVIS");
            DropForeignKey("dbo.CTTAISANS", "parent_id", "dbo.CTTAISANS");
            DropForeignKey("dbo.VITRIS", "tang_id", "dbo.TANGS");
            DropForeignKey("dbo.PHONGS", "vitri_id", "dbo.VITRIS");
            DropForeignKey("dbo.PHONGS", "loaiphong_id", "dbo.LOAIPHONGS");
            DropForeignKey("dbo.VITRIS", "day_id", "dbo.DAYS");
            DropForeignKey("dbo.VITRIS", "coso_id", "dbo.COSOS");
            DropForeignKey("dbo.TANGS", "day_id", "dbo.DAYS");
            DropForeignKey("dbo.DAYS", "coso_id", "dbo.COSOS");
            DropIndex("dbo.DONVI_PERMISSION", new[] { "id2" });
            DropIndex("dbo.DONVI_PERMISSION", new[] { "id1" });
            DropIndex("dbo.GROUP_PERMISSION", new[] { "id2" });
            DropIndex("dbo.GROUP_PERMISSION", new[] { "id1" });
            DropIndex("dbo.SETTINGS", new[] { "key" });
            DropIndex("dbo.TINHTRANGS", new[] { "value" });
            DropIndex("dbo.TINHTRANGS", new[] { "key" });
            DropIndex("dbo.LOAITAISANS", new[] { "parent_id" });
            DropIndex("dbo.LOAITAISANS", new[] { "donvitinh_id" });
            DropIndex("dbo.LOAITAISANS", new[] { "ten" });
            DropIndex("dbo.TAISANS", new[] { "loaitaisan_id" });
            DropIndex("dbo.GROUPS", new[] { "ten" });
            DropIndex("dbo.QUANTRIVIENS", new[] { "username" });
            DropIndex("dbo.QUANTRIVIENS", new[] { "group_id" });
            DropIndex("dbo.LOGTAISANS", new[] { "phong_id" });
            DropIndex("dbo.LOGTAISANS", new[] { "vitri_id" });
            DropIndex("dbo.LOGTAISANS", new[] { "tinhtrang_id" });
            DropIndex("dbo.LOGTAISANS", new[] { "donvisudung_id" });
            DropIndex("dbo.LOGTAISANS", new[] { "donviquanly_id" });
            DropIndex("dbo.LOGTAISANS", new[] { "taisan_id" });
            DropIndex("dbo.LOGTAISANS", new[] { "quantrivien_id" });
            DropIndex("dbo.LOAIDONVIS", new[] { "ten" });
            DropIndex("dbo.DONVIS", new[] { "loaidonvi_id" });
            DropIndex("dbo.DONVIS", new[] { "parent_id" });
            DropIndex("dbo.CTTAISANS", new[] { "parent_id" });
            DropIndex("dbo.CTTAISANS", new[] { "taisan_id" });
            DropIndex("dbo.CTTAISANS", new[] { "phong_id" });
            DropIndex("dbo.CTTAISANS", new[] { "vitri_id" });
            DropIndex("dbo.CTTAISANS", new[] { "tinhtrang_id" });
            DropIndex("dbo.CTTAISANS", new[] { "donvisudung_id" });
            DropIndex("dbo.CTTAISANS", new[] { "donviquanly_id" });
            DropIndex("dbo.LOAIPHONGS", new[] { "ten" });
            DropIndex("dbo.PHONGS", new[] { "vitri_id" });
            DropIndex("dbo.PHONGS", new[] { "loaiphong_id" });
            DropIndex("dbo.PHONGS", "nothing");
            DropIndex("dbo.VITRIS", new[] { "tang_id" });
            DropIndex("dbo.VITRIS", new[] { "day_id" });
            DropIndex("dbo.VITRIS", new[] { "coso_id" });
            DropIndex("dbo.TANGS", new[] { "day_id" });
            DropIndex("dbo.DAYS", new[] { "coso_id" });
            DropIndex("dbo.COSOS", new[] { "ten" });
            DropTable("dbo.DONVI_PERMISSION");
            DropTable("dbo.GROUP_PERMISSION");
            DropTable("dbo.SETTINGS");
            DropTable("dbo.LOGHETHONGS");
            DropTable("dbo.TINHTRANGS");
            DropTable("dbo.DONVITINHS");
            DropTable("dbo.LOAITAISANS");
            DropTable("dbo.TAISANS");
            DropTable("dbo.PERMISSIONS");
            DropTable("dbo.GROUPS");
            DropTable("dbo.QUANTRIVIENS");
            DropTable("dbo.LOGTAISANS");
            DropTable("dbo.LOAIDONVIS");
            DropTable("dbo.DONVIS");
            DropTable("dbo.CTTAISANS");
            DropTable("dbo.LOAIPHONGS");
            DropTable("dbo.PHONGS");
            DropTable("dbo.VITRIS");
            DropTable("dbo.TANGS");
            DropTable("dbo.DAYS");
            DropTable("dbo.COSOS");
        }
    }
}

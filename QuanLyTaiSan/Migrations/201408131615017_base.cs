namespace QuanLyTaiSan.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _base : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.COSOS",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        ten = c.String(nullable: false, maxLength: 255),
                        diachi = c.String(),
                        subId = c.String(),
                        order = c.Int(),
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
                        id = c.Int(nullable: false, identity: true),
                        ten = c.String(nullable: false),
                        coso_id = c.Int(nullable: false),
                        subId = c.String(),
                        order = c.Int(),
                        mota = c.String(),
                        date_create = c.DateTime(),
                        date_modified = c.DateTime(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.COSOS", t => t.coso_id)
                .Index(t => t.coso_id);
            
            CreateTable(
                "dbo.HINHANHS",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        path = c.String(nullable: false, maxLength: 255),
                        subId = c.String(),
                        order = c.Int(),
                        mota = c.String(),
                        date_create = c.DateTime(),
                        date_modified = c.DateTime(),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.CTTHIETBIS",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        ngay = c.DateTime(),
                        soluong = c.Int(nullable: false),
                        phong_id = c.Int(nullable: false),
                        thietbi_id = c.Int(nullable: false),
                        tinhtrang_id = c.Int(nullable: false),
                        subId = c.String(),
                        order = c.Int(),
                        mota = c.String(),
                        date_create = c.DateTime(),
                        date_modified = c.DateTime(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.PHONGS", t => t.phong_id)
                .ForeignKey("dbo.THIETBIS", t => t.thietbi_id)
                .ForeignKey("dbo.TINHTRANGS", t => t.tinhtrang_id)
                .Index(t => t.phong_id)
                .Index(t => t.thietbi_id)
                .Index(t => t.tinhtrang_id);
            
            CreateTable(
                "dbo.PHONGS",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        ten = c.String(nullable: false, maxLength: 255),
                        vitri_id = c.Int(nullable: false),
                        nhanvienpt_id = c.Int(),
                        quantrivien_id = c.Int(),
                        subId = c.String(),
                        order = c.Int(),
                        mota = c.String(),
                        date_create = c.DateTime(),
                        date_modified = c.DateTime(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.QUANTRIVIENS", t => t.quantrivien_id)
                .ForeignKey("dbo.NHANVIENPTS", t => t.nhanvienpt_id)
                .ForeignKey("dbo.VITRIS", t => t.vitri_id)
                .Index(t => t.ten, unique: true, name: "nothing")
                .Index(t => t.vitri_id)
                .Index(t => t.nhanvienpt_id)
                .Index(t => t.quantrivien_id);
            
            CreateTable(
                "dbo.LOGTHIETBIS",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        soluong = c.Int(nullable: false),
                        thietbi_id = c.Int(nullable: false),
                        tinhtrang_id = c.Int(nullable: false),
                        phong_id = c.Int(),
                        quantrivien_id = c.Int(),
                        subId = c.String(),
                        order = c.Int(),
                        mota = c.String(),
                        date_create = c.DateTime(),
                        date_modified = c.DateTime(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.PHONGS", t => t.phong_id)
                .ForeignKey("dbo.QUANTRIVIENS", t => t.quantrivien_id)
                .ForeignKey("dbo.THIETBIS", t => t.thietbi_id)
                .ForeignKey("dbo.TINHTRANGS", t => t.tinhtrang_id)
                .Index(t => t.thietbi_id)
                .Index(t => t.tinhtrang_id)
                .Index(t => t.phong_id)
                .Index(t => t.quantrivien_id);
            
            CreateTable(
                "dbo.QUANTRIVIENS",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        group_id = c.Int(nullable: false),
                        hoten = c.String(nullable: false),
                        username = c.String(nullable: false, maxLength: 100),
                        password = c.String(nullable: false),
                        subId = c.String(),
                        order = c.Int(),
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
                        id = c.Int(nullable: false, identity: true),
                        key = c.String(maxLength: 100),
                        ten = c.String(nullable: false, maxLength: 100),
                        subId = c.String(),
                        order = c.Int(),
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
                        id = c.Int(nullable: false, identity: true),
                        key = c.String(nullable: false, maxLength: 100),
                        subId = c.String(),
                        order = c.Int(),
                        mota = c.String(),
                        date_create = c.DateTime(),
                        date_modified = c.DateTime(),
                    })
                .PrimaryKey(t => t.id)
                .Index(t => t.key, unique: true);
            
            CreateTable(
                "dbo.LOGSUCOPHONGS",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        tinhtrang_id = c.Int(nullable: false),
                        sucophong_id = c.Int(nullable: false),
                        quantrivien_id = c.Int(),
                        subId = c.String(),
                        order = c.Int(),
                        mota = c.String(),
                        date_create = c.DateTime(),
                        date_modified = c.DateTime(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.QUANTRIVIENS", t => t.quantrivien_id)
                .ForeignKey("dbo.SUCOPHONGS", t => t.sucophong_id)
                .ForeignKey("dbo.TINHTRANGS", t => t.tinhtrang_id)
                .Index(t => t.tinhtrang_id)
                .Index(t => t.sucophong_id)
                .Index(t => t.quantrivien_id);
            
            CreateTable(
                "dbo.SUCOPHONGS",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        ngay = c.DateTime(nullable: false),
                        ten = c.String(nullable: false, maxLength: 255),
                        tinhtrang_id = c.Int(nullable: false),
                        phong_id = c.Int(nullable: false),
                        subId = c.String(),
                        order = c.Int(),
                        mota = c.String(),
                        date_create = c.DateTime(),
                        date_modified = c.DateTime(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.PHONGS", t => t.phong_id)
                .ForeignKey("dbo.TINHTRANGS", t => t.tinhtrang_id)
                .Index(t => t.tinhtrang_id)
                .Index(t => t.phong_id);
            
            CreateTable(
                "dbo.TINHTRANGS",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        key = c.String(maxLength: 100),
                        value = c.String(nullable: false, maxLength: 255),
                        subId = c.String(),
                        order = c.Int(),
                        mota = c.String(),
                        date_create = c.DateTime(),
                        date_modified = c.DateTime(),
                    })
                .PrimaryKey(t => t.id)
                .Index(t => t.key, unique: true)
                .Index(t => t.value, unique: true);
            
            CreateTable(
                "dbo.PHIEUMUONPHONGS",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        khoaphongmuon = c.String(nullable: false),
                        ngaymuon = c.DateTime(nullable: false),
                        ngaytra = c.DateTime(nullable: false),
                        lydomuon = c.String(),
                        trangthai = c.Int(nullable: false),
                        ghichu = c.String(),
                        lop = c.String(),
                        sophong = c.Int(nullable: false),
                        quantrivien_id = c.Int(),
                        soluongsv = c.Int(nullable: false),
                        subId = c.String(),
                        order = c.Int(),
                        mota = c.String(),
                        date_create = c.DateTime(),
                        date_modified = c.DateTime(),
                        giangvien_id = c.Int(nullable: false),
                        Phong_id = c.Int(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.GIANGVIENS", t => t.giangvien_id)
                .ForeignKey("dbo.QUANTRIVIENS", t => t.quantrivien_id)
                .ForeignKey("dbo.PHONGS", t => t.Phong_id)
                .Index(t => t.quantrivien_id)
                .Index(t => t.giangvien_id)
                .Index(t => t.Phong_id);
            
            CreateTable(
                "dbo.GIANGVIENS",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        khoa = c.String(nullable: false),
                        email = c.String(nullable: false),
                        hoten = c.String(nullable: false),
                        username = c.String(nullable: false, maxLength: 100),
                        password = c.String(nullable: false),
                        subId = c.String(),
                        order = c.Int(),
                        mota = c.String(),
                        date_create = c.DateTime(),
                        date_modified = c.DateTime(),
                    })
                .PrimaryKey(t => t.id)
                .Index(t => t.username, unique: true);
            
            CreateTable(
                "dbo.THIETBIS",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        ten = c.String(nullable: false),
                        ngaymua = c.DateTime(),
                        loaithietbi_id = c.Int(nullable: false),
                        subId = c.String(),
                        order = c.Int(),
                        mota = c.String(),
                        date_create = c.DateTime(),
                        date_modified = c.DateTime(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.LOAITHIETBIS", t => t.loaithietbi_id)
                .Index(t => t.loaithietbi_id);
            
            CreateTable(
                "dbo.LOAITHIETBIS",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        ten = c.String(nullable: false, maxLength: 255),
                        loaichung = c.Boolean(nullable: false),
                        parent_id = c.Int(),
                        subId = c.String(),
                        order = c.Int(),
                        mota = c.String(),
                        date_create = c.DateTime(),
                        date_modified = c.DateTime(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.LOAITHIETBIS", t => t.parent_id)
                .Index(t => t.ten, unique: true)
                .Index(t => t.parent_id);
            
            CreateTable(
                "dbo.NHANVIENPTS",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        hoten = c.String(nullable: false),
                        sodienthoai = c.String(),
                        subId = c.String(),
                        order = c.Int(),
                        mota = c.String(),
                        date_create = c.DateTime(),
                        date_modified = c.DateTime(),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.VITRIS",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        coso_id = c.Int(nullable: false),
                        day_id = c.Int(),
                        tang_id = c.Int(),
                        subId = c.String(),
                        order = c.Int(),
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
                "dbo.TANGS",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        ten = c.String(nullable: false),
                        day_id = c.Int(nullable: false),
                        subId = c.String(),
                        order = c.Int(),
                        mota = c.String(),
                        date_create = c.DateTime(),
                        date_modified = c.DateTime(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.DAYS", t => t.day_id)
                .Index(t => t.day_id);
            
            CreateTable(
                "dbo.LOGHETHONGS",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        subId = c.String(),
                        order = c.Int(),
                        mota = c.String(),
                        date_create = c.DateTime(),
                        date_modified = c.DateTime(),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.SETTINGS",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        key = c.String(nullable: false, maxLength: 100),
                        value = c.String(),
                        subId = c.String(),
                        order = c.Int(),
                        mota = c.String(),
                        date_create = c.DateTime(),
                        date_modified = c.DateTime(),
                    })
                .PrimaryKey(t => t.id)
                .Index(t => t.key, unique: true);
            
            CreateTable(
                "dbo.CTTHIETBI_HINHANH",
                c => new
                    {
                        id1 = c.Int(nullable: false),
                        id2 = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.id1, t.id2 })
                .ForeignKey("dbo.CTTHIETBIS", t => t.id1, cascadeDelete: true)
                .ForeignKey("dbo.HINHANHS", t => t.id2, cascadeDelete: true)
                .Index(t => t.id1)
                .Index(t => t.id2);
            
            CreateTable(
                "dbo.PHONG_HINHANH",
                c => new
                    {
                        id1 = c.Int(nullable: false),
                        id2 = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.id1, t.id2 })
                .ForeignKey("dbo.PHONGS", t => t.id1, cascadeDelete: true)
                .ForeignKey("dbo.HINHANHS", t => t.id2, cascadeDelete: true)
                .Index(t => t.id1)
                .Index(t => t.id2);
            
            CreateTable(
                "dbo.LOGTHIETBI_HINHANH",
                c => new
                    {
                        id1 = c.Int(nullable: false),
                        id2 = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.id1, t.id2 })
                .ForeignKey("dbo.LOGTHIETBIS", t => t.id1, cascadeDelete: true)
                .ForeignKey("dbo.HINHANHS", t => t.id2, cascadeDelete: true)
                .Index(t => t.id1)
                .Index(t => t.id2);
            
            CreateTable(
                "dbo.GROUP_PERMISSION",
                c => new
                    {
                        group_id = c.Int(nullable: false),
                        permission_id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.group_id, t.permission_id })
                .ForeignKey("dbo.GROUPS", t => t.group_id, cascadeDelete: true)
                .ForeignKey("dbo.PERMISSIONS", t => t.permission_id, cascadeDelete: true)
                .Index(t => t.group_id)
                .Index(t => t.permission_id);
            
            CreateTable(
                "dbo.LOGSUCOPHONG_HINHANH",
                c => new
                    {
                        id1 = c.Int(nullable: false),
                        id2 = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.id1, t.id2 })
                .ForeignKey("dbo.LOGSUCOPHONGS", t => t.id1, cascadeDelete: true)
                .ForeignKey("dbo.HINHANHS", t => t.id2, cascadeDelete: true)
                .Index(t => t.id1)
                .Index(t => t.id2);
            
            CreateTable(
                "dbo.SUCOPHONG_HINHANH",
                c => new
                    {
                        id1 = c.Int(nullable: false),
                        id2 = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.id1, t.id2 })
                .ForeignKey("dbo.SUCOPHONGS", t => t.id1, cascadeDelete: true)
                .ForeignKey("dbo.HINHANHS", t => t.id2, cascadeDelete: true)
                .Index(t => t.id1)
                .Index(t => t.id2);
            
            CreateTable(
                "dbo.THIETBI_HINHANH",
                c => new
                    {
                        id1 = c.Int(nullable: false),
                        id2 = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.id1, t.id2 })
                .ForeignKey("dbo.THIETBIS", t => t.id1, cascadeDelete: true)
                .ForeignKey("dbo.HINHANHS", t => t.id2, cascadeDelete: true)
                .Index(t => t.id1)
                .Index(t => t.id2);
            
            CreateTable(
                "dbo.NHANVIENPT_HINHANH",
                c => new
                    {
                        id1 = c.Int(nullable: false),
                        id2 = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.id1, t.id2 })
                .ForeignKey("dbo.NHANVIENPTS", t => t.id1, cascadeDelete: true)
                .ForeignKey("dbo.HINHANHS", t => t.id2, cascadeDelete: true)
                .Index(t => t.id1)
                .Index(t => t.id2);
            
            CreateTable(
                "dbo.TANG_HINHANH",
                c => new
                    {
                        id1 = c.Int(nullable: false),
                        id2 = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.id1, t.id2 })
                .ForeignKey("dbo.TANGS", t => t.id1, cascadeDelete: true)
                .ForeignKey("dbo.HINHANHS", t => t.id2, cascadeDelete: true)
                .Index(t => t.id1)
                .Index(t => t.id2);
            
            CreateTable(
                "dbo.DAY_HINHANH",
                c => new
                    {
                        id1 = c.Int(nullable: false),
                        id2 = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.id1, t.id2 })
                .ForeignKey("dbo.DAYS", t => t.id1, cascadeDelete: true)
                .ForeignKey("dbo.HINHANHS", t => t.id2, cascadeDelete: true)
                .Index(t => t.id1)
                .Index(t => t.id2);
            
            CreateTable(
                "dbo.COSO_HINHANH",
                c => new
                    {
                        id1 = c.Int(nullable: false),
                        id2 = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.id1, t.id2 })
                .ForeignKey("dbo.COSOS", t => t.id1, cascadeDelete: true)
                .ForeignKey("dbo.HINHANHS", t => t.id2, cascadeDelete: true)
                .Index(t => t.id1)
                .Index(t => t.id2);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.COSO_HINHANH", "id2", "dbo.HINHANHS");
            DropForeignKey("dbo.COSO_HINHANH", "id1", "dbo.COSOS");
            DropForeignKey("dbo.DAY_HINHANH", "id2", "dbo.HINHANHS");
            DropForeignKey("dbo.DAY_HINHANH", "id1", "dbo.DAYS");
            DropForeignKey("dbo.CTTHIETBIS", "tinhtrang_id", "dbo.TINHTRANGS");
            DropForeignKey("dbo.CTTHIETBIS", "thietbi_id", "dbo.THIETBIS");
            DropForeignKey("dbo.CTTHIETBIS", "phong_id", "dbo.PHONGS");
            DropForeignKey("dbo.PHONGS", "vitri_id", "dbo.VITRIS");
            DropForeignKey("dbo.VITRIS", "tang_id", "dbo.TANGS");
            DropForeignKey("dbo.TANG_HINHANH", "id2", "dbo.HINHANHS");
            DropForeignKey("dbo.TANG_HINHANH", "id1", "dbo.TANGS");
            DropForeignKey("dbo.TANGS", "day_id", "dbo.DAYS");
            DropForeignKey("dbo.VITRIS", "day_id", "dbo.DAYS");
            DropForeignKey("dbo.VITRIS", "coso_id", "dbo.COSOS");
            DropForeignKey("dbo.PHIEUMUONPHONGS", "Phong_id", "dbo.PHONGS");
            DropForeignKey("dbo.PHONGS", "nhanvienpt_id", "dbo.NHANVIENPTS");
            DropForeignKey("dbo.NHANVIENPT_HINHANH", "id2", "dbo.HINHANHS");
            DropForeignKey("dbo.NHANVIENPT_HINHANH", "id1", "dbo.NHANVIENPTS");
            DropForeignKey("dbo.LOGTHIETBIS", "tinhtrang_id", "dbo.TINHTRANGS");
            DropForeignKey("dbo.LOGTHIETBIS", "thietbi_id", "dbo.THIETBIS");
            DropForeignKey("dbo.THIETBIS", "loaithietbi_id", "dbo.LOAITHIETBIS");
            DropForeignKey("dbo.LOAITHIETBIS", "parent_id", "dbo.LOAITHIETBIS");
            DropForeignKey("dbo.THIETBI_HINHANH", "id2", "dbo.HINHANHS");
            DropForeignKey("dbo.THIETBI_HINHANH", "id1", "dbo.THIETBIS");
            DropForeignKey("dbo.PHONGS", "quantrivien_id", "dbo.QUANTRIVIENS");
            DropForeignKey("dbo.PHIEUMUONPHONGS", "quantrivien_id", "dbo.QUANTRIVIENS");
            DropForeignKey("dbo.PHIEUMUONPHONGS", "giangvien_id", "dbo.GIANGVIENS");
            DropForeignKey("dbo.LOGTHIETBIS", "quantrivien_id", "dbo.QUANTRIVIENS");
            DropForeignKey("dbo.LOGSUCOPHONGS", "tinhtrang_id", "dbo.TINHTRANGS");
            DropForeignKey("dbo.LOGSUCOPHONGS", "sucophong_id", "dbo.SUCOPHONGS");
            DropForeignKey("dbo.SUCOPHONGS", "tinhtrang_id", "dbo.TINHTRANGS");
            DropForeignKey("dbo.SUCOPHONGS", "phong_id", "dbo.PHONGS");
            DropForeignKey("dbo.SUCOPHONG_HINHANH", "id2", "dbo.HINHANHS");
            DropForeignKey("dbo.SUCOPHONG_HINHANH", "id1", "dbo.SUCOPHONGS");
            DropForeignKey("dbo.LOGSUCOPHONGS", "quantrivien_id", "dbo.QUANTRIVIENS");
            DropForeignKey("dbo.LOGSUCOPHONG_HINHANH", "id2", "dbo.HINHANHS");
            DropForeignKey("dbo.LOGSUCOPHONG_HINHANH", "id1", "dbo.LOGSUCOPHONGS");
            DropForeignKey("dbo.QUANTRIVIENS", "group_id", "dbo.GROUPS");
            DropForeignKey("dbo.GROUP_PERMISSION", "permission_id", "dbo.PERMISSIONS");
            DropForeignKey("dbo.GROUP_PERMISSION", "group_id", "dbo.GROUPS");
            DropForeignKey("dbo.LOGTHIETBIS", "phong_id", "dbo.PHONGS");
            DropForeignKey("dbo.LOGTHIETBI_HINHANH", "id2", "dbo.HINHANHS");
            DropForeignKey("dbo.LOGTHIETBI_HINHANH", "id1", "dbo.LOGTHIETBIS");
            DropForeignKey("dbo.PHONG_HINHANH", "id2", "dbo.HINHANHS");
            DropForeignKey("dbo.PHONG_HINHANH", "id1", "dbo.PHONGS");
            DropForeignKey("dbo.CTTHIETBI_HINHANH", "id2", "dbo.HINHANHS");
            DropForeignKey("dbo.CTTHIETBI_HINHANH", "id1", "dbo.CTTHIETBIS");
            DropForeignKey("dbo.DAYS", "coso_id", "dbo.COSOS");
            DropIndex("dbo.COSO_HINHANH", new[] { "id2" });
            DropIndex("dbo.COSO_HINHANH", new[] { "id1" });
            DropIndex("dbo.DAY_HINHANH", new[] { "id2" });
            DropIndex("dbo.DAY_HINHANH", new[] { "id1" });
            DropIndex("dbo.TANG_HINHANH", new[] { "id2" });
            DropIndex("dbo.TANG_HINHANH", new[] { "id1" });
            DropIndex("dbo.NHANVIENPT_HINHANH", new[] { "id2" });
            DropIndex("dbo.NHANVIENPT_HINHANH", new[] { "id1" });
            DropIndex("dbo.THIETBI_HINHANH", new[] { "id2" });
            DropIndex("dbo.THIETBI_HINHANH", new[] { "id1" });
            DropIndex("dbo.SUCOPHONG_HINHANH", new[] { "id2" });
            DropIndex("dbo.SUCOPHONG_HINHANH", new[] { "id1" });
            DropIndex("dbo.LOGSUCOPHONG_HINHANH", new[] { "id2" });
            DropIndex("dbo.LOGSUCOPHONG_HINHANH", new[] { "id1" });
            DropIndex("dbo.GROUP_PERMISSION", new[] { "permission_id" });
            DropIndex("dbo.GROUP_PERMISSION", new[] { "group_id" });
            DropIndex("dbo.LOGTHIETBI_HINHANH", new[] { "id2" });
            DropIndex("dbo.LOGTHIETBI_HINHANH", new[] { "id1" });
            DropIndex("dbo.PHONG_HINHANH", new[] { "id2" });
            DropIndex("dbo.PHONG_HINHANH", new[] { "id1" });
            DropIndex("dbo.CTTHIETBI_HINHANH", new[] { "id2" });
            DropIndex("dbo.CTTHIETBI_HINHANH", new[] { "id1" });
            DropIndex("dbo.SETTINGS", new[] { "key" });
            DropIndex("dbo.TANGS", new[] { "day_id" });
            DropIndex("dbo.VITRIS", new[] { "tang_id" });
            DropIndex("dbo.VITRIS", new[] { "day_id" });
            DropIndex("dbo.VITRIS", new[] { "coso_id" });
            DropIndex("dbo.LOAITHIETBIS", new[] { "parent_id" });
            DropIndex("dbo.LOAITHIETBIS", new[] { "ten" });
            DropIndex("dbo.THIETBIS", new[] { "loaithietbi_id" });
            DropIndex("dbo.GIANGVIENS", new[] { "username" });
            DropIndex("dbo.PHIEUMUONPHONGS", new[] { "Phong_id" });
            DropIndex("dbo.PHIEUMUONPHONGS", new[] { "giangvien_id" });
            DropIndex("dbo.PHIEUMUONPHONGS", new[] { "quantrivien_id" });
            DropIndex("dbo.TINHTRANGS", new[] { "value" });
            DropIndex("dbo.TINHTRANGS", new[] { "key" });
            DropIndex("dbo.SUCOPHONGS", new[] { "phong_id" });
            DropIndex("dbo.SUCOPHONGS", new[] { "tinhtrang_id" });
            DropIndex("dbo.LOGSUCOPHONGS", new[] { "quantrivien_id" });
            DropIndex("dbo.LOGSUCOPHONGS", new[] { "sucophong_id" });
            DropIndex("dbo.LOGSUCOPHONGS", new[] { "tinhtrang_id" });
            DropIndex("dbo.PERMISSIONS", new[] { "key" });
            DropIndex("dbo.GROUPS", new[] { "ten" });
            DropIndex("dbo.QUANTRIVIENS", new[] { "username" });
            DropIndex("dbo.QUANTRIVIENS", new[] { "group_id" });
            DropIndex("dbo.LOGTHIETBIS", new[] { "quantrivien_id" });
            DropIndex("dbo.LOGTHIETBIS", new[] { "phong_id" });
            DropIndex("dbo.LOGTHIETBIS", new[] { "tinhtrang_id" });
            DropIndex("dbo.LOGTHIETBIS", new[] { "thietbi_id" });
            DropIndex("dbo.PHONGS", new[] { "quantrivien_id" });
            DropIndex("dbo.PHONGS", new[] { "nhanvienpt_id" });
            DropIndex("dbo.PHONGS", new[] { "vitri_id" });
            DropIndex("dbo.PHONGS", "nothing");
            DropIndex("dbo.CTTHIETBIS", new[] { "tinhtrang_id" });
            DropIndex("dbo.CTTHIETBIS", new[] { "thietbi_id" });
            DropIndex("dbo.CTTHIETBIS", new[] { "phong_id" });
            DropIndex("dbo.DAYS", new[] { "coso_id" });
            DropIndex("dbo.COSOS", new[] { "ten" });
            DropTable("dbo.COSO_HINHANH");
            DropTable("dbo.DAY_HINHANH");
            DropTable("dbo.TANG_HINHANH");
            DropTable("dbo.NHANVIENPT_HINHANH");
            DropTable("dbo.THIETBI_HINHANH");
            DropTable("dbo.SUCOPHONG_HINHANH");
            DropTable("dbo.LOGSUCOPHONG_HINHANH");
            DropTable("dbo.GROUP_PERMISSION");
            DropTable("dbo.LOGTHIETBI_HINHANH");
            DropTable("dbo.PHONG_HINHANH");
            DropTable("dbo.CTTHIETBI_HINHANH");
            DropTable("dbo.SETTINGS");
            DropTable("dbo.LOGHETHONGS");
            DropTable("dbo.TANGS");
            DropTable("dbo.VITRIS");
            DropTable("dbo.NHANVIENPTS");
            DropTable("dbo.LOAITHIETBIS");
            DropTable("dbo.THIETBIS");
            DropTable("dbo.GIANGVIENS");
            DropTable("dbo.PHIEUMUONPHONGS");
            DropTable("dbo.TINHTRANGS");
            DropTable("dbo.SUCOPHONGS");
            DropTable("dbo.LOGSUCOPHONGS");
            DropTable("dbo.PERMISSIONS");
            DropTable("dbo.GROUPS");
            DropTable("dbo.QUANTRIVIENS");
            DropTable("dbo.LOGTHIETBIS");
            DropTable("dbo.PHONGS");
            DropTable("dbo.CTTHIETBIS");
            DropTable("dbo.HINHANHS");
            DropTable("dbo.DAYS");
            DropTable("dbo.COSOS");
        }
    }
}

namespace QuanLyTaiSan.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class them_nghiepvu_muonphong : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PHIEUMUONPHONGS",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        ngaymuon = c.DateTime(nullable: false),
                        ngaytra = c.DateTime(nullable: false),
                        lydomuon = c.String(),
                        trangthai = c.Int(nullable: false),
                        lydotuchoi = c.String(),
                        quantrivien_id = c.Int(),
                        soluongsv = c.Int(nullable: false),
                        subId = c.String(),
                        order = c.Int(),
                        mota = c.String(),
                        date_create = c.DateTime(),
                        date_modified = c.DateTime(),
                        giangvien_id = c.Int(nullable: false),
                        phong_id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.GIANGVIENS", t => t.giangvien_id)
                .ForeignKey("dbo.PHONGS", t => t.phong_id)
                .ForeignKey("dbo.QUANTRIVIENS", t => t.quantrivien_id)
                .Index(t => t.quantrivien_id)
                .Index(t => t.giangvien_id)
                .Index(t => t.phong_id);
            
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
            
            AddColumn("dbo.PHONGS", "quantrivien_id", c => c.Int());
            CreateIndex("dbo.PHONGS", "quantrivien_id");
            AddForeignKey("dbo.PHONGS", "quantrivien_id", "dbo.QUANTRIVIENS", "id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PHONGS", "quantrivien_id", "dbo.QUANTRIVIENS");
            DropForeignKey("dbo.PHIEUMUONPHONGS", "quantrivien_id", "dbo.QUANTRIVIENS");
            DropForeignKey("dbo.PHIEUMUONPHONGS", "phong_id", "dbo.PHONGS");
            DropForeignKey("dbo.PHIEUMUONPHONGS", "giangvien_id", "dbo.GIANGVIENS");
            DropIndex("dbo.GIANGVIENS", new[] { "username" });
            DropIndex("dbo.PHIEUMUONPHONGS", new[] { "phong_id" });
            DropIndex("dbo.PHIEUMUONPHONGS", new[] { "giangvien_id" });
            DropIndex("dbo.PHIEUMUONPHONGS", new[] { "quantrivien_id" });
            DropIndex("dbo.PHONGS", new[] { "quantrivien_id" });
            DropColumn("dbo.PHONGS", "quantrivien_id");
            DropTable("dbo.GIANGVIENS");
            DropTable("dbo.PHIEUMUONPHONGS");
        }
    }
}

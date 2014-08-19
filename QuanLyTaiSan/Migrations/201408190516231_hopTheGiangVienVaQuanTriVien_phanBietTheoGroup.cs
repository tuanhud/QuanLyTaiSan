namespace QuanLyTaiSan.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class hopTheGiangVienVaQuanTriVien_phanBietTheoGroup : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.PHIEUMUONPHONGS", "giangvien_id", "dbo.GIANGVIENS");
            DropIndex("dbo.PHIEUMUONPHONGS", new[] { "quantrivien_id" });
            DropIndex("dbo.PHIEUMUONPHONGS", new[] { "giangvien_id" });
            DropIndex("dbo.GIANGVIENS", new[] { "username" });
            AddColumn("dbo.QUANTRIVIENS", "donvi", c => c.String());
            AddColumn("dbo.QUANTRIVIENS", "email", c => c.String());
            AddColumn("dbo.PHIEUMUONPHONGS", "donvi", c => c.String(nullable: false));
            AddColumn("dbo.PHIEUMUONPHONGS", "nguoimuon_id", c => c.Int(nullable: false));
            AddColumn("dbo.PHIEUMUONPHONGS", "nguoiduyet_id", c => c.Int());
            CreateIndex("dbo.PHIEUMUONPHONGS", "nguoimuon_id");
            CreateIndex("dbo.PHIEUMUONPHONGS", "nguoiduyet_id");
            CreateIndex("dbo.PHIEUMUONPHONGS", "QuanTriVien_id");
            AddForeignKey("dbo.PHIEUMUONPHONGS", "nguoiduyet_id", "dbo.QUANTRIVIENS", "id");
            AddForeignKey("dbo.PHIEUMUONPHONGS", "nguoimuon_id", "dbo.QUANTRIVIENS", "id");
            DropColumn("dbo.PHIEUMUONPHONGS", "khoaphongmuon");
            DropColumn("dbo.PHIEUMUONPHONGS", "giangvien_id");
            DropTable("dbo.GIANGVIENS");
        }
        
        public override void Down()
        {
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
                .PrimaryKey(t => t.id);
            
            AddColumn("dbo.PHIEUMUONPHONGS", "giangvien_id", c => c.Int(nullable: false));
            AddColumn("dbo.PHIEUMUONPHONGS", "khoaphongmuon", c => c.String(nullable: false));
            DropForeignKey("dbo.PHIEUMUONPHONGS", "nguoimuon_id", "dbo.QUANTRIVIENS");
            DropForeignKey("dbo.PHIEUMUONPHONGS", "nguoiduyet_id", "dbo.QUANTRIVIENS");
            DropIndex("dbo.PHIEUMUONPHONGS", new[] { "QuanTriVien_id" });
            DropIndex("dbo.PHIEUMUONPHONGS", new[] { "nguoiduyet_id" });
            DropIndex("dbo.PHIEUMUONPHONGS", new[] { "nguoimuon_id" });
            DropColumn("dbo.PHIEUMUONPHONGS", "nguoiduyet_id");
            DropColumn("dbo.PHIEUMUONPHONGS", "nguoimuon_id");
            DropColumn("dbo.PHIEUMUONPHONGS", "donvi");
            DropColumn("dbo.QUANTRIVIENS", "email");
            DropColumn("dbo.QUANTRIVIENS", "donvi");
            CreateIndex("dbo.GIANGVIENS", "username", unique: true);
            CreateIndex("dbo.PHIEUMUONPHONGS", "giangvien_id");
            CreateIndex("dbo.PHIEUMUONPHONGS", "quantrivien_id");
            AddForeignKey("dbo.PHIEUMUONPHONGS", "giangvien_id", "dbo.GIANGVIENS", "id");
        }
    }
}

namespace QuanLyTaiSan.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mot_entity_co_nhieuhinhanh : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.DAYS", "hinhanh_id", "dbo.HINHANHS");
            DropForeignKey("dbo.TANGS", "hinhanh_id", "dbo.HINHANHS");
            DropForeignKey("dbo.THIETBIS", "hinhanh_id", "dbo.HINHANHS");
            DropForeignKey("dbo.PHONGS", "hinhanh_id", "dbo.HINHANHS");
            DropForeignKey("dbo.NHANVIENPTS", "hinh_id", "dbo.HINHANHS");
            DropForeignKey("dbo.COSOS", "hinhanh_id", "dbo.HINHANHS");
            DropIndex("dbo.COSOS", new[] { "hinhanh_id" });
            DropIndex("dbo.DAYS", new[] { "hinhanh_id" });
            DropIndex("dbo.TANGS", new[] { "hinhanh_id" });
            DropIndex("dbo.PHONGS", new[] { "hinhanh_id" });
            DropIndex("dbo.THIETBIS", new[] { "hinhanh_id" });
            DropIndex("dbo.NHANVIENPTS", new[] { "hinh_id" });
            AddColumn("dbo.HINHANHS", "coso_id", c => c.Int());
            AddColumn("dbo.HINHANHS", "day_id", c => c.Int());
            AddColumn("dbo.HINHANHS", "nhanvienpt_id", c => c.Int());
            AddColumn("dbo.HINHANHS", "thietbi_id", c => c.Int());
            AddColumn("dbo.HINHANHS", "phong_id", c => c.Int());
            AddColumn("dbo.HINHANHS", "tang_id", c => c.Int());
            CreateIndex("dbo.HINHANHS", "coso_id");
            CreateIndex("dbo.HINHANHS", "day_id");
            CreateIndex("dbo.HINHANHS", "nhanvienpt_id");
            CreateIndex("dbo.HINHANHS", "thietbi_id");
            CreateIndex("dbo.HINHANHS", "phong_id");
            CreateIndex("dbo.HINHANHS", "tang_id");
            AddForeignKey("dbo.HINHANHS", "coso_id", "dbo.COSOS", "id");
            AddForeignKey("dbo.HINHANHS", "day_id", "dbo.DAYS", "id");
            AddForeignKey("dbo.HINHANHS", "nhanvienpt_id", "dbo.NHANVIENPTS", "id");
            AddForeignKey("dbo.HINHANHS", "thietbi_id", "dbo.THIETBIS", "id");
            AddForeignKey("dbo.HINHANHS", "phong_id", "dbo.PHONGS", "id");
            AddForeignKey("dbo.HINHANHS", "tang_id", "dbo.TANGS", "id");
            DropColumn("dbo.COSOS", "hinhanh_id");
            DropColumn("dbo.DAYS", "hinhanh_id");
            DropColumn("dbo.TANGS", "hinhanh_id");
            DropColumn("dbo.PHONGS", "hinhanh_id");
            DropColumn("dbo.THIETBIS", "hinhanh_id");
            DropColumn("dbo.NHANVIENPTS", "hinh_id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.NHANVIENPTS", "hinh_id", c => c.Int());
            AddColumn("dbo.THIETBIS", "hinhanh_id", c => c.Int());
            AddColumn("dbo.PHONGS", "hinhanh_id", c => c.Int());
            AddColumn("dbo.TANGS", "hinhanh_id", c => c.Int());
            AddColumn("dbo.DAYS", "hinhanh_id", c => c.Int());
            AddColumn("dbo.COSOS", "hinhanh_id", c => c.Int());
            DropForeignKey("dbo.HINHANHS", "tang_id", "dbo.TANGS");
            DropForeignKey("dbo.HINHANHS", "phong_id", "dbo.PHONGS");
            DropForeignKey("dbo.HINHANHS", "thietbi_id", "dbo.THIETBIS");
            DropForeignKey("dbo.HINHANHS", "nhanvienpt_id", "dbo.NHANVIENPTS");
            DropForeignKey("dbo.HINHANHS", "day_id", "dbo.DAYS");
            DropForeignKey("dbo.HINHANHS", "coso_id", "dbo.COSOS");
            DropIndex("dbo.HINHANHS", new[] { "tang_id" });
            DropIndex("dbo.HINHANHS", new[] { "phong_id" });
            DropIndex("dbo.HINHANHS", new[] { "thietbi_id" });
            DropIndex("dbo.HINHANHS", new[] { "nhanvienpt_id" });
            DropIndex("dbo.HINHANHS", new[] { "day_id" });
            DropIndex("dbo.HINHANHS", new[] { "coso_id" });
            DropColumn("dbo.HINHANHS", "tang_id");
            DropColumn("dbo.HINHANHS", "phong_id");
            DropColumn("dbo.HINHANHS", "thietbi_id");
            DropColumn("dbo.HINHANHS", "nhanvienpt_id");
            DropColumn("dbo.HINHANHS", "day_id");
            DropColumn("dbo.HINHANHS", "coso_id");
            CreateIndex("dbo.NHANVIENPTS", "hinh_id");
            CreateIndex("dbo.THIETBIS", "hinhanh_id");
            CreateIndex("dbo.PHONGS", "hinhanh_id");
            CreateIndex("dbo.TANGS", "hinhanh_id");
            CreateIndex("dbo.DAYS", "hinhanh_id");
            CreateIndex("dbo.COSOS", "hinhanh_id");
            AddForeignKey("dbo.COSOS", "hinhanh_id", "dbo.HINHANHS", "id");
            AddForeignKey("dbo.NHANVIENPTS", "hinh_id", "dbo.HINHANHS", "id");
            AddForeignKey("dbo.PHONGS", "hinhanh_id", "dbo.HINHANHS", "id");
            AddForeignKey("dbo.THIETBIS", "hinhanh_id", "dbo.HINHANHS", "id");
            AddForeignKey("dbo.TANGS", "hinhanh_id", "dbo.HINHANHS", "id");
            AddForeignKey("dbo.DAYS", "hinhanh_id", "dbo.HINHANHS", "id");
        }
    }
}

namespace QuanLyTaiSan.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class them_rangbuoc_xoa_cs_xoaluonvitri_ : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.CTTHIETBIS", "phong_id", "dbo.PHONGS");
            DropForeignKey("dbo.CTTHIETBIS", "thietbi_id", "dbo.THIETBIS");
            DropForeignKey("dbo.CTTHIETBIS", "tinhtrang_id", "dbo.TINHTRANGS");
            DropForeignKey("dbo.THIETBIS", "loaithietbi_id", "dbo.LOAITHIETBIS");
            DropForeignKey("dbo.LOGTHIETBIS", "phong_id", "dbo.PHONGS");
            DropForeignKey("dbo.LOGTHIETBIS", "thietbi_id", "dbo.THIETBIS");
            DropForeignKey("dbo.LOGTHIETBIS", "tinhtrang_id", "dbo.TINHTRANGS");
            DropIndex("dbo.CTTHIETBIS", new[] { "phong_id" });
            DropIndex("dbo.CTTHIETBIS", new[] { "thietbi_id" });
            DropIndex("dbo.CTTHIETBIS", new[] { "tinhtrang_id" });
            DropIndex("dbo.THIETBIS", new[] { "loaithietbi_id" });
            DropIndex("dbo.LOGTHIETBIS", new[] { "phong_id" });
            DropIndex("dbo.LOGTHIETBIS", new[] { "thietbi_id" });
            DropIndex("dbo.LOGTHIETBIS", new[] { "tinhtrang_id" });
            AlterColumn("dbo.CTTHIETBIS", "phong_id", c => c.Int(nullable: false));
            AlterColumn("dbo.CTTHIETBIS", "thietbi_id", c => c.Int(nullable: false));
            AlterColumn("dbo.CTTHIETBIS", "tinhtrang_id", c => c.Int(nullable: false));
            AlterColumn("dbo.THIETBIS", "loaithietbi_id", c => c.Int(nullable: false));
            AlterColumn("dbo.LOGTHIETBIS", "phong_id", c => c.Int(nullable: false));
            AlterColumn("dbo.LOGTHIETBIS", "thietbi_id", c => c.Int(nullable: false));
            AlterColumn("dbo.LOGTHIETBIS", "tinhtrang_id", c => c.Int(nullable: false));
            CreateIndex("dbo.CTTHIETBIS", "phong_id");
            CreateIndex("dbo.CTTHIETBIS", "thietbi_id");
            CreateIndex("dbo.CTTHIETBIS", "tinhtrang_id");
            CreateIndex("dbo.THIETBIS", "loaithietbi_id");
            CreateIndex("dbo.LOGTHIETBIS", "phong_id");
            CreateIndex("dbo.LOGTHIETBIS", "thietbi_id");
            CreateIndex("dbo.LOGTHIETBIS", "tinhtrang_id");
            AddForeignKey("dbo.CTTHIETBIS", "phong_id", "dbo.PHONGS", "id", cascadeDelete: true);
            AddForeignKey("dbo.CTTHIETBIS", "thietbi_id", "dbo.THIETBIS", "id", cascadeDelete: true);
            AddForeignKey("dbo.CTTHIETBIS", "tinhtrang_id", "dbo.TINHTRANGS", "id", cascadeDelete: true);
            AddForeignKey("dbo.THIETBIS", "loaithietbi_id", "dbo.LOAITHIETBIS", "id", cascadeDelete: true);
            AddForeignKey("dbo.LOGTHIETBIS", "phong_id", "dbo.PHONGS", "id", cascadeDelete: true);
            AddForeignKey("dbo.LOGTHIETBIS", "thietbi_id", "dbo.THIETBIS", "id", cascadeDelete: true);
            AddForeignKey("dbo.LOGTHIETBIS", "tinhtrang_id", "dbo.TINHTRANGS", "id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.LOGTHIETBIS", "tinhtrang_id", "dbo.TINHTRANGS");
            DropForeignKey("dbo.LOGTHIETBIS", "thietbi_id", "dbo.THIETBIS");
            DropForeignKey("dbo.LOGTHIETBIS", "phong_id", "dbo.PHONGS");
            DropForeignKey("dbo.THIETBIS", "loaithietbi_id", "dbo.LOAITHIETBIS");
            DropForeignKey("dbo.CTTHIETBIS", "tinhtrang_id", "dbo.TINHTRANGS");
            DropForeignKey("dbo.CTTHIETBIS", "thietbi_id", "dbo.THIETBIS");
            DropForeignKey("dbo.CTTHIETBIS", "phong_id", "dbo.PHONGS");
            DropIndex("dbo.LOGTHIETBIS", new[] { "tinhtrang_id" });
            DropIndex("dbo.LOGTHIETBIS", new[] { "thietbi_id" });
            DropIndex("dbo.LOGTHIETBIS", new[] { "phong_id" });
            DropIndex("dbo.THIETBIS", new[] { "loaithietbi_id" });
            DropIndex("dbo.CTTHIETBIS", new[] { "tinhtrang_id" });
            DropIndex("dbo.CTTHIETBIS", new[] { "thietbi_id" });
            DropIndex("dbo.CTTHIETBIS", new[] { "phong_id" });
            AlterColumn("dbo.LOGTHIETBIS", "tinhtrang_id", c => c.Int());
            AlterColumn("dbo.LOGTHIETBIS", "thietbi_id", c => c.Int());
            AlterColumn("dbo.LOGTHIETBIS", "phong_id", c => c.Int());
            AlterColumn("dbo.THIETBIS", "loaithietbi_id", c => c.Int());
            AlterColumn("dbo.CTTHIETBIS", "tinhtrang_id", c => c.Int());
            AlterColumn("dbo.CTTHIETBIS", "thietbi_id", c => c.Int());
            AlterColumn("dbo.CTTHIETBIS", "phong_id", c => c.Int());
            CreateIndex("dbo.LOGTHIETBIS", "tinhtrang_id");
            CreateIndex("dbo.LOGTHIETBIS", "thietbi_id");
            CreateIndex("dbo.LOGTHIETBIS", "phong_id");
            CreateIndex("dbo.THIETBIS", "loaithietbi_id");
            CreateIndex("dbo.CTTHIETBIS", "tinhtrang_id");
            CreateIndex("dbo.CTTHIETBIS", "thietbi_id");
            CreateIndex("dbo.CTTHIETBIS", "phong_id");
            AddForeignKey("dbo.LOGTHIETBIS", "tinhtrang_id", "dbo.TINHTRANGS", "id");
            AddForeignKey("dbo.LOGTHIETBIS", "thietbi_id", "dbo.THIETBIS", "id");
            AddForeignKey("dbo.LOGTHIETBIS", "phong_id", "dbo.PHONGS", "id");
            AddForeignKey("dbo.THIETBIS", "loaithietbi_id", "dbo.LOAITHIETBIS", "id");
            AddForeignKey("dbo.CTTHIETBIS", "tinhtrang_id", "dbo.TINHTRANGS", "id");
            AddForeignKey("dbo.CTTHIETBIS", "thietbi_id", "dbo.THIETBIS", "id");
            AddForeignKey("dbo.CTTHIETBIS", "phong_id", "dbo.PHONGS", "id");
        }
    }
}

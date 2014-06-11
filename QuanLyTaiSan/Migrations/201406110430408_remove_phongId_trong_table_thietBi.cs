namespace QuanLyTaiSan.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class remove_phongId_trong_table_thietBi : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.THIETBIS", "Phong_id", "dbo.PHONGS");
            DropIndex("dbo.THIETBIS", new[] { "Phong_id" });
            AlterColumn("dbo.COSOS", "date_create", c => c.DateTime());
            AlterColumn("dbo.COSOS", "date_modified", c => c.DateTime());
            AlterColumn("dbo.DAYS", "date_create", c => c.DateTime());
            AlterColumn("dbo.DAYS", "date_modified", c => c.DateTime());
            AlterColumn("dbo.TANGS", "date_create", c => c.DateTime());
            AlterColumn("dbo.TANGS", "date_modified", c => c.DateTime());
            AlterColumn("dbo.PHONGS", "date_create", c => c.DateTime());
            AlterColumn("dbo.PHONGS", "date_modified", c => c.DateTime());
            AlterColumn("dbo.THIETBIS", "ngaymua", c => c.DateTime());
            AlterColumn("dbo.THIETBIS", "ngaylap", c => c.DateTime());
            AlterColumn("dbo.THIETBIS", "date_create", c => c.DateTime());
            AlterColumn("dbo.THIETBIS", "date_modified", c => c.DateTime());
            DropColumn("dbo.THIETBIS", "Phong_id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.THIETBIS", "Phong_id", c => c.Int());
            AlterColumn("dbo.THIETBIS", "date_modified", c => c.DateTime(nullable: false));
            AlterColumn("dbo.THIETBIS", "date_create", c => c.DateTime(nullable: false));
            AlterColumn("dbo.THIETBIS", "ngaylap", c => c.DateTime(nullable: false));
            AlterColumn("dbo.THIETBIS", "ngaymua", c => c.DateTime(nullable: false));
            AlterColumn("dbo.PHONGS", "date_modified", c => c.DateTime(nullable: false));
            AlterColumn("dbo.PHONGS", "date_create", c => c.DateTime(nullable: false));
            AlterColumn("dbo.TANGS", "date_modified", c => c.DateTime(nullable: false));
            AlterColumn("dbo.TANGS", "date_create", c => c.DateTime(nullable: false));
            AlterColumn("dbo.DAYS", "date_modified", c => c.DateTime(nullable: false));
            AlterColumn("dbo.DAYS", "date_create", c => c.DateTime(nullable: false));
            AlterColumn("dbo.COSOS", "date_modified", c => c.DateTime(nullable: false));
            AlterColumn("dbo.COSOS", "date_create", c => c.DateTime(nullable: false));
            CreateIndex("dbo.THIETBIS", "Phong_id");
            AddForeignKey("dbo.THIETBIS", "Phong_id", "dbo.PHONGS", "id");
        }
    }
}

namespace QuanLyTaiSan.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class sua_thuoctinh_phieumuonphong : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PHIEUMUONPHONGS", "sophong", c => c.Int(nullable: false));
            DropColumn("dbo.PHIEUMUONPHONGS", "phong");
        }
        
        public override void Down()
        {
            AddColumn("dbo.PHIEUMUONPHONGS", "phong", c => c.String(nullable: false));
            DropColumn("dbo.PHIEUMUONPHONGS", "sophong");
        }
    }
}

namespace QuanLyTaiSan.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class sua_thuoc_tinh_phieumuonphong_lydotuchoi_thanh_ghichu : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PHIEUMUONPHONGS", "ghichu", c => c.String());
            DropColumn("dbo.PHIEUMUONPHONGS", "lydotuchoi");
        }
        
        public override void Down()
        {
            AddColumn("dbo.PHIEUMUONPHONGS", "lydotuchoi", c => c.String());
            DropColumn("dbo.PHIEUMUONPHONGS", "ghichu");
        }
    }
}

namespace QuanLyTaiSan.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class them_thuoc_tinh_khoaphongmuon : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PHIEUMUONPHONGS", "khoaphongmuon", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.PHIEUMUONPHONGS", "khoaphongmuon");
        }
    }
}

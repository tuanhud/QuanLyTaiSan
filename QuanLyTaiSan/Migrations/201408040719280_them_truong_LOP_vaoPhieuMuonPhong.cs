namespace QuanLyTaiSan.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class them_truong_LOP_vaoPhieuMuonPhong : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PHIEUMUONPHONGS", "lop", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.PHIEUMUONPHONGS", "lop");
        }
    }
}

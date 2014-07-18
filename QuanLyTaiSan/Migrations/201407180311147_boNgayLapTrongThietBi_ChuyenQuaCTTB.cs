namespace QuanLyTaiSan.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class boNgayLapTrongThietBi_ChuyenQuaCTTB : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.THIETBIS", "ngaylap");
        }
        
        public override void Down()
        {
            AddColumn("dbo.THIETBIS", "ngaylap", c => c.DateTime());
        }
    }
}

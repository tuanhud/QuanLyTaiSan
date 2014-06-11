namespace QuanLyTaiSan.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class them_mota_cho_mot_vai_doiTuong : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.GROUPS", "mota", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.GROUPS", "mota");
        }
    }
}

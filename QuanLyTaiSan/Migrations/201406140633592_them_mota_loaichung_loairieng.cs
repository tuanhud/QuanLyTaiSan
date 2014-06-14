namespace QuanLyTaiSan.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class them_mota_loaichung_loairieng : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.LOAITHIETBIS", "loaichung", c => c.Boolean(nullable: false));
            AddColumn("dbo.LOGTINHTRANGS", "mota", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.LOGTINHTRANGS", "mota");
            DropColumn("dbo.LOAITHIETBIS", "loaichung");
        }
    }
}

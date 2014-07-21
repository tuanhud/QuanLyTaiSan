namespace QuanLyTaiSan.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class them_order_cho_day_tang_tinhtrang_detienSapXepVeSau : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.DAYS", "order", c => c.Int());
            AddColumn("dbo.TINHTRANGS", "order", c => c.Int());
            AddColumn("dbo.TANGS", "order", c => c.Int());
        }
        
        public override void Down()
        {
            DropColumn("dbo.TANGS", "order");
            DropColumn("dbo.TINHTRANGS", "order");
            DropColumn("dbo.DAYS", "order");
        }
    }
}

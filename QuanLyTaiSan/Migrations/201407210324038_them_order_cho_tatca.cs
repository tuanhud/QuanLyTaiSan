namespace QuanLyTaiSan.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class them_order_cho_tatca : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.HINHANHS", "order", c => c.Int());
            AddColumn("dbo.CTTHIETBIS", "order", c => c.Int());
            AddColumn("dbo.PHONGS", "order", c => c.Int());
            AddColumn("dbo.LOGTHIETBIS", "order", c => c.Int());
            AddColumn("dbo.QUANTRIVIENS", "order", c => c.Int());
            AddColumn("dbo.GROUPS", "order", c => c.Int());
            AddColumn("dbo.PERMISSIONS", "order", c => c.Int());
            AddColumn("dbo.LOGSUCOPHONGS", "order", c => c.Int());
            AddColumn("dbo.SUCOPHONGS", "order", c => c.Int());
            AddColumn("dbo.THIETBIS", "order", c => c.Int());
            AddColumn("dbo.LOAITHIETBIS", "order", c => c.Int());
            AddColumn("dbo.NHANVIENPTS", "order", c => c.Int());
            AddColumn("dbo.VITRIS", "order", c => c.Int());
            AddColumn("dbo.LOGHETHONGS", "order", c => c.Int());
            AddColumn("dbo.SETTINGS", "order", c => c.Int());
        }
        
        public override void Down()
        {
            DropColumn("dbo.SETTINGS", "order");
            DropColumn("dbo.LOGHETHONGS", "order");
            DropColumn("dbo.VITRIS", "order");
            DropColumn("dbo.NHANVIENPTS", "order");
            DropColumn("dbo.LOAITHIETBIS", "order");
            DropColumn("dbo.THIETBIS", "order");
            DropColumn("dbo.SUCOPHONGS", "order");
            DropColumn("dbo.LOGSUCOPHONGS", "order");
            DropColumn("dbo.PERMISSIONS", "order");
            DropColumn("dbo.GROUPS", "order");
            DropColumn("dbo.QUANTRIVIENS", "order");
            DropColumn("dbo.LOGTHIETBIS", "order");
            DropColumn("dbo.PHONGS", "order");
            DropColumn("dbo.CTTHIETBIS", "order");
            DropColumn("dbo.HINHANHS", "order");
        }
    }
}

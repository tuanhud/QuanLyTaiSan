namespace TSCD.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class them_nuoc_san_xuat_choTaiSan : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.TAISANS", "nuocsx", c => c.String());
            AlterColumn("dbo.QUANTRIVIENS", "hoten", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.QUANTRIVIENS", "hoten", c => c.String(nullable: false));
            DropColumn("dbo.TAISANS", "nuocsx");
        }
    }
}

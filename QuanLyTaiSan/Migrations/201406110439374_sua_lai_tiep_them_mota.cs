namespace QuanLyTaiSan.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class sua_lai_tiep_them_mota : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.VITRIS", "mota", c => c.String());
            AddColumn("dbo.TINHTRANGS", "mota", c => c.String());
            AlterColumn("dbo.NHANVIENPTS", "date_create", c => c.DateTime());
            AlterColumn("dbo.NHANVIENPTS", "date_modified", c => c.DateTime());
            AlterColumn("dbo.QUANTRIVIENS", "date_create", c => c.DateTime());
            AlterColumn("dbo.QUANTRIVIENS", "date_modified", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.QUANTRIVIENS", "date_modified", c => c.DateTime(nullable: false));
            AlterColumn("dbo.QUANTRIVIENS", "date_create", c => c.DateTime(nullable: false));
            AlterColumn("dbo.NHANVIENPTS", "date_modified", c => c.DateTime(nullable: false));
            AlterColumn("dbo.NHANVIENPTS", "date_create", c => c.DateTime(nullable: false));
            DropColumn("dbo.TINHTRANGS", "mota");
            DropColumn("dbo.VITRIS", "mota");
        }
    }
}

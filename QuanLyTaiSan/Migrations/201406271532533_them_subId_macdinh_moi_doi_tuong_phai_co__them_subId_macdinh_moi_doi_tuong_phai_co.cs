namespace QuanLyTaiSan.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class them_subId_macdinh_moi_doi_tuong_phai_co__them_subId_macdinh_moi_doi_tuong_phai_co : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.HINHANHS", "subId", c => c.String());
            AddColumn("dbo.HINHANHS", "mota", c => c.String());
            AddColumn("dbo.HINHANHS", "date_create", c => c.DateTime());
            AddColumn("dbo.HINHANHS", "date_modified", c => c.DateTime());
            AddColumn("dbo.NHANVIENPTS", "mota", c => c.String());
            AddColumn("dbo.CTTHIETBIS", "subId", c => c.String());
            AddColumn("dbo.CTTHIETBIS", "mota", c => c.String());
            AddColumn("dbo.CTTHIETBIS", "date_create", c => c.DateTime());
            AddColumn("dbo.CTTHIETBIS", "date_modified", c => c.DateTime());
            AddColumn("dbo.LOAITHIETBIS", "subId", c => c.String());
            AddColumn("dbo.LOGTHIETBIS", "subId", c => c.String());
            AddColumn("dbo.LOGTHIETBIS", "date_create", c => c.DateTime());
            AddColumn("dbo.LOGTHIETBIS", "date_modified", c => c.DateTime());
            AddColumn("dbo.TINHTRANGS", "subId", c => c.String());
            AddColumn("dbo.TINHTRANGS", "date_create", c => c.DateTime());
            AddColumn("dbo.TINHTRANGS", "date_modified", c => c.DateTime());
            AddColumn("dbo.VITRIS", "subId", c => c.String());
            AddColumn("dbo.VITRIS", "date_create", c => c.DateTime());
            AddColumn("dbo.VITRIS", "date_modified", c => c.DateTime());
            AddColumn("dbo.GROUPS", "subId", c => c.String());
            AddColumn("dbo.GROUPS", "date_create", c => c.DateTime());
            AddColumn("dbo.GROUPS", "date_modified", c => c.DateTime());
            AddColumn("dbo.QUANTRIVIENS", "mota", c => c.String());
            AddColumn("dbo.PERMISSIONS", "subId", c => c.String());
            AddColumn("dbo.PERMISSIONS", "date_create", c => c.DateTime());
            AddColumn("dbo.PERMISSIONS", "date_modified", c => c.DateTime());
            AddColumn("dbo.LOGHETHONGS", "subId", c => c.String());
            AddColumn("dbo.LOGHETHONGS", "date_create", c => c.DateTime());
            AddColumn("dbo.LOGHETHONGS", "date_modified", c => c.DateTime());
            AddColumn("dbo.SETTINGS", "subId", c => c.String());
            AddColumn("dbo.SETTINGS", "mota", c => c.String());
            AddColumn("dbo.SETTINGS", "date_create", c => c.DateTime());
            AddColumn("dbo.SETTINGS", "date_modified", c => c.DateTime());
            AlterColumn("dbo.HINHANHS", "path", c => c.String(nullable: false, maxLength: 255));
            AlterColumn("dbo.LOAITHIETBIS", "ten", c => c.String(nullable: false));
            AlterColumn("dbo.LOAITHIETBIS", "date_create", c => c.DateTime());
            AlterColumn("dbo.LOAITHIETBIS", "date_modified", c => c.DateTime());
            AlterColumn("dbo.LOGHETHONGS", "mota", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.LOGHETHONGS", "mota", c => c.String(nullable: false));
            AlterColumn("dbo.LOAITHIETBIS", "date_modified", c => c.DateTime(nullable: false));
            AlterColumn("dbo.LOAITHIETBIS", "date_create", c => c.DateTime(nullable: false));
            AlterColumn("dbo.LOAITHIETBIS", "ten", c => c.String());
            AlterColumn("dbo.HINHANHS", "path", c => c.String(maxLength: 255));
            DropColumn("dbo.SETTINGS", "date_modified");
            DropColumn("dbo.SETTINGS", "date_create");
            DropColumn("dbo.SETTINGS", "mota");
            DropColumn("dbo.SETTINGS", "subId");
            DropColumn("dbo.LOGHETHONGS", "date_modified");
            DropColumn("dbo.LOGHETHONGS", "date_create");
            DropColumn("dbo.LOGHETHONGS", "subId");
            DropColumn("dbo.PERMISSIONS", "date_modified");
            DropColumn("dbo.PERMISSIONS", "date_create");
            DropColumn("dbo.PERMISSIONS", "subId");
            DropColumn("dbo.QUANTRIVIENS", "mota");
            DropColumn("dbo.GROUPS", "date_modified");
            DropColumn("dbo.GROUPS", "date_create");
            DropColumn("dbo.GROUPS", "subId");
            DropColumn("dbo.VITRIS", "date_modified");
            DropColumn("dbo.VITRIS", "date_create");
            DropColumn("dbo.VITRIS", "subId");
            DropColumn("dbo.TINHTRANGS", "date_modified");
            DropColumn("dbo.TINHTRANGS", "date_create");
            DropColumn("dbo.TINHTRANGS", "subId");
            DropColumn("dbo.LOGTHIETBIS", "date_modified");
            DropColumn("dbo.LOGTHIETBIS", "date_create");
            DropColumn("dbo.LOGTHIETBIS", "subId");
            DropColumn("dbo.LOAITHIETBIS", "subId");
            DropColumn("dbo.CTTHIETBIS", "date_modified");
            DropColumn("dbo.CTTHIETBIS", "date_create");
            DropColumn("dbo.CTTHIETBIS", "mota");
            DropColumn("dbo.CTTHIETBIS", "subId");
            DropColumn("dbo.NHANVIENPTS", "mota");
            DropColumn("dbo.HINHANHS", "date_modified");
            DropColumn("dbo.HINHANHS", "date_create");
            DropColumn("dbo.HINHANHS", "mota");
            DropColumn("dbo.HINHANHS", "subId");
        }
    }
}

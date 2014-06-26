namespace QuanLyTaiSan.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TURN_OFF_CASCADE_DELETE : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.DAYS", "coso_id", "dbo.COSOS");
            DropForeignKey("dbo.VITRIS", "coso_id", "dbo.COSOS");
            DropForeignKey("dbo.TANGS", "day_id", "dbo.DAYS");
            DropForeignKey("dbo.CTTHIETBIS", "phong_id", "dbo.PHONGS");
            DropForeignKey("dbo.LOGTHIETBIS", "phong_id", "dbo.PHONGS");
            DropForeignKey("dbo.PHONGS", "vitri_id", "dbo.VITRIS");
            DropForeignKey("dbo.CTTHIETBIS", "thietbi_id", "dbo.THIETBIS");
            DropForeignKey("dbo.CTTHIETBIS", "tinhtrang_id", "dbo.TINHTRANGS");
            DropForeignKey("dbo.THIETBIS", "loaithietbi_id", "dbo.LOAITHIETBIS");
            DropForeignKey("dbo.LOGTHIETBIS", "thietbi_id", "dbo.THIETBIS");
            DropForeignKey("dbo.LOGTHIETBIS", "tinhtrang_id", "dbo.TINHTRANGS");
            DropForeignKey("dbo.QUANTRIVIENS", "group_id", "dbo.GROUPS");
            AddForeignKey("dbo.DAYS", "coso_id", "dbo.COSOS", "id");
            AddForeignKey("dbo.VITRIS", "coso_id", "dbo.COSOS", "id");
            AddForeignKey("dbo.TANGS", "day_id", "dbo.DAYS", "id");
            AddForeignKey("dbo.CTTHIETBIS", "phong_id", "dbo.PHONGS", "id");
            AddForeignKey("dbo.LOGTHIETBIS", "phong_id", "dbo.PHONGS", "id");
            AddForeignKey("dbo.PHONGS", "vitri_id", "dbo.VITRIS", "id");
            AddForeignKey("dbo.CTTHIETBIS", "thietbi_id", "dbo.THIETBIS", "id");
            AddForeignKey("dbo.CTTHIETBIS", "tinhtrang_id", "dbo.TINHTRANGS", "id");
            AddForeignKey("dbo.THIETBIS", "loaithietbi_id", "dbo.LOAITHIETBIS", "id");
            AddForeignKey("dbo.LOGTHIETBIS", "thietbi_id", "dbo.THIETBIS", "id");
            AddForeignKey("dbo.LOGTHIETBIS", "tinhtrang_id", "dbo.TINHTRANGS", "id");
            AddForeignKey("dbo.QUANTRIVIENS", "group_id", "dbo.GROUPS", "id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.QUANTRIVIENS", "group_id", "dbo.GROUPS");
            DropForeignKey("dbo.LOGTHIETBIS", "tinhtrang_id", "dbo.TINHTRANGS");
            DropForeignKey("dbo.LOGTHIETBIS", "thietbi_id", "dbo.THIETBIS");
            DropForeignKey("dbo.THIETBIS", "loaithietbi_id", "dbo.LOAITHIETBIS");
            DropForeignKey("dbo.CTTHIETBIS", "tinhtrang_id", "dbo.TINHTRANGS");
            DropForeignKey("dbo.CTTHIETBIS", "thietbi_id", "dbo.THIETBIS");
            DropForeignKey("dbo.PHONGS", "vitri_id", "dbo.VITRIS");
            DropForeignKey("dbo.LOGTHIETBIS", "phong_id", "dbo.PHONGS");
            DropForeignKey("dbo.CTTHIETBIS", "phong_id", "dbo.PHONGS");
            DropForeignKey("dbo.TANGS", "day_id", "dbo.DAYS");
            DropForeignKey("dbo.VITRIS", "coso_id", "dbo.COSOS");
            DropForeignKey("dbo.DAYS", "coso_id", "dbo.COSOS");
            AddForeignKey("dbo.QUANTRIVIENS", "group_id", "dbo.GROUPS", "id", cascadeDelete: true);
            AddForeignKey("dbo.LOGTHIETBIS", "tinhtrang_id", "dbo.TINHTRANGS", "id", cascadeDelete: true);
            AddForeignKey("dbo.LOGTHIETBIS", "thietbi_id", "dbo.THIETBIS", "id", cascadeDelete: true);
            AddForeignKey("dbo.THIETBIS", "loaithietbi_id", "dbo.LOAITHIETBIS", "id", cascadeDelete: true);
            AddForeignKey("dbo.CTTHIETBIS", "tinhtrang_id", "dbo.TINHTRANGS", "id", cascadeDelete: true);
            AddForeignKey("dbo.CTTHIETBIS", "thietbi_id", "dbo.THIETBIS", "id", cascadeDelete: true);
            AddForeignKey("dbo.PHONGS", "vitri_id", "dbo.VITRIS", "id", cascadeDelete: true);
            AddForeignKey("dbo.LOGTHIETBIS", "phong_id", "dbo.PHONGS", "id", cascadeDelete: true);
            AddForeignKey("dbo.CTTHIETBIS", "phong_id", "dbo.PHONGS", "id", cascadeDelete: true);
            AddForeignKey("dbo.TANGS", "day_id", "dbo.DAYS", "id", cascadeDelete: true);
            AddForeignKey("dbo.VITRIS", "coso_id", "dbo.COSOS", "id", cascadeDelete: true);
            AddForeignKey("dbo.DAYS", "coso_id", "dbo.COSOS", "id", cascadeDelete: true);
        }
    }
}

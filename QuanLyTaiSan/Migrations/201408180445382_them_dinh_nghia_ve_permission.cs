namespace QuanLyTaiSan.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class them_dinh_nghia_ve_permission : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PERMISSIONS", "can_delete", c => c.Boolean(nullable: false));
            AddColumn("dbo.PERMISSIONS", "can_add", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.PERMISSIONS", "can_add");
            DropColumn("dbo.PERMISSIONS", "can_delete");
        }
    }
}

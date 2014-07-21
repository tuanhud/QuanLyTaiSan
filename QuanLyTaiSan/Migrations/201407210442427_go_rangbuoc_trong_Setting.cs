namespace QuanLyTaiSan.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class go_rangbuoc_trong_Setting : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.SETTINGS", "value", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.SETTINGS", "value", c => c.String(nullable: false));
        }
    }
}

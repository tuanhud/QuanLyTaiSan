namespace QuanLyTaiSan.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class them_rangbuoc_day_thuoc_coso : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.DAYS", "coso_id", "dbo.COSOS");
            DropIndex("dbo.DAYS", new[] { "coso_id" });
            AlterColumn("dbo.DAYS", "coso_id", c => c.Int(nullable: false));
            CreateIndex("dbo.DAYS", "coso_id");
            AddForeignKey("dbo.DAYS", "coso_id", "dbo.COSOS", "id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.DAYS", "coso_id", "dbo.COSOS");
            DropIndex("dbo.DAYS", new[] { "coso_id" });
            AlterColumn("dbo.DAYS", "coso_id", c => c.Int());
            CreateIndex("dbo.DAYS", "coso_id");
            AddForeignKey("dbo.DAYS", "coso_id", "dbo.COSOS", "id");
        }
    }
}

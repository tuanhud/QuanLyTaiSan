namespace QuanLyTaiSan.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class choPhepLOGTB_Phong_null : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.LOGTHIETBIS", new[] { "phong_id" });
            AlterColumn("dbo.LOGTHIETBIS", "phong_id", c => c.Int());
            CreateIndex("dbo.LOGTHIETBIS", "phong_id");
        }
        
        public override void Down()
        {
            DropIndex("dbo.LOGTHIETBIS", new[] { "phong_id" });
            AlterColumn("dbo.LOGTHIETBIS", "phong_id", c => c.Int(nullable: false));
            CreateIndex("dbo.LOGTHIETBIS", "phong_id");
        }
    }
}

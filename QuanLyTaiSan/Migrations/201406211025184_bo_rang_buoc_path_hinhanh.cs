namespace QuanLyTaiSan.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class bo_rang_buoc_path_hinhanh : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.HINHANHS", new[] { "path" });
            AlterColumn("dbo.HINHANHS", "path", c => c.String(maxLength: 255));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.HINHANHS", "path", c => c.String(nullable: false, maxLength: 255));
            CreateIndex("dbo.HINHANHS", "path", unique: true);
        }
    }
}

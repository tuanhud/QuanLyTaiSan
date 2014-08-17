namespace QuanLyTaiSan.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class base2 : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.HINHANHS", "path", unique: true);
        }
        
        public override void Down()
        {
            DropIndex("dbo.HINHANHS", new[] { "path" });
        }
    }
}

namespace QuanLyTaiSan.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class them_rang_buoc_unique_choLOGTHIETBI : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.LOGTINHTRANGS", "nothing");
            CreateIndex("dbo.LOGTINHTRANGS", new[] { "ngay", "soluong" }, unique: true, name: "nothing");
        }
        
        public override void Down()
        {
            DropIndex("dbo.LOGTINHTRANGS", "nothing");
            CreateIndex("dbo.LOGTINHTRANGS", "ngay", unique: true, name: "nothing");
        }
    }
}

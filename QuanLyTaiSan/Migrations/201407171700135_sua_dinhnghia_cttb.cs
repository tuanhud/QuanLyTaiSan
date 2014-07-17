namespace QuanLyTaiSan.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class sua_dinhnghia_cttb : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.LOGTHIETBIS", "nothing");
            AddColumn("dbo.CTTHIETBIS", "ngay", c => c.DateTime());
            DropColumn("dbo.LOGTHIETBIS", "ngay");
        }
        
        public override void Down()
        {
            AddColumn("dbo.LOGTHIETBIS", "ngay", c => c.DateTime(nullable: false));
            DropColumn("dbo.CTTHIETBIS", "ngay");
            CreateIndex("dbo.LOGTHIETBIS", new[] { "ngay", "soluong" }, unique: true, name: "nothing");
        }
    }
}

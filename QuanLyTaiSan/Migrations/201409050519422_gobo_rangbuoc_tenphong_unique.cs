namespace QuanLyTaiSan.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class gobo_rangbuoc_tenphong_unique : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.PHONGS", "nothing");
            AlterColumn("dbo.PHONGS", "ten", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.PHONGS", "ten", c => c.String(nullable: false, maxLength: 255));
            CreateIndex("dbo.PHONGS", "ten", unique: true, name: "nothing");
        }
    }
}

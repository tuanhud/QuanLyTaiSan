namespace QuanLyTaiSan.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class chuyen_thuoctinh_ngay_LOGSUCO_SUCO_goboMotVaiIndex_K_canthiet : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.LOGSUCOPHONGS", "nothing");
            AddColumn("dbo.SUCOPHONGS", "ngay", c => c.DateTime(nullable: false));
            DropColumn("dbo.LOGSUCOPHONGS", "ngay");
        }
        
        public override void Down()
        {
            AddColumn("dbo.LOGSUCOPHONGS", "ngay", c => c.DateTime(nullable: false));
            DropColumn("dbo.SUCOPHONGS", "ngay");
            CreateIndex("dbo.LOGSUCOPHONGS", "ngay", unique: true, name: "nothing");
        }
    }
}

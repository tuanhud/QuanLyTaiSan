namespace TSCD.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class them_thuoctinh_cho_LogTaiSan : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.LOGTAISANS", "ngay", c => c.DateTime());
            AddColumn("dbo.LOGTAISANS", "cttaisan_parent_id", c => c.Guid());
            CreateIndex("dbo.LOGTAISANS", "cttaisan_parent_id");
            AddForeignKey("dbo.LOGTAISANS", "cttaisan_parent_id", "dbo.CTTAISANS", "id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.LOGTAISANS", "cttaisan_parent_id", "dbo.CTTAISANS");
            DropIndex("dbo.LOGTAISANS", new[] { "cttaisan_parent_id" });
            DropColumn("dbo.LOGTAISANS", "cttaisan_parent_id");
            DropColumn("dbo.LOGTAISANS", "ngay");
        }
    }
}

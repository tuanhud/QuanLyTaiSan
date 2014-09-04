namespace QuanLyTaiSan.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class QLTSCD_xoa_rangbuoc_ctts_logts_chuthe : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.TSCD_CTTAISAN", new[] { "chuthequanly_id" });
            DropIndex("dbo.TSCD_CTTAISAN", new[] { "chuthesudung_id" });
            DropIndex("dbo.TSCD_LOGTAISAN", new[] { "chuthequanly_id" });
            DropIndex("dbo.TSCD_LOGTAISAN", new[] { "chuthesudung_id" });
            AlterColumn("dbo.TSCD_CTTAISAN", "chuthequanly_id", c => c.Guid());
            AlterColumn("dbo.TSCD_CTTAISAN", "chuthesudung_id", c => c.Guid());
            AlterColumn("dbo.TSCD_LOGTAISAN", "chuthequanly_id", c => c.Guid());
            AlterColumn("dbo.TSCD_LOGTAISAN", "chuthesudung_id", c => c.Guid());
            CreateIndex("dbo.TSCD_CTTAISAN", "chuthequanly_id");
            CreateIndex("dbo.TSCD_CTTAISAN", "chuthesudung_id");
            CreateIndex("dbo.TSCD_LOGTAISAN", "chuthequanly_id");
            CreateIndex("dbo.TSCD_LOGTAISAN", "chuthesudung_id");
        }
        
        public override void Down()
        {
            DropIndex("dbo.TSCD_LOGTAISAN", new[] { "chuthesudung_id" });
            DropIndex("dbo.TSCD_LOGTAISAN", new[] { "chuthequanly_id" });
            DropIndex("dbo.TSCD_CTTAISAN", new[] { "chuthesudung_id" });
            DropIndex("dbo.TSCD_CTTAISAN", new[] { "chuthequanly_id" });
            AlterColumn("dbo.TSCD_LOGTAISAN", "chuthesudung_id", c => c.Guid(nullable: false));
            AlterColumn("dbo.TSCD_LOGTAISAN", "chuthequanly_id", c => c.Guid(nullable: false));
            AlterColumn("dbo.TSCD_CTTAISAN", "chuthesudung_id", c => c.Guid(nullable: false));
            AlterColumn("dbo.TSCD_CTTAISAN", "chuthequanly_id", c => c.Guid(nullable: false));
            CreateIndex("dbo.TSCD_LOGTAISAN", "chuthesudung_id");
            CreateIndex("dbo.TSCD_LOGTAISAN", "chuthequanly_id");
            CreateIndex("dbo.TSCD_CTTAISAN", "chuthesudung_id");
            CreateIndex("dbo.TSCD_CTTAISAN", "chuthequanly_id");
        }
    }
}

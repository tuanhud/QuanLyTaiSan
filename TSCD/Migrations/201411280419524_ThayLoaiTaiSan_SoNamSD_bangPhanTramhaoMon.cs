namespace TSCD.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ThayLoaiTaiSan_SoNamSD_bangPhanTramhaoMon : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.LOAITAISANS", "phantramhaomon_351", c => c.Double(nullable: false));
            AddColumn("dbo.LOAITAISANS", "phantramhaomon_32", c => c.Double(nullable: false));
            DropColumn("dbo.LOAITAISANS", "sonamsudung");
            DropColumn("dbo.LOAITAISANS", "sonamsudung_2");
            DropColumn("dbo.LOAITAISANS", "phantramhaomon");
            DropColumn("dbo.LOAITAISANS", "phantramhaomon_2");
        }
        
        public override void Down()
        {
            AddColumn("dbo.LOAITAISANS", "phantramhaomon_2", c => c.Int(nullable: false));
            AddColumn("dbo.LOAITAISANS", "phantramhaomon", c => c.Int(nullable: false));
            AddColumn("dbo.LOAITAISANS", "sonamsudung_2", c => c.Int(nullable: false));
            AddColumn("dbo.LOAITAISANS", "sonamsudung", c => c.Int(nullable: false));
            DropColumn("dbo.LOAITAISANS", "phantramhaomon_32");
            DropColumn("dbo.LOAITAISANS", "phantramhaomon_351");
        }
    }
}

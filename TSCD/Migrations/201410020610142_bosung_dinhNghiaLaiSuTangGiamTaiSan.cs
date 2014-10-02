namespace TSCD.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class bosung_dinhNghiaLaiSuTangGiamTaiSan : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.LOGTANGGIAMTAISANS", "nguongoc", c => c.String());
            AddColumn("dbo.LOGSUATAISANS", "nguongoc", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.LOGSUATAISANS", "nguongoc");
            DropColumn("dbo.LOGTANGGIAMTAISANS", "nguongoc");
        }
    }
}

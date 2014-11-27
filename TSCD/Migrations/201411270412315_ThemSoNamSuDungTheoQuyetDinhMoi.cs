namespace TSCD.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ThemSoNamSuDungTheoQuyetDinhMoi : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.LOAITAISANS", "sonamsudung_2", c => c.Int(nullable: false));
            AddColumn("dbo.LOAITAISANS", "phantramhaomon_2", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.LOAITAISANS", "phantramhaomon_2");
            DropColumn("dbo.LOAITAISANS", "sonamsudung_2");
        }
    }
}

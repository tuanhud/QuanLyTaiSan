namespace QuanLyTaiSan.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class them_diachi_cho_cs : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.COSOS", "diachi", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.COSOS", "diachi");
        }
    }
}

namespace QuanLyTaiSan.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatedatabase : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.COSOS", "order");
        }
        
        public override void Down()
        {
            AddColumn("dbo.COSOS", "order", c => c.Int());
        }
    }
}

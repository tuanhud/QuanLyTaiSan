namespace QuanLyTaiSan.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatedatabase : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.COSOS", "order", c => c.Int());
        }
        
        public override void Down()
        {
            DropColumn("dbo.COSOS", "order");
        }
    }
}

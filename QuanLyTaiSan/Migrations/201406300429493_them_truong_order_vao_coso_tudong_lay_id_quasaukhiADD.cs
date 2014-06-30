namespace QuanLyTaiSan.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class them_truong_order_vao_coso_tudong_lay_id_quasaukhiADD : DbMigration
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

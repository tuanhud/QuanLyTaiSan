namespace QuanLyTaiSan.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class them_hinhanhs_vao_cttbs_sucophong : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.HINHANHS", "ctthietbi_id", c => c.Int());
            AddColumn("dbo.HINHANHS", "sucophong_id", c => c.Int());
            CreateIndex("dbo.HINHANHS", "ctthietbi_id");
            CreateIndex("dbo.HINHANHS", "sucophong_id");
            AddForeignKey("dbo.HINHANHS", "ctthietbi_id", "dbo.CTTHIETBIS", "id");
            AddForeignKey("dbo.HINHANHS", "sucophong_id", "dbo.SUCOPHONGS", "id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.HINHANHS", "sucophong_id", "dbo.SUCOPHONGS");
            DropForeignKey("dbo.HINHANHS", "ctthietbi_id", "dbo.CTTHIETBIS");
            DropIndex("dbo.HINHANHS", new[] { "sucophong_id" });
            DropIndex("dbo.HINHANHS", new[] { "ctthietbi_id" });
            DropColumn("dbo.HINHANHS", "sucophong_id");
            DropColumn("dbo.HINHANHS", "ctthietbi_id");
        }
    }
}

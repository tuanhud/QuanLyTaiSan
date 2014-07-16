namespace QuanLyTaiSan.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class sua_moi_quanhe_SUCOPHONG_LOGSUCOPHONG : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.LOGSUCOPHONGS", "phong_id", "dbo.PHONGS");
            DropIndex("dbo.LOGSUCOPHONGS", "nothing");
            DropIndex("dbo.LOGSUCOPHONGS", new[] { "phong_id" });
            AddColumn("dbo.LOGSUCOPHONGS", "sucophong_id", c => c.Int(nullable: false));
            CreateIndex("dbo.LOGSUCOPHONGS", "ngay", unique: true, name: "nothing");
            CreateIndex("dbo.LOGSUCOPHONGS", "sucophong_id");
            AddForeignKey("dbo.LOGSUCOPHONGS", "sucophong_id", "dbo.SUCOPHONGS", "id");
            DropColumn("dbo.LOGSUCOPHONGS", "ten");
            DropColumn("dbo.LOGSUCOPHONGS", "phong_id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.LOGSUCOPHONGS", "phong_id", c => c.Int(nullable: false));
            AddColumn("dbo.LOGSUCOPHONGS", "ten", c => c.String(nullable: false, maxLength: 255));
            DropForeignKey("dbo.LOGSUCOPHONGS", "sucophong_id", "dbo.SUCOPHONGS");
            DropIndex("dbo.LOGSUCOPHONGS", new[] { "sucophong_id" });
            DropIndex("dbo.LOGSUCOPHONGS", "nothing");
            DropColumn("dbo.LOGSUCOPHONGS", "sucophong_id");
            CreateIndex("dbo.LOGSUCOPHONGS", "phong_id");
            CreateIndex("dbo.LOGSUCOPHONGS", new[] { "ten", "ngay" }, unique: true, name: "nothing");
            AddForeignKey("dbo.LOGSUCOPHONGS", "phong_id", "dbo.PHONGS", "id");
        }
    }
}

namespace QuanLyTaiSan.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CSDL_v2_them_entites_quan_ly_SUCOPHONG_ThaydoimotsorangbuocKhac_BIGCHANGES : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.LOGSUCOPHONGS",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        ten = c.String(nullable: false, maxLength: 255),
                        ngay = c.DateTime(nullable: false),
                        tinhtrang_id = c.Int(nullable: false),
                        phong_id = c.Int(nullable: false),
                        quantrivien_id = c.Int(),
                        subId = c.String(),
                        mota = c.String(),
                        date_create = c.DateTime(),
                        date_modified = c.DateTime(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.QUANTRIVIENS", t => t.quantrivien_id)
                .ForeignKey("dbo.PHONGS", t => t.phong_id)
                .ForeignKey("dbo.TINHTRANGS", t => t.tinhtrang_id)
                .Index(t => new { t.ten, t.ngay }, unique: true, name: "nothing")
                .Index(t => t.tinhtrang_id)
                .Index(t => t.phong_id)
                .Index(t => t.quantrivien_id);
            
            CreateTable(
                "dbo.SUCOPHONGS",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        ten = c.String(nullable: false, maxLength: 255),
                        tinhtrang_id = c.Int(nullable: false),
                        phong_id = c.Int(nullable: false),
                        subId = c.String(),
                        mota = c.String(),
                        date_create = c.DateTime(),
                        date_modified = c.DateTime(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.PHONGS", t => t.phong_id)
                .ForeignKey("dbo.TINHTRANGS", t => t.tinhtrang_id)
                .Index(t => t.ten, unique: true, name: "nothing")
                .Index(t => t.tinhtrang_id)
                .Index(t => t.phong_id);
            
            AddColumn("dbo.HINHANHS", "logsucophong_id", c => c.Int());
            AddColumn("dbo.HINHANHS", "logthietbi_id", c => c.Int());
            AddColumn("dbo.LOGTHIETBIS", "quantrivien_id", c => c.Int());
            AlterColumn("dbo.COSOS", "ten", c => c.String(nullable: false, maxLength: 255));
            AlterColumn("dbo.DAYS", "ten", c => c.String(nullable: false));
            AlterColumn("dbo.PHONGS", "ten", c => c.String(nullable: false, maxLength: 255));
            AlterColumn("dbo.THIETBIS", "ten", c => c.String(nullable: false));
            AlterColumn("dbo.LOAITHIETBIS", "ten", c => c.String(nullable: false, maxLength: 255));
            AlterColumn("dbo.TANGS", "ten", c => c.String(nullable: false));
            CreateIndex("dbo.COSOS", "ten", unique: true);
            CreateIndex("dbo.HINHANHS", "logsucophong_id");
            CreateIndex("dbo.HINHANHS", "logthietbi_id");
            CreateIndex("dbo.PHONGS", "ten", unique: true, name: "nothing");
            CreateIndex("dbo.LOAITHIETBIS", "ten", unique: true);
            CreateIndex("dbo.LOGTHIETBIS", "quantrivien_id");
            AddForeignKey("dbo.HINHANHS", "logsucophong_id", "dbo.LOGSUCOPHONGS", "id");
            AddForeignKey("dbo.HINHANHS", "logthietbi_id", "dbo.LOGTHIETBIS", "id");
            AddForeignKey("dbo.LOGTHIETBIS", "quantrivien_id", "dbo.QUANTRIVIENS", "id");
            DropColumn("dbo.LOGHETHONGS", "ngay");
        }
        
        public override void Down()
        {
            AddColumn("dbo.LOGHETHONGS", "ngay", c => c.DateTime(nullable: false));
            DropForeignKey("dbo.LOGSUCOPHONGS", "tinhtrang_id", "dbo.TINHTRANGS");
            DropForeignKey("dbo.LOGSUCOPHONGS", "phong_id", "dbo.PHONGS");
            DropForeignKey("dbo.SUCOPHONGS", "tinhtrang_id", "dbo.TINHTRANGS");
            DropForeignKey("dbo.SUCOPHONGS", "phong_id", "dbo.PHONGS");
            DropForeignKey("dbo.LOGTHIETBIS", "quantrivien_id", "dbo.QUANTRIVIENS");
            DropForeignKey("dbo.LOGSUCOPHONGS", "quantrivien_id", "dbo.QUANTRIVIENS");
            DropForeignKey("dbo.HINHANHS", "logthietbi_id", "dbo.LOGTHIETBIS");
            DropForeignKey("dbo.HINHANHS", "logsucophong_id", "dbo.LOGSUCOPHONGS");
            DropIndex("dbo.SUCOPHONGS", new[] { "phong_id" });
            DropIndex("dbo.SUCOPHONGS", new[] { "tinhtrang_id" });
            DropIndex("dbo.SUCOPHONGS", "nothing");
            DropIndex("dbo.LOGTHIETBIS", new[] { "quantrivien_id" });
            DropIndex("dbo.LOAITHIETBIS", new[] { "ten" });
            DropIndex("dbo.PHONGS", "nothing");
            DropIndex("dbo.LOGSUCOPHONGS", new[] { "quantrivien_id" });
            DropIndex("dbo.LOGSUCOPHONGS", new[] { "phong_id" });
            DropIndex("dbo.LOGSUCOPHONGS", new[] { "tinhtrang_id" });
            DropIndex("dbo.LOGSUCOPHONGS", "nothing");
            DropIndex("dbo.HINHANHS", new[] { "logthietbi_id" });
            DropIndex("dbo.HINHANHS", new[] { "logsucophong_id" });
            DropIndex("dbo.COSOS", new[] { "ten" });
            AlterColumn("dbo.TANGS", "ten", c => c.String());
            AlterColumn("dbo.LOAITHIETBIS", "ten", c => c.String(nullable: false));
            AlterColumn("dbo.THIETBIS", "ten", c => c.String());
            AlterColumn("dbo.PHONGS", "ten", c => c.String());
            AlterColumn("dbo.DAYS", "ten", c => c.String());
            AlterColumn("dbo.COSOS", "ten", c => c.String());
            DropColumn("dbo.LOGTHIETBIS", "quantrivien_id");
            DropColumn("dbo.HINHANHS", "logthietbi_id");
            DropColumn("dbo.HINHANHS", "logsucophong_id");
            DropTable("dbo.SUCOPHONGS");
            DropTable("dbo.LOGSUCOPHONGS");
        }
    }
}

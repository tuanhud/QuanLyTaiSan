namespace TSCD.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class tachChungTuRaEntity_themAttachment : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CHUNGTUS",
                c => new
                    {
                        id = c.Guid(nullable: false, identity: true),
                        sohieu = c.String(),
                        ngay = c.DateTime(),
                        subId = c.String(),
                        order = c.Long(),
                        mota = c.String(),
                        date_create = c.DateTime(),
                        date_modified = c.DateTime(),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.ATTACHMENTS",
                c => new
                    {
                        id = c.Guid(nullable: false, identity: true),
                        path = c.String(),
                        size = c.Int(nullable: false),
                        subId = c.String(),
                        order = c.Long(),
                        mota = c.String(),
                        date_create = c.DateTime(),
                        date_modified = c.DateTime(),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.CHUNGTU_ATTACHMENT",
                c => new
                    {
                        id1 = c.Guid(nullable: false),
                        id2 = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => new { t.id1, t.id2 })
                .ForeignKey("dbo.CHUNGTUS", t => t.id1, cascadeDelete: true)
                .ForeignKey("dbo.ATTACHMENTS", t => t.id2, cascadeDelete: true)
                .Index(t => t.id1)
                .Index(t => t.id2);
            
            AddColumn("dbo.CTTAISANS", "chungtu_id", c => c.Guid());
            AddColumn("dbo.LOGTANGGIAMTAISANS", "chungtu_id", c => c.Guid());
            AddColumn("dbo.LOGSUATAISANS", "chungtu_id", c => c.Guid());
            CreateIndex("dbo.CTTAISANS", "chungtu_id");
            CreateIndex("dbo.LOGTANGGIAMTAISANS", "chungtu_id");
            CreateIndex("dbo.LOGSUATAISANS", "chungtu_id");
            AddForeignKey("dbo.CTTAISANS", "chungtu_id", "dbo.CHUNGTUS", "id");
            AddForeignKey("dbo.LOGTANGGIAMTAISANS", "chungtu_id", "dbo.CHUNGTUS", "id");
            AddForeignKey("dbo.LOGSUATAISANS", "chungtu_id", "dbo.CHUNGTUS", "id");
            DropColumn("dbo.CTTAISANS", "chungtu_sohieu");
            DropColumn("dbo.CTTAISANS", "chungtu_ngay");
            DropColumn("dbo.LOGTANGGIAMTAISANS", "chungtu_sohieu");
            DropColumn("dbo.LOGTANGGIAMTAISANS", "chungtu_ngay");
            DropColumn("dbo.LOGSUATAISANS", "chungtu_sohieu");
            DropColumn("dbo.LOGSUATAISANS", "chungtu_ngay");
        }
        
        public override void Down()
        {
            AddColumn("dbo.LOGSUATAISANS", "chungtu_ngay", c => c.DateTime());
            AddColumn("dbo.LOGSUATAISANS", "chungtu_sohieu", c => c.String());
            AddColumn("dbo.LOGTANGGIAMTAISANS", "chungtu_ngay", c => c.DateTime());
            AddColumn("dbo.LOGTANGGIAMTAISANS", "chungtu_sohieu", c => c.String());
            AddColumn("dbo.CTTAISANS", "chungtu_ngay", c => c.DateTime());
            AddColumn("dbo.CTTAISANS", "chungtu_sohieu", c => c.String());
            DropForeignKey("dbo.LOGSUATAISANS", "chungtu_id", "dbo.CHUNGTUS");
            DropForeignKey("dbo.LOGTANGGIAMTAISANS", "chungtu_id", "dbo.CHUNGTUS");
            DropForeignKey("dbo.CTTAISANS", "chungtu_id", "dbo.CHUNGTUS");
            DropForeignKey("dbo.CHUNGTU_ATTACHMENT", "id2", "dbo.ATTACHMENTS");
            DropForeignKey("dbo.CHUNGTU_ATTACHMENT", "id1", "dbo.CHUNGTUS");
            DropIndex("dbo.CHUNGTU_ATTACHMENT", new[] { "id2" });
            DropIndex("dbo.CHUNGTU_ATTACHMENT", new[] { "id1" });
            DropIndex("dbo.LOGSUATAISANS", new[] { "chungtu_id" });
            DropIndex("dbo.LOGTANGGIAMTAISANS", new[] { "chungtu_id" });
            DropIndex("dbo.CTTAISANS", new[] { "chungtu_id" });
            DropColumn("dbo.LOGSUATAISANS", "chungtu_id");
            DropColumn("dbo.LOGTANGGIAMTAISANS", "chungtu_id");
            DropColumn("dbo.CTTAISANS", "chungtu_id");
            DropTable("dbo.CHUNGTU_ATTACHMENT");
            DropTable("dbo.ATTACHMENTS");
            DropTable("dbo.CHUNGTUS");
        }
    }
}

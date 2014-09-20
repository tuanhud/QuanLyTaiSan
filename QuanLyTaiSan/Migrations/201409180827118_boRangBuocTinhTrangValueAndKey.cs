namespace PTB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class boRangBuocTinhTrangValueAndKey : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.TINHTRANGS", new[] { "key" });
            DropIndex("dbo.TINHTRANGS", new[] { "value" });
            AlterColumn("dbo.QUANTRIVIENS", "hoten", c => c.String());
            AlterColumn("dbo.TINHTRANGS", "key", c => c.String(maxLength: 255));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.TINHTRANGS", "key", c => c.String(maxLength: 100));
            AlterColumn("dbo.QUANTRIVIENS", "hoten", c => c.String(nullable: false));
            CreateIndex("dbo.TINHTRANGS", "value", unique: true);
            CreateIndex("dbo.TINHTRANGS", "key", unique: true);
        }
    }
}

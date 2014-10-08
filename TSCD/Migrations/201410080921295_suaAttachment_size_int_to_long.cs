namespace TSCD.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class suaAttachment_size_int_to_long : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.ATTACHMENTS", "size", c => c.Long(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.ATTACHMENTS", "size", c => c.Int(nullable: false));
        }
    }
}

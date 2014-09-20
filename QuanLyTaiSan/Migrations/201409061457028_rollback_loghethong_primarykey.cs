namespace PTB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class rollback_loghethong_primarykey : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.LOGHETHONGS");
            AddColumn("dbo.LOGHETHONGS", "id", c => c.Guid(nullable: false, identity: true));
            AddColumn("dbo.LOGHETHONGS", "subId", c => c.String());
            AddColumn("dbo.LOGHETHONGS", "order", c => c.Long());
            AddColumn("dbo.LOGHETHONGS", "date_modified", c => c.DateTime());
            AlterColumn("dbo.LOGHETHONGS", "mota", c => c.String());
            AlterColumn("dbo.LOGHETHONGS", "date_create", c => c.DateTime());
            AddPrimaryKey("dbo.LOGHETHONGS", "id");
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.LOGHETHONGS");
            AlterColumn("dbo.LOGHETHONGS", "date_create", c => c.DateTime(nullable: false));
            AlterColumn("dbo.LOGHETHONGS", "mota", c => c.String(nullable: false, maxLength: 128));
            DropColumn("dbo.LOGHETHONGS", "date_modified");
            DropColumn("dbo.LOGHETHONGS", "order");
            DropColumn("dbo.LOGHETHONGS", "subId");
            DropColumn("dbo.LOGHETHONGS", "id");
            AddPrimaryKey("dbo.LOGHETHONGS", new[] { "mota", "date_create" });
        }
    }
}

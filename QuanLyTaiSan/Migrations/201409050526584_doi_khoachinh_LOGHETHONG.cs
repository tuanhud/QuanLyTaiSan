namespace PTB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class doi_khoachinh_LOGHETHONG : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.LOGHETHONGS");
            AlterColumn("dbo.LOGHETHONGS", "mota", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.LOGHETHONGS", "date_create", c => c.DateTime(nullable: false));
            AddPrimaryKey("dbo.LOGHETHONGS", new[] { "mota", "date_create" });
            DropColumn("dbo.LOGHETHONGS", "id");
            DropColumn("dbo.LOGHETHONGS", "subId");
            DropColumn("dbo.LOGHETHONGS", "order");
            DropColumn("dbo.LOGHETHONGS", "date_modified");
        }
        
        public override void Down()
        {
            AddColumn("dbo.LOGHETHONGS", "date_modified", c => c.DateTime());
            AddColumn("dbo.LOGHETHONGS", "order", c => c.Long());
            AddColumn("dbo.LOGHETHONGS", "subId", c => c.String());
            AddColumn("dbo.LOGHETHONGS", "id", c => c.Guid(nullable: false, identity: true));
            DropPrimaryKey("dbo.LOGHETHONGS");
            AlterColumn("dbo.LOGHETHONGS", "date_create", c => c.DateTime());
            AlterColumn("dbo.LOGHETHONGS", "mota", c => c.String());
            AddPrimaryKey("dbo.LOGHETHONGS", "id");
        }
    }
}

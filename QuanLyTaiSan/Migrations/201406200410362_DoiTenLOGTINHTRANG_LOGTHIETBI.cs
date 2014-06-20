namespace QuanLyTaiSan.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DoiTenLOGTINHTRANG_LOGTHIETBI : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.LOGTINHTRANGS", newName: "LOGTHIETBIS");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.LOGTHIETBIS", newName: "LOGTINHTRANGS");
        }
    }
}

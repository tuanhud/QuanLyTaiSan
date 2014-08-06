namespace QuanLyTaiSan.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class chinh_sua_su_co_phong : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.SUCOPHONGS", "nothing");
        }
        
        public override void Down()
        {
            CreateIndex("dbo.SUCOPHONGS", "ten", unique: true, name: "nothing");
        }
    }
}

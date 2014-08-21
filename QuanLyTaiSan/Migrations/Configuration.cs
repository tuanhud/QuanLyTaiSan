namespace QuanLyTaiSan.Migrations
{
    using QuanLyTaiSan.Entities;
    using QuanLyTaiSan.Libraries;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<QuanLyTaiSan.Entities.OurDBContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(OurDBContext context)
        {
            
        }
    }
}

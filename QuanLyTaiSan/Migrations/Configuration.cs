namespace PTB.Migrations
{
    using PTB.Entities;
    using PTB.Libraries;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<PTB.Entities.OurDBContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(OurDBContext context)
        {
            base.Seed(context);
        }
    }
}

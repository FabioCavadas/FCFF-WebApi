namespace FCFFInfra.Data.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<FCFFInfra.Data.Context.DataContext>
    {
        /// <summary>
        /// AutomaticMigrationsEnabled = true -> Permitir Create, Alter
        /// AutomaticMigrationDataLossAllowed = true -> Permitir DROP
        /// </summary>
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;

            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(FCFFInfra.Data.Context.DataContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
        }
    }
}

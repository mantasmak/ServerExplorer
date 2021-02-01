namespace ServerExplorer.Infrastructure.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<ServerExplorer.Infrastructure.Persistence.ServerExplorerContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "ServerExplorer.Infrastructure.Persistence.ServerExplorerContext";
        }

        protected override void Seed(ServerExplorer.Infrastructure.Persistence.ServerExplorerContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.
        }
    }
}

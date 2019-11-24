using System;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
namespace Gerobra.Migrations
{
    public class Configuration : DbMigrationsConfiguration<Gerobra.Models.GerobraContext> 
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
            ContextKey = "Gerobra.Models.GerobraContext";
        }
    }
    
}
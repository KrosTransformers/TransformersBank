using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Transformers.Bank.Data.Context
{
    public static class Upgrader
    {
        public static void AutoUpgrade()
        {
            Database.SetInitializer<DataWorker>(new MigrateDatabaseToLatestVersion<DataWorker, Migrations.Configuration>());
            var migrator = new DbMigrator(new Migrations.Configuration());
            migrator.Update();
        }
    }
}

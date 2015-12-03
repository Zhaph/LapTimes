using System.Data.Entity.Migrations;
using System.Diagnostics;
using LapTimes.Migrations;

namespace LapTimes
{
    /// <summary>
    /// Configures the database on application start-up
    /// </summary>
    public static class DatabaseConfig
    {
        /// <summary>
        /// Runs the database migrations on the database.
        /// </summary>
        [Conditional("DEBUG")]
        public static void SetupDatabase()
        {
            var migrator = new DbMigrator(new Configuration());
            migrator.Update();
        }
    }
}

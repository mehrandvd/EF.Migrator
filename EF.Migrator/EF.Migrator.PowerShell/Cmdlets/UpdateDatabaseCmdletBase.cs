using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Text;
using System.Threading.Tasks;

namespace EntityFramework.Migrator.PowerShell.Cmdlets
{
    [Cmdlet(VerbsData.Update, "EfmDatabase", SupportsShouldProcess = true)]
    public class UpdateDatabaseCmdletBase : EfmCmdletBase
    {
        protected override void ProcessRecord()
        {
            base.ProcessRecord();

            var migrators = GetMigrators();

            foreach (var dbMigrator in migrators)
            {
                WriteVerbose("Pending migrations: ");
                foreach (var pendingMigration in dbMigrator.GetPendingMigrations())
                {
                    WriteVerbose(string.Format("\t-[{0}]", pendingMigration));
                }

                if (ShouldProcess("Applying migration on the target database."))
                    dbMigrator.Update();
            }
        }
    }
}

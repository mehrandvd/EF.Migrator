using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Text;
using System.Threading.Tasks;

namespace EF.Migrator.PowerShell.Cmdlets
{
    [Cmdlet(VerbsData.Update, "EfmDatabase")]
    public class UpdateDatabaseCmdlet : EfmCmdlet
    {
        protected override void ProcessRecord()
        {
            base.ProcessRecord();

            var migrators = GetMigrators();

            foreach (var dbMigrator in migrators)
            {
                dbMigrator.Update();
            }
        }
    }
}

using System.Management.Automation;

namespace EntityFramework.Migrator.PowerShell.Cmdlets
{
    [Cmdlet(VerbsCommon.Get, "EfmPendingMigrations")]
    public class GetPendingMigrationsCmdletBase : EfmCmdletBase
    {
        protected override void ProcessRecord()
        {
            base.ProcessRecord();

            var migrators = GetMigrators();

            WriteObject(migrators, true);
        }
    }
}
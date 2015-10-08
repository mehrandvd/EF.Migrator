using System.Management.Automation;

namespace EF.Migrator.PowerShell.Cmdlets
{
    [Cmdlet(VerbsCommon.Get, "EfmPendingMigrations")]
    public class GetPendingMigrationsCmdlet : EfmCmdlet
    {
        protected override void ProcessRecord()
        {
            base.ProcessRecord();

            var migrators = GetMigrators();

            WriteObject(migrators, true);
        }
    }
}
using System;
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

            foreach (var migrator in migrators)
            {
                WriteVerbose(string.Format("DbContext: {0}", migrator.Configuration.ContextKey));
                
                foreach (var pendingChange in migrator.GetPendingMigrations())
                {
                    if (ShouldProcess(string.Format("Executing: [{0}]", pendingChange)))
                    {
                        try
                        {
                            migrator.Update(pendingChange);
                            WriteVerbose(string.Format("\tDone."));
                        }
                        catch (Exception exception)
                        {
                            WriteError(new ErrorRecord(exception, "UnableToUpdate", ErrorCategory.OperationStopped, pendingChange));
                        }
                    }
                }
            }
        }
    }
}
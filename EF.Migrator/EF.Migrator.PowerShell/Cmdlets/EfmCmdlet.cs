using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Management.Automation;
using System.Reflection;

namespace EF.Migrator.PowerShell.Cmdlets
{
    public class EfmCmdlet : PSCmdlet
    {
        [Parameter(Mandatory = true)]
        string[] AssemblyNames { get; set; }

        protected List<DbMigrator> GetMigrators()
        {
            var assemblies = new List<Assembly>();
            var configTypes = new List<Type>();

            foreach (var assemblyName in AssemblyNames)
            {
                var assembly = Assembly.Load(assemblyName);

                if (assembly == null)
                {
                    throw new Exception("Unable to load assembly exception");
                }

                configTypes.AddRange(
                    assembly.GetTypes().Where(t => t.IsSubclassOf(typeof (DbMigrationsConfiguration)) && !t.IsAbstract).ToList());
            }

            var migrators = new List<DbMigrator>();

            foreach (var configType in configTypes)
            {
                var migrator = new DbMigrator((DbMigrationsConfiguration) Activator.CreateInstance(configType));
                migrators.Add(migrator);
            }
            return migrators;
        }
    }
}
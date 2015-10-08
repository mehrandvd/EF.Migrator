using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace EF.Migrator
{
    public class MigratorTool
    {
        public List<Assembly> Assemblies { get; set; }
        public DbConnectionInfo TargetDatabase { get; set; }


    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager.Data
{
    public static class Configuration
    {
        public static string ConnectionString = @"Server=PINUSE-PC\MSSQLSERVER01;Database=TaskManager;Integrated Security=True;Trust Server Certificate=true";
    }
}

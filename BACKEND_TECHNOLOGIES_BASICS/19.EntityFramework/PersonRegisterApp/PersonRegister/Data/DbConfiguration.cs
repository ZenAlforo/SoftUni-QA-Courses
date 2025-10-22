using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonRegister.Data
{
    public class DbConfiguration
    {
        public const string ConnectionString = "Server=(localdb)\\MSSQLLocalDB;Database=PersonRegister;Trusted_Connection=True;MultipleActiveResultSets=true";
    }
}
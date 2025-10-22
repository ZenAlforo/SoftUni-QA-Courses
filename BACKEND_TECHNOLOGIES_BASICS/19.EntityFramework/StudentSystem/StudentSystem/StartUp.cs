using StudentSystem.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentSystem
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            using var context = new StudentDbContext();
            context.Database.EnsureCreated();
        }
    }
}

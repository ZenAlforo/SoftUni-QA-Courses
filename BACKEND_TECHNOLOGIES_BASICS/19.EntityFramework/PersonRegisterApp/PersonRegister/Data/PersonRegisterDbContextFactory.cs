using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonRegister.Data
{
    public class PersonRegisterDbContextFactory : IDesignTimeDbContextFactory<PersonRegisterDbContext>
    {
        public PersonRegisterDbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<PersonRegisterDbContext>();
            var connectionString = DbConfiguration.ConnectionString;

            builder.UseSqlServer(connectionString);

            return new PersonRegisterDbContext(builder.Options);
        }
    }
}

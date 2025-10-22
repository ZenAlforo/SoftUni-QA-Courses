using Microsoft.EntityFrameworkCore;
using PersonRegister.Data;
using PersonRegister.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonRegister
{
    public class StartUp
    {
        static async Task Main(string[] args)
        {
            var contextFactory = new PersonRegisterDbContextFactory();
            var dbContext = contextFactory.CreateDbContext(args);

            await dbContext.Database.MigrateAsync();

            var jobData = new JobInfo
            {
                JobTitle = "Designer",
                JobDescription = "Creating new cars model vision",
                MonthlySalary = 13000.00,
                Persons = new List<Person> { }
            };

            await dbContext.SaveChangesAsync();

            var person = new Person
            {
                FirstName = "Martin",
                LastName = "Pankov",
                Age = 39,
                City = "Sofia",
                JobId = jobData.JobId
               
            };

            dbContext.Person.Add(person);
            dbContext.JobInfo.Add(jobData);

            await dbContext.SaveChangesAsync();

            //var person = dbContext.Person.Where(per => per.LastName == "Pankov").ToList();

            //var personByNameList = dbContext.Person.OrderBy(p => p.FirstName).ToList();

            //var person1 = dbContext.Person.Find(2);

            //var personByAge = dbContext.Person.FirstOrDefault(a => a.Age == 20);

            //var findPerson = dbContext.Person.Any(p => p.LastName == "Georgiev");

            //var lastPerson = dbContext.Person.OrderByDescending(p=>p.City).Last();


        }
    }
}

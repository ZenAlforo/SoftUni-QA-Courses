using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonRegister.Data.Models
{
    public class JobInfo
    {
        [Key]
        public int JobId { get; set; }
        public string JobTitle {  get; set; }  
        public string JobDescription { get; set; }
        public double MonthlySalary { get; set; }

        public ICollection<Person> Persons { get; set; } = new List<Person>();
    }
}

using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentSystem.Data.Models
{
    public class Course
    {
        public int CourseId { get; set; }

        [MaxLength(80)]
        [Unicode(true)]
        public string Name { get; set; }

        [Unicode(true)]
        public string? Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public double Price { get; set; }

        public ICollection<StudentCourse> StudentCourses { get; set; } = new HashSet<StudentCourse>();
        public ICollection<Resource> Resources { get; set; } = new HashSet<Resource>();
        public ICollection<Homework> Homeworks { get; set; } = new HashSet<Homework>();

    }
}

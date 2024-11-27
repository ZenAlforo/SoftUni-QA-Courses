namespace ObjectsAndClasses_Exe
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Student> students = new() { };

            int studentsCount = int.Parse(Console.ReadLine());

            for (int i = 0; i < studentsCount; i++)
            {
                string[] studentData = Console.ReadLine().Split();
                string firstName = studentData[0];
                string lastName = studentData[1];
                double grade = double.Parse(studentData[2]);

                Student currentStudent = new Student(firstName, lastName, grade);
                students.Add(currentStudent);
            }

            foreach (Student student in students.OrderByDescending(student => student.Grade))
            {
                Console.WriteLine($"{student.FirstName} {student.LastName}: {student.Grade:F2}");
            }

        }

        class Student
        {
            public Student(string firstName, string lastName, double grade)
            {
                FirstName = firstName;
                LastName = lastName;
                Grade = grade;
            }

            public string FirstName { get; set; }
            public string LastName { get; set; }
            public double Grade { get; set; }
        }
    }
}

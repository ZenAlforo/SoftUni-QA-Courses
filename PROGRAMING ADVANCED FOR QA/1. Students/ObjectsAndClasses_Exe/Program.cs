using _1._Students;

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
    }
}

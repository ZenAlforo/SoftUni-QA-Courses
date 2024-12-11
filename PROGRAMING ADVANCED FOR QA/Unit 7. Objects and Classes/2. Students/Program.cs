namespace _2._Students
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Student> studentsList = new List<Student>();

            string input = Console.ReadLine();

            while (input != "end")
            {
                string[] studentsData = input.Split().ToArray();
                string firstName = studentsData[0];
                string lastName = studentsData[1];
                int age = int.Parse(studentsData[2]);
                string homeTown = studentsData[3];

                Student studentDetails = new Student(firstName, lastName, age, homeTown);
                studentsList.Add(studentDetails);
                input = Console.ReadLine();
            }

            string homeTownFilter = Console.ReadLine();

            foreach (Student student in studentsList.Where(student => student.HomeTown == homeTownFilter))
            {
                Console.WriteLine($"{student.GivenName} {student.FamilyName} is {student.Age} years old.");
            }

        }

        class Student
        {
            public Student(string givenName, string familyName, int age, string homeTown)
            {
                GivenName = givenName;
                FamilyName = familyName;
                Age = age;
                HomeTown = homeTown;
            }

            public string GivenName { get; set; }
            public string FamilyName { get; set; }
            public int Age { get; set; }
            public string HomeTown { get; set; }
        }
    }
}

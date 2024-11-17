namespace _5._Students_Academy
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numberOfStudents = int.Parse(Console.ReadLine());

            Dictionary<string, List<double>> studentsData = new Dictionary<string, List<double>>();

            for (int i = 1; i <= numberOfStudents; i++)
            {
                string student = Console.ReadLine();
                double grade = double.Parse(Console.ReadLine());

                if (!studentsData.ContainsKey(student))
                {
                    studentsData.Add(student, new List<double>() { grade });
                }
                else
                {
                    studentsData[student].Add(grade);
                }
            }

            foreach (KeyValuePair<string, List<double>> kvp in studentsData)
            {
                string studentsName = kvp.Key;
                double avgGrade = kvp.Value.Average();

                if (avgGrade >= 4.5)
                {
                    Console.WriteLine($"{studentsName} -> {avgGrade:F2}");
                }
            }
        }
    }
}

using System.Runtime.InteropServices;

namespace _6._Company_Users
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            Dictionary<string, List<string>> employees = new Dictionary<string, List<string>>();

            while (input != "End")
            {
                string[] employeeData = input.Split(" -> ").ToArray();

                string companyName = employeeData[0];
                string employeeId = employeeData[1];

                if (employees.ContainsKey(companyName) ) 
                {
                    if (!employees[companyName].Contains(employeeId)) {
                        employees[companyName].Add(employeeId);
                    }
                } else
                {
                    employees.Add(companyName, new List<string>() {employeeId});
                }


                input = Console.ReadLine();
            }

            foreach (string companyName in employees.Keys)
            {
                Console.WriteLine(companyName);
                foreach (string value in employees[companyName])
                {
                    Console.WriteLine($"-- {value}");
                }
            }
        }
    }
}

namespace _7._Greater_of_Two_Values
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string type = Console.ReadLine();
            FindTheGreaterOfTwoValues(type);

            static void FindTheGreaterOfTwoValues(string type)
            {

                if (type == "int")
                {
                    int firstNumber = int.Parse(Console.ReadLine());
                    int secondNumber = int.Parse(Console.ReadLine());

                    Console.WriteLine(Math.Max(firstNumber, secondNumber));
                } 
                else if (type == "char")
                {
                    char firstChar = char.Parse(Console.ReadLine());
                    char secondChar = char.Parse(Console.ReadLine());

                    Console.WriteLine((char)Math.Max((int)firstChar, (int)secondChar));
                }
                else if (type == "string")
                {
                    string firstString = Console.ReadLine();
                    string secondString = Console.ReadLine();

                    int result = string.Compare(firstString, secondString);
                    string biggest = result < 0 ? secondString : firstString;

                    Console.WriteLine(biggest);
                }

            }
        }
    }
}

namespace _5._Invalid_Number
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());
            if (num == 0 || num >= 100 && num <= 200)
            {
                
            }
            else
            {
                Console.WriteLine("invalid");
            }

            // other way to do it
            bool isValid = (num >= 100 && num <= 200) || num == 0;

            if (isValid == false)
            {
                Console.WriteLine("invalid");

            }
        }
    }
}

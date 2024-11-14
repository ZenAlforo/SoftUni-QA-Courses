namespace _4._Password_Manager
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string password = Console.ReadLine();


            if (passwordLengthCheck(password) && passwordCharsCheck(password) && passwordDigitNumberCheck(password))
            {
                Console.WriteLine("Password is valid");
            }

            if (!passwordLengthCheck(password))
            {
                Console.WriteLine("Password must be between 6 and 10 characters");
            }
            if (!passwordCharsCheck(password))
            {
                Console.WriteLine("Password must consist only of letters and digits");
            }
            if (!passwordDigitNumberCheck(password))
            {
                Console.WriteLine("Password must have at least 2 digits");
            }

            static bool passwordLengthCheck(string pass)
            {
                bool isValid = false;

                if (pass.Length >=6 && pass.Length <= 10)
                {
                    isValid = true;
                }

                return isValid;
            }

            static bool passwordCharsCheck(string pass)
            {
                bool isValid = true;

                for (int index = 0; index < pass.Length; index++)
                {

                    if (!Char.IsLetterOrDigit(pass[index]))
                    {
                        isValid = false;
                        break;
                    }
                }

                return isValid;
            }

            static bool passwordDigitNumberCheck(string pass)
            {
                bool isValid = false;
                int digitCounter = 0;

                for (int index = 0; index < pass.Length; index++)
                {

                    if (Char.IsDigit(pass[index]))
                    {
                        digitCounter++;
                    }

                    if (digitCounter == 2)
                    {
                        isValid = true;
                        break;
                    }
                }

                return isValid;
            }
        }
    }
}

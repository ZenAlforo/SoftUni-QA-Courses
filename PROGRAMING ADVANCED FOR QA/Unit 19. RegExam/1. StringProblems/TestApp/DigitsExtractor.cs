using System;
using System.Text;

namespace TestApp;

public class DigitsExtractor
{
    public static string FindDigits(string input)
    {
        string digits = "";

        foreach (char c in input)
        {
            if (char.IsDigit(c))
            {
                digits += c;
            }
        }

        return digits.Length > 0 ? digits : "No digits!";
    }
}

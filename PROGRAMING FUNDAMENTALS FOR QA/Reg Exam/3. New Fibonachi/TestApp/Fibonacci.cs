
using System.Text;

namespace TestApp;

public class Fibonacci
{
    public static string FibonacciInRange(int start, int end)
    {
        if (start > end)
        {
            return "Start number should be less than end number.";
        }

        string fibonacciNumbers = GetFibonacciSequence(start, end);

        return fibonacciNumbers;
    }

    private static string GetFibonacciSequence(int start, int end)
    {
        StringBuilder sb = new StringBuilder();
        int a = 0, b = 1;


        while (a <= end)
        {
            if (a >= start)
                sb.Append(a + " ");

            int next = a + b;
            a = b;
            b = next;
        }

        return sb.ToString().TrimEnd();
    }
}


using System;
using System.Collections.Generic;

namespace TestApp;

public class DigitAndSymbolCounter
{
    public static Dictionary<string, int> CountDigitsAndSymbols(string input)
    {
        Dictionary<string, int> counts = new Dictionary<string, int>
        {
            { "even digit", 0 },
            { "odd digit", 0 },
            { "non-digit symbol", 0 }
        };

        foreach (char c in input)
        {
            if (char.IsDigit(c))
            {
                if ((c - '0') % 2 == 0)
                {
                    counts["even digit"]++;
                }
                else
                {
                    counts["odd digit"]++;
                }
            }
            else
            {
                counts["non-digit symbol"]++;
            }
        }

        if (counts["even digit"] == 0) counts.Remove("even digit");
        if (counts["odd digit"] == 0) counts.Remove("odd digit");
        if (counts["non-digit symbol"] == 0) counts.Remove("non-digit symbol");

        return counts;
    }
}

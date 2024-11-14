namespace TestApp;

public class LongestStringFinder
{
    public static string GetLongestString(List<string> strings)
    {
        if (strings == null || strings.Count == 0)
            return string.Empty;

        string longestString = strings[0];

        foreach (string str in strings)
        {
            if (str.Length > longestString.Length)
            {
                longestString = str;
            }
        }

        return longestString;
    }
}

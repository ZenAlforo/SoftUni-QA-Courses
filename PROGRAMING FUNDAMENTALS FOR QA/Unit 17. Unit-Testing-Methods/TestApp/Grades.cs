namespace TestApp;

public class Grades
{
    public static string GradeAsWords(double grade)
    {
        switch (grade)
        {
            case >= 2.00 and < 3.00:
                return "Fail";
            case >= 3.00 and < 3.5:
                return "Average";
            case >= 3.5 and < 4.5:
                return "Good";
            case >= 4.5 and < 5.5:
                return "Very Good";
            case >= 5.5 and <= 6:
                return "Excellent";
            default:
                return "Invalid!";
        }
    }
}

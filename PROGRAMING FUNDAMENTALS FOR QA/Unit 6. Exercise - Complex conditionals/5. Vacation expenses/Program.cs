namespace _5._Vacation_expenses
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string season = Console.ReadLine();
            string accommodation = Console.ReadLine();
            int stay = int.Parse(Console.ReadLine());

            int springHotelPrice = 30;
            int springCampingPrice = 10;
            double springDiscount = 0.2;

            int summerHotelPrice = 50;
            int summerCampingPrice = 30;
            double summerDiscount = 0;

            int autumnHotelPrice = 20;
            int autumnCampingPrice = 15;
            double autumnDiscount = 0.3;

            int winterHotelPrice = 40;
            int winterCampingPrice = 10;
            double winterDiscount = 0.1;

            double vacationCost = 0;

            switch (accommodation)
            {
                case "Hotel":
                    switch (season)
                    {
                        case "Spring":
                            vacationCost = springHotelPrice * stay - (springHotelPrice * stay * springDiscount);
                            break;
                        case "Summer":
                            vacationCost = summerHotelPrice * stay - (summerHotelPrice * stay * summerDiscount);
                            break;
                        case "Autumn":
                            vacationCost = autumnHotelPrice * stay - (autumnHotelPrice * stay * autumnDiscount);
                            break;
                        case "Winter":
                            vacationCost = winterHotelPrice * stay - (winterHotelPrice * stay * winterDiscount);
                            break;
                    } 
                    break;

                case "Camping":
                    switch (season)
                    {
                        case "Spring":
                            vacationCost = springCampingPrice * stay - (springCampingPrice * stay * springDiscount);
                            break;
                        case "Summer":
                            vacationCost = summerCampingPrice * stay - (summerCampingPrice * stay * summerDiscount);
                            break;
                        case "Autumn":
                            vacationCost = autumnCampingPrice * stay - (autumnCampingPrice * stay * autumnDiscount);
                            break;
                        case "Winter":
                            vacationCost = winterCampingPrice * stay - (winterCampingPrice * stay * winterDiscount);
                            break;
                    }

                    break;
                
            }

            Console.WriteLine($"{vacationCost:F2}");
        }
    }
}

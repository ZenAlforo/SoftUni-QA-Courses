using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GetGreeting
{
    public class GreetingProvider
    {
        // Declaring the variable _timeProvider
        private readonly ITimeProvider _timeProvider;

        // Setting the _timeProvider constructor 
        public GreetingProvider(ITimeProvider timeProvider)
        {
            _timeProvider = timeProvider;
        }

        // Implementation of GetGreeting method
        public string GetGreeting()
        {
            var hour = _timeProvider.GetCurrentTime().Hour;

            if (hour >= 5 && hour < 12)
            {
                return "Good morning!";
            }
            else if (hour >= 12 && hour < 18)
            {
                return "Good afternoon!";
            }
            else if (hour >= 18 && hour < 22)
            {
                return "Good evening!";
            }
            else
            {
                return "Good night!";
            }
        }
    }

}

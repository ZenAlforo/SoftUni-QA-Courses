using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GetGreeting
{
    public class SystemTimeProvider : ITimeProvider
    {
        // SystemTimeProvider extends ITimeProvider
        public DateTime GetCurrentTime()
        {
            return DateTime.Now;
        }
    }
}

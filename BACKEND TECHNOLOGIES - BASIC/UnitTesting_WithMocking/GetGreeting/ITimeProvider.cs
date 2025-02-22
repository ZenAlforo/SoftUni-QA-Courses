using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GetGreeting
{
    public interface ITimeProvider
    {
        // Setting the interface contract
        DateTime GetCurrentTime();
    }
}

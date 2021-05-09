using System;

namespace AppWithViewComponent
{
    public class TimeService : ITimeService
    {
        public string GetTime()
        {
            return DateTime.Now.ToString();
        }
    }
}

using Microsoft.Extensions.Logging;

namespace WithHighPerfLogging
{
    public static class Events
    {
        public static readonly EventId Started = new EventId(100, "Started");
    }
}

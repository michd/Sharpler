namespace Sharpler.Support
{
    using System;

    public static class ExtensionMethods
    {
        public static string FormatAsPlaybackTime(this TimeSpan ts)
        {
            var hours = (int)Math.Floor(ts.TotalHours);

            return hours > 0
                ? $"{hours}:{ts.Minutes:D2}:{ts.Seconds:D2}"
                : $"{ts.Minutes}:{ts.Seconds:D2}";
        }
    }
}
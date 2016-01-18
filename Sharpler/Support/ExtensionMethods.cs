namespace Sharpler.Support
{
    using System;
    using System.Collections.Generic;

    public static class ExtensionMethods
    {
        public static string FormatAsPlaybackTime(this TimeSpan ts)
        {
            var hours = (int)Math.Floor(ts.TotalHours);

            return hours > 0
                ? $"{hours}:{ts.Minutes:D2}:{ts.Seconds:D2}"
                : $"{ts.Minutes}:{ts.Seconds:D2}";
        }

        public static void Shuffle<T>(this IList<T> list)
        {
            var randomGen = new Random();

            var n = list.Count;

            while (n > 1)
            {
                n--;

                var k = randomGen.Next(n + 1);
                var value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
        }
    }
}
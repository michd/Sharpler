namespace Sharpler
{
    using System;

    using Sharpler.Playback;

    public class Application
    {
        public Application(ITransport trackPlayer)
        {
            TrackPlayer = trackPlayer;

            Console.WriteLine(@"Application initalised.");
        }

        public ITransport TrackPlayer { get; }
    }
}

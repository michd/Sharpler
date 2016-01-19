namespace Sharpler
{
    using System;

    using Sharpler.Data;
    using Sharpler.Playback;

    public class Application
    {
        public Application(ITransport trackPlayer)
        {
            TrackPlayer = trackPlayer;

            PlayQueue = new Playlist();

            PlaylistPlayer = new PlaylistPlayer(this);

            Console.WriteLine(@"Application initalised.");
        }

        public ITransport TrackPlayer { get; }

        public PlaylistPlayer PlaylistPlayer { get; }

        public Playlist PlayQueue { get; }
    }
}

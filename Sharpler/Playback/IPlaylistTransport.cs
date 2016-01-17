namespace Sharpler.Playback
{
    /// <summary>
    /// Extension of ITransport, applying only to contexts with multiple tracks
    /// </summary>
    interface IPlaylistTransport : ITransport
    {
        /// <summary>
        /// Skip to the previous track in the playlist, if any
        /// </summary>

        void SkipToPrevious();
        /// <summary>
        /// Skip to the next track in the playlist, if any
        /// </summary>
        void SkipToNext();
    }
}

using System.IO;

namespace Sharpler.Data
{
    using TagLib;

    /// <summary>
    /// Reads metadata from audio files, returning fully formed Track instances
    /// </summary>
    public static class MetadataReader
    {
        public static Track ReadTrack(string filePath)
        {
            var file = File.Create(filePath);

            return new Track
            {
                FilePath = Path.GetFullPath(filePath),
                Album = file.Tag.Album != string.Empty
                    ? new Album
                          {
                              Title = file.Tag.Album,
                              Artist = file.Tag.JoinedAlbumArtists
                          }
                    : null,
                Artist = file.Tag.JoinedPerformers,
                Title = file.Tag.Title,
                TrackNumber = file.Tag.Track,
                Duration = file.Properties.Duration
            };
        }
    }
}

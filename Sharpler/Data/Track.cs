using System.IO;

namespace Sharpler.Data
{
    public class Track
    {
        public int? TrackNumber { get; set; }

        public string Artist { get; set; }

        public string Title { get; set; }

        public Album Album { get; set; }

        public string FilePath { get; set; }

        // TODO art? - Make getter return album?.Art is art here is null

        // TODO: this is an oversimplification, format should be configurable
        public override string ToString()
        {
            if (Artist != null && Title != null)
            {
                return $"{Artist} - {Title}";
            }

            if (Title != null)
            {
                return Title;
            }

            if (FilePath != null)
            {
                return Path.GetFileNameWithoutExtension(FilePath);
            }

            return string.Empty;
        }
    }
}

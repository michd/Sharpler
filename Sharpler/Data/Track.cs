namespace Sharpler.Data
{
    using System;
    using System.IO;

    public class Track
    {
        private string artist;

        private string title;

        public uint? TrackNumber { get; set; }

        public string Artist
        {
            get
            {
                return artist;
            }

            set
            {
                if (artist == value)
                {
                    return;
                }

                artist = string.IsNullOrWhiteSpace(value) ? null : value;
            }
        }

        public string Title
        {
            get
            {
                return title;
            }

            set
            {
                if (title == value)
                {
                    return;
                }

                title = string.IsNullOrWhiteSpace(value) ? null : value;
            }
        }

        public Album Album { get; set; }

        public TimeSpan Duration { get; set; }

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

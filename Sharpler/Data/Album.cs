namespace Sharpler.Data
{
    using System.Collections.Generic;

    public class Album
    {
        public string Title { get; set; }

        public string Artist { get; set; }

        public List<Track> Tracks { get; set; }

        // TODO: Art?

        public override string ToString()
        {
            return Title;
        }
    }
}

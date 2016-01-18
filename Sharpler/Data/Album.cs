namespace Sharpler.Data
{
    using System.Collections.Generic;

    // TODO: add an art property (but first figure out how to represent it)
    public class Album
    {
        public string Title { get; set; }

        public string Artist { get; set; }

        public List<Track> Tracks { get; set; }

        public override string ToString()
        {
            return Title;
        }
    }
}

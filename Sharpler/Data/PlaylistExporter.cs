namespace Sharpler.Data
{
    using System;
    using System.IO;

    public static class PlaylistExporter
    {
        private const string PlsExtension = "pls";

        private const string M3UExtension = "m3u";

        public static void Export(this Playlist playlist, string destinationFile)
        {
            var extension = Path.GetExtension(destinationFile)?.ToLower();

            switch (extension)
            {
                case PlsExtension:
                    ExportPls(playlist, destinationFile);
                    return;

                case M3UExtension:
                    ExportM3u(playlist, destinationFile);
                    return;

                default:
                    ExportPls(playlist, Path.ChangeExtension(destinationFile, PlsExtension));
                    return;
            }
        }

        private static void ExportPls(Playlist playlist, string destinationFile)
        {
            throw new NotImplementedException();
        }

        private static void ExportM3u(Playlist playlist, string destinationFile)
        {
            throw new NotImplementedException();
        }
    }
}

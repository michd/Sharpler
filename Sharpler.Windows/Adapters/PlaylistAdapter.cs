namespace Sharpler.Windows.Adapters
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Drawing;
    using System.Runtime.CompilerServices;
    using System.Windows.Forms;

    using Sharpler.Data;

    public class PlaylistAdapter : INotifyPropertyChanged
    {
        private readonly ListBox listBox;

        private readonly Dictionary<string, Track> trackDictionary = new Dictionary<string, Track>();

        private readonly Font highlightFont;

        private readonly Brush textBrush;

        private Playlist playlist;

        private int? highlightedIndex;

        public PlaylistAdapter(ListBox listBox, Playlist playlist)
        {
            this.listBox = listBox;
            Playlist = playlist;

            highlightFont = new Font(listBox.Font.FontFamily, listBox.Font.Size, FontStyle.Bold);
            textBrush = new SolidBrush(listBox.ForeColor);

            listBox.DrawItem += ListBoxOnDrawItem;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public Playlist Playlist
        {
            get
            {
                return playlist;
            }

            set
            {
                if (playlist == value)
                {
                    return;
                }

                if (playlist != null)
                {
                    playlist.ListChanged -= PlaylistOnListChanged;
                }

                playlist = value;

                if (playlist != null)
                {
                    playlist.ListChanged += PlaylistOnListChanged;
                }
            }
        }

        public int? HighlightedIndex
        {
            set
            {
                if (highlightedIndex == value)
                {
                    return;
                }

                highlightedIndex = value;

                if (highlightedIndex != null)
                {
                    listBox.Refresh();
                }
            }
        }

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void PlaylistOnListChanged(object sender, EventArgs e)
        {
            GenerateTrackDictionary();
            listBox.Items.Clear();

            foreach (var trackStr in trackDictionary.Keys)
            {
                listBox.Items.Add(trackStr);
            }
        }

        private void GenerateTrackDictionary()
        {
            trackDictionary.Clear();

            var trackNum = 1;

            foreach (var track in playlist)
            {
                trackDictionary.Add($"{trackNum++}. {track}", track);
            }
        }

        private void ListBoxOnDrawItem(object sender, DrawItemEventArgs args)
        {
            args.DrawBackground();
            args.Graphics.DrawString(
                listBox.Items[args.Index].ToString(),
                args.Index == (highlightedIndex ?? -1) ? highlightFont : args.Font,
                textBrush,
                args.Bounds);

            args.DrawFocusRectangle();
        }
    }
}

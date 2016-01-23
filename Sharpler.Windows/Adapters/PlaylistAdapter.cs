namespace Sharpler.Windows.Adapters
{
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Windows.Forms;

    using Sharpler.Data;
    using Sharpler.Support;

    public class PlaylistAdapter
    {
        private readonly DataGridView dataGridView;

        private readonly Dictionary<string, Track> trackDictionary = new Dictionary<string, Track>();

        private readonly Font highlightFont;

        private Playlist playlist;

        private int? highlightedIndex;

        public PlaylistAdapter(DataGridView dataGridView, Playlist playlist)
        {
            this.dataGridView = dataGridView;
            Playlist = playlist;

            highlightFont = new Font(dataGridView.Font.FontFamily, dataGridView.Font.Size, FontStyle.Italic);

            dataGridView.CellDoubleClick += DataGridViewOnCellDoubleClick;

            dataGridView.Resize += (s, e) => ResizeColumns();

            dataGridView.Columns.Add("track", "Track");
            dataGridView.Columns.Add("duration", "Duration");
        }

        internal event EventHandler<PlaylistItemDoubleClickedEventargs> ItemDoubleClicked;

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

                var oldIndex = highlightedIndex;

                highlightedIndex = value;

                UpdateHighlightedRow(oldIndex, highlightedIndex);
            }
        }

        private void PlaylistOnListChanged(object sender, EventArgs e)
        {
            GenerateTrackDictionary();
            dataGridView.Rows.Clear();

            foreach (var trackPair in trackDictionary)
            {
                var row = new DataGridViewRow();
                row.Cells.Add(new DataGridViewTextBoxCell { Value = trackPair.Key });
                row.Cells.Add(new DataGridViewTextBoxCell { Value = trackPair.Value.Duration.FormatAsPlaybackTime() });
                dataGridView.Rows.Add(row);
            }

            ResizeColumns();
            UpdateHighlightedRow(newRowIndex: highlightedIndex);
        }

        private void UpdateHighlightedRow(int? oldRowIndex = null, int? newRowIndex = null)
        {
            if (oldRowIndex != null && dataGridView.Rows.Count - 1 >= oldRowIndex.Value)
            {
                var row = dataGridView.Rows[oldRowIndex.Value];

                foreach (DataGridViewCell cell in row.Cells)
                {
                    cell.Style.Font = dataGridView.Font;
                }
            }

            if (newRowIndex != null && dataGridView.Rows.Count - 1 >= newRowIndex.Value)
            {
                var row = dataGridView.Rows[newRowIndex.Value];

                foreach (DataGridViewCell cell in row.Cells)
                {
                    cell.Style.Font = highlightFont;
                }
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

        private void ResizeColumns()
        {
            dataGridView.AutoResizeColumn(1);
            dataGridView.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }

        private void DataGridViewOnCellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            ItemDoubleClicked?.Invoke(this, new PlaylistItemDoubleClickedEventargs(e.RowIndex));
        }

        internal class PlaylistItemDoubleClickedEventargs : EventArgs
        {
            public PlaylistItemDoubleClickedEventargs(int index)
            {
                Index = index;
            }

            public int Index { get; }
        }
    }
}

namespace Sharpler.Windows
{
    using System;
    using System.ComponentModel;
    using System.Linq;
    using System.Windows.Forms;

    using Sharpler.Data;
    using Sharpler.Playback;
    using Sharpler.Support;
    using Sharpler.Windows.Adapters;
    using Sharpler.Windows.Playback;

    using Application = Sharpler.Application;

    public partial class MainForm : Form
    {
        private readonly Application application;

        private PlaylistAdapter playQueueAdapter;

        public MainForm()
        {
            InitializeComponent();

            application = new Application(new TrackPlayer());
            TrackPlayer.PropertyChanged += TrackPlayerOnPropertyChanged;
            PlaylistPlayer.PropertyChanged += PlaylistPlayerOnPropertyChanged;
        }

        private TrackPlayer TrackPlayer => application.TrackPlayer as TrackPlayer;

        private PlaylistPlayer PlaylistPlayer => application.PlaylistPlayer;

        private void TrackPlayerOnPropertyChanged(object sender, PropertyChangedEventArgs args)
        {
            switch (args.PropertyName)
            {
                case nameof(TrackPlayer.Track):
                    trackNameLabel.Text = TrackPlayer.Track.ToString();
                    break;

                case nameof(TrackPlayer.PlayState):
                    // TODO: localization
                    playPauseButton.Text = (TrackPlayer.PlayState == PlayState.Playing) ? "Pause" : "Play";
                    break;

                case nameof(TrackPlayer.TrackDuration):
                    progressBar.Maximum = (int)(TrackPlayer.TrackDuration?.TotalMilliseconds ?? 0);
                    durationLabel.Text = (TrackPlayer.TrackDuration ?? TimeSpan.Zero).FormatAsPlaybackTime();
                    break;

                case nameof(TrackPlayer.CurrentTime):
                    progressBar.Value = (int)TrackPlayer.CurrentTime.TotalMilliseconds;
                    currentTimeLabel.Text = TrackPlayer.CurrentTime.FormatAsPlaybackTime();
                    break;
            }
        }

        private void PlaylistPlayerOnPropertyChanged(object sender, PropertyChangedEventArgs args)
        {
            switch (args.PropertyName)
            {
                case nameof(PlaylistPlayer.CurrentIndex):
                    playQueueAdapter.HighlightedIndex = PlaylistPlayer.CurrentIndex;
                    break;
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            playQueueAdapter = new PlaylistAdapter(playlistDataGridView, application.PlayQueue);

            playQueueAdapter.ItemDoubleClicked += (s, args) => PlaylistPlayer.SkipToIndex(args.Index);
        }

        private void SelectFileButton_Click(object sender, EventArgs e)
        {
            if (selectFileDialog.ShowDialog() != DialogResult.OK)
            {
                return;
            }

            application.PlayQueue.Clear();
            application.PlayQueue.AddRange(selectFileDialog.FileNames.Select(MetadataReader.ReadTrack));
        }

        private void PlayPauseButton_Click(object sender, EventArgs e)
        {
            if (TrackPlayer.PlayState == PlayState.Playing)
            {
                PlaylistPlayer.Pause();
                return;
            }

            PlaylistPlayer.Play();
        }

        private void StopButton_Click(object sender, EventArgs e)
        {
            PlaylistPlayer.Stop();
        }

        private void ProgressBar_MouseClick(object sender, MouseEventArgs args)
        {
            var seekPoint = (float)progressBar.Maximum / progressBar.Width * args.X;

            TrackPlayer.SeekTo(TimeSpan.FromMilliseconds(seekPoint));
        }

        private void PreviousButton_Click(object sender, EventArgs e)
        {
            PlaylistPlayer.SkipToPreviousTrack();
        }

        private void NextButton_Click(object sender, EventArgs e)
        {
            PlaylistPlayer.SkipToNextTrack();
        }
    }
}
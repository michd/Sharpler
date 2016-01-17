namespace Sharpler.Windows
{
    using System;
    using System.ComponentModel;
    using System.Windows.Forms;

    using Sharpler.Data;
    using Sharpler.Playback;
    using Sharpler.Windows.Playback;

    using Application = Sharpler.Application;

    public partial class MainForm : Form
    {
        private readonly Application application;

        public MainForm()
        {
            InitializeComponent();

            application = new Application(new TrackPlayer());
            application.TrackPlayer.PropertyChanged += TrackPlayerOnPropertyChanged;
        }

        private TrackPlayer TrackPlayer => application.TrackPlayer as TrackPlayer;

        private void SelectFileButton_Click(object sender, EventArgs e)
        {
            if (selectFileDialog.ShowDialog() != DialogResult.OK)
            {
                return;
            }

            var track = new Track { FilePath = selectFileDialog.FileName };

            TrackPlayer.Track = track;
        }

        private void PlayPauseButton_Click(object sender, EventArgs e)
        {
            if (TrackPlayer.PlayState == PlayState.Playing)
            {
                TrackPlayer.Pause();
                return;
            }

            TrackPlayer.Play();
        }

        private void StopButton_Click(object sender, EventArgs e)
        {
            TrackPlayer.Stop();
        }

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
            }
        }
    }
}

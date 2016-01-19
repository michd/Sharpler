namespace Sharpler.Windows.Playback
{
    using System;
    using System.ComponentModel;
    using System.Runtime.CompilerServices;
    using System.Threading;
    using System.Threading.Tasks;

    using NAudio.Wave;

    using Sharpler.Data;
    using Sharpler.Playback;

    public class TrackPlayer : ITransport, IDisposable
    {
        private static readonly TimeSpan TimeUpdateRate = TimeSpan.FromMilliseconds(200);

        private readonly IWavePlayer waveOutDevice = new WaveOut();

        private AudioFileReader audioFileReader;

        private CancellationTokenSource timeUpdateCts;

        private Track track;

        private bool nextStopIsRequested;

        public TrackPlayer(Track track = null)
        {
            Track = track;
            waveOutDevice.PlaybackStopped += WaveOutDeviceOnPlaybackStopped;

            PropertyChanged += LocalOnPropertyChanged;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public event EventHandler TrackFinished;

        public Track Track
        {
            get
            {
                return track;
            }

            set
            {
                if (track == value)
                {
                    return;
                }

                track = value;

                OnPropertyChanged();

                if (track == null)
                {
                    return;
                }

                waveOutDevice.Stop();
                audioFileReader?.Dispose();

                audioFileReader = new AudioFileReader(track.FilePath);
                waveOutDevice.Init(audioFileReader);

                OnPropertyChanged(nameof(TrackDuration));
            }
        }

        public TimeSpan CurrentTime => audioFileReader.CurrentTime;

        public TimeSpan? TrackDuration
        {
            get
            {
                if (Track == null)
                {
                    return null;
                }

                return audioFileReader.TotalTime;
            }
        }

        public PlayState PlayState
        {
            get
            {
                switch (waveOutDevice.PlaybackState)
                {
                    case PlaybackState.Playing:
                        return PlayState.Playing;

                    case PlaybackState.Paused:
                        return PlayState.Paused;

                    default:
                        return PlayState.Stopped;
                }
            }
        }

        public void Play()
        {
            if (waveOutDevice == null)
            {
                return;
            }

            waveOutDevice.Play();
            OnPropertyChanged(nameof(PlayState));
        }

        public void Pause()
        {
            if (waveOutDevice == null)
            {
                return;
            }

            waveOutDevice.Pause();
            OnPropertyChanged(nameof(PlayState));
        }

        public void Stop()
        {
            if (waveOutDevice == null || audioFileReader == null)
            {
                return;
            }

            // This flag ensures we can distinguish between track endings and manual
            // stop calls in the PlaybackStopped event handler
            nextStopIsRequested = true;

            waveOutDevice.Stop();
            audioFileReader.Position = 0;

            OnPropertyChanged(nameof(PlayState));
            OnPropertyChanged(nameof(CurrentTime));
        }

        public void SeekTo(TimeSpan seekPoint)
        {
            if (Track == null)
            {
                return;
            }

            audioFileReader.CurrentTime = seekPoint;
            OnPropertyChanged(nameof(CurrentTime));
        }

        public void Dispose()
        {
            PropertyChanged = null;
            StopUpdatingTime();

            Track = null;

            waveOutDevice.PlaybackStopped -= WaveOutDeviceOnPlaybackStopped;

            audioFileReader.Dispose();
            waveOutDevice.Dispose();
        }

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void StartUpdatingTime()
        {
            StopUpdatingTime();

            timeUpdateCts = new CancellationTokenSource();
            UpdateTime();
        }

        private void StopUpdatingTime()
        {
            timeUpdateCts?.Cancel();
            timeUpdateCts?.Dispose();
            timeUpdateCts = null;
        }

        private async void UpdateTime()
        {
            try
            {
                OnPropertyChanged(nameof(CurrentTime));
                await Task.Delay(TimeUpdateRate, timeUpdateCts.Token);
                UpdateTime();
            }
            catch (TaskCanceledException)
            {
                // Canceled, so don't do anything
            }
        }

        private void WaveOutDeviceOnPlaybackStopped(object sender, StoppedEventArgs stoppedEventArgs)
        {
            if (nextStopIsRequested)
            {
                nextStopIsRequested = false;
                return;
            }

            audioFileReader.CurrentTime = TimeSpan.Zero;

            if (stoppedEventArgs.Exception == null)
            {
                TrackFinished?.Invoke(this, new EventArgs());
            }

            OnPropertyChanged(nameof(PlayState));
        }

        private void LocalOnPropertyChanged(object sender, PropertyChangedEventArgs args)
        {
            switch (args.PropertyName)
            {
                case nameof(PlayState):
                    if (PlayState == PlayState.Playing)
                    {
                        StartUpdatingTime();
                    }
                    else
                    {
                        StopUpdatingTime();
                    }

                    break;
            }
        }
    }
}

namespace Sharpler.Windows.Playback
{
    using System;
    using System.ComponentModel;
    using System.Runtime.CompilerServices;

    using NAudio.Wave;

    using global::Sharpler.Playback;
    using global::Sharpler.Data;
    using global::Sharpler.Windows.Annotations;

    // TODO: PropertyChanged events on CurrentTime, TrackDuration
    public class TrackPlayer : ITransport, IDisposable
    {
        private readonly IWavePlayer waveOutDevice = new WaveOut();

        private AudioFileReader audioFileReader;

        private Track track;

        public TrackPlayer(Track track = null)
        {
            Track = track;
            waveOutDevice.PlaybackStopped += WaveOutDeviceOnPlaybackStopped;
        }

        

        public event PropertyChangedEventHandler PropertyChanged;

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

                audioFileReader = new AudioFileReader(track.FilePath);
                waveOutDevice.Init(audioFileReader);
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
            waveOutDevice.Play();
            OnPropertyChanged(nameof(PlayState));
        }

        public void Pause()
        {
            waveOutDevice.Pause();
            OnPropertyChanged(nameof(PlayState));
        }

        public void Stop()
        {
            waveOutDevice.Stop();
            audioFileReader.Position = 0;
            OnPropertyChanged(nameof(PlayState));
        }

        public void Seek(TimeSpan seekPoint)
        {
            audioFileReader.CurrentTime = seekPoint;
        }

        public void Dispose()
        {
            PropertyChanged = null;
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

        private void WaveOutDeviceOnPlaybackStopped(object sender, StoppedEventArgs stoppedEventArgs)
        {
            audioFileReader.CurrentTime = TimeSpan.Zero;
            OnPropertyChanged(nameof(PlayState));
        }
    }
}

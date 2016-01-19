namespace Sharpler.Playback
{
    using System;
    using System.ComponentModel;
    using System.Runtime.CompilerServices;

    using Sharpler;
    using Sharpler.Data;

    public class PlaylistPlayer : INotifyPropertyChanged
    {
        private readonly Application application;
        private int? currentIndex;

        public PlaylistPlayer(Application application)
        {
            this.application = application;

            PlayQueue.PropertyChanged += PlayQueueOnPropertyChanged;
            PlayQueue.ListChanged += PlayQueueOnListChanged;
            TrackPlayer.TrackFinished += TrackPlayerOnTrackFinished;

            UpdatePosition();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public Track CurrentTrack
        {
            get
            {
                if (CurrentIndex == null)
                {
                    return null;
                }

                return PlayQueue.Count == 0 ? null : PlayQueue[CurrentIndex.Value];
            }
        }

        public int? CurrentIndex
        {
            get
            {
                return currentIndex;
            }

            set
            {
                if (currentIndex == value)
                {
                    return;
                }

                currentIndex = value;

                OnPropertyChanged();
                OnPropertyChanged(nameof(CurrentTrack));
            }
        }

        private ITransport TrackPlayer => application.TrackPlayer;

        private Playlist PlayQueue => application.PlayQueue;

        public void Play()
        {
            if (CurrentIndex == null)
            {
                return;
            }

            if (TrackPlayer.Track != PlayQueue[CurrentIndex.Value])
            {
                TrackPlayer.Track = PlayQueue[CurrentIndex.Value];
            }

            TrackPlayer.Play();
        }

        public void Pause()
        {
            TrackPlayer.Pause();
        }

        public void Stop()
        {
            TrackPlayer.Stop();
        }

        public void SkipToPreviousTrack()
        {
            if (CurrentIndex == 0)
            {
                return;
            }

            CurrentIndex--;
            PlayCurrentTrack();
        }

        public void SkipToNextTrack()
        {
            if (CurrentIndex == PlayQueue.Count - 1)
            {
                return;
            }

            CurrentIndex++;
            PlayCurrentTrack();
        }

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void PlayCurrentTrack()
        {
            if (CurrentIndex == null)
            {
                return;
            }

            if (TrackPlayer.Track != PlayQueue[CurrentIndex.Value])
            {
                TrackPlayer.Track = PlayQueue[CurrentIndex.Value];
            }

            TrackPlayer.Play();
        }

        private void UpdatePosition()
        {
            // No tracks in queue, so we don't have a current index.
            if (PlayQueue.Count == 0)
            {
                CurrentIndex = null;
                Stop();
                return;
            }

            // Didn't have an index, but now there are tracks, start at 0
            if (CurrentIndex == null)
            {
                CurrentIndex = 0;
                return;
            }

            // Play queue didn't shrink past the track we were playing,
            // Ensure it's still the same track we were playing
            if (CurrentIndex < PlayQueue.Count)
            {
                PlayCurrentTrack();
                return;
            }

            // playlist shrunk past the current position
            // Stop playback and set position to last item
            TrackPlayer.Stop();
            CurrentIndex = PlayQueue.Count - 1;
        }

        private void PlayQueueOnPropertyChanged(object sender, PropertyChangedEventArgs args)
        {
            switch (args.PropertyName)
            {
                case nameof(PlayQueue.Count):
                    UpdatePosition();
                    break;
            }
        }

        private void PlayQueueOnListChanged(object sender, EventArgs e)
        {
            UpdatePosition();
        }

        // TODO: support looping playlist, looping track, shuffle
        private void TrackPlayerOnTrackFinished(object sender, EventArgs args)
        {
            if (CurrentIndex == null)
            {
                return;
            }

            // This was the last track, do nothing (playback finished)
            if (CurrentIndex == PlayQueue.Count - 1)
            {
                return;
            }

            CurrentIndex++;

            TrackPlayer.Track = PlayQueue[CurrentIndex.Value];
            TrackPlayer.Play();
        }
    }
}

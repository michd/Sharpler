namespace Sharpler.Data
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Runtime.CompilerServices;
    using System.Linq;

    using Sharpler.Support;

    public class Playlist : IEnumerable<Track>, INotifyPropertyChanged
    {
        private readonly List<Track> list = new List<Track>();
        private TimeSpan duration;

        public event EventHandler ListChanged;

        public event PropertyChangedEventHandler PropertyChanged;

        public int Count => list.Count;

        public TimeSpan Duration
        {
            get
            {
                return duration;
            }

            private set
            {
                if (value.Equals(duration))
                {
                    return;
                }

                duration = value;
                OnPropertyChanged();
            }
        }

        public void Add(Track track)
        {
            list.Add(track);
            OnListChanged();
            OnPropertyChanged(nameof(Count));
            CalculateDuration();
        }

        public void Move(int startPos, int newPos)
        {
            if (startPos == newPos)
            {
                return;
            }

            var track = list[startPos];

            list.RemoveAt(startPos);
            list.Insert(newPos, track);
            OnListChanged();
        }

        public void Remove(int pos)
        {
            list.RemoveAt(pos);
            OnListChanged();
            OnPropertyChanged(nameof(Count));
            CalculateDuration();
        }

        public void Shuffle()
        {
            list.Shuffle();
            OnListChanged();
        }

        public IEnumerator<Track> GetEnumerator()
        {
            return list.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void OnListChanged()
        {
            ListChanged?.Invoke(this, new EventArgs());
        }

        private void CalculateDuration()
        {
            Duration = list.Aggregate(TimeSpan.Zero, (total, next) => total + next.Duration);
        }
    }
}

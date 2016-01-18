namespace Sharpler.Data
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Linq;
    using System.Runtime.CompilerServices;

    using Sharpler.Annotations;
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
            OnChanged();
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
            OnChanged();
        }

        public void Remove(int pos)
        {
            list.RemoveAt(pos);
            OnChanged();
            OnPropertyChanged(nameof(Count));
            CalculateDuration();
        }

        public void Shuffle()
        {
            list.Shuffle();
            OnChanged();
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

        private void OnChanged()
        {
            ListChanged?.Invoke(this, new EventArgs());
        }

        private void CalculateDuration()
        {
            Duration = list.Aggregate(TimeSpan.Zero, (total, next) => total += next.Duration);
        }
    }
}

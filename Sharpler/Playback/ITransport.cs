using Sharpler.Data;

namespace Sharpler.Playback
{
    using System;
    using System.ComponentModel;

    /// <summary>
    /// ITransport is the common interface for controlling playback 
    /// </summary>
    public interface ITransport : INotifyPropertyChanged
    {
        /// <summary>
        /// Start playback, from CurrentTime
        /// </summary>
        void Play();

        /// <summary>
        /// Stop playback, but hold on to CurrentTime
        /// </summary>
        void Pause();

        /// <summary>
        /// Stop playback, revert CurrentTime to staring point
        /// </summary>
        void Stop();

        /// <summary>
        /// Skip to a certain point in the current track
        /// Should throw an OutOfRangeException or something
        /// if seekPoint is higher than the duration of the track
        /// </summary>
        /// <param name="seekPoint">Time position in the track to seek to</param>
        void Seek(TimeSpan seekPoint);

        /// <summary>
        /// Retrieve the current position within the track
        /// </summary>
        TimeSpan CurrentTime { get; }

        /// <summary>
        /// Duration of currently loaded track, if any
        /// </summary>
        TimeSpan? TrackDuration { get; }

        /// <summary>
        /// Whether we're stopped, playing or paused
        /// </summary>
        PlayState PlayState { get; }

        Track Track { get; set; }
    }

    public enum PlayState
    {
        Stopped,
        Playing,
        Paused
    }
}
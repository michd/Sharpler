namespace Sharpler.Playback
{
    using System;
    using System.ComponentModel;

    using Sharpler.Data;

    /// <summary>
    /// ITransport is the common interface for controlling playback
    /// </summary>
    public interface ITransport : INotifyPropertyChanged
    {
        /// <summary>
        /// Gets the current position within the track
        /// </summary>
        TimeSpan CurrentTime { get; }

        /// <summary>
        /// Gets the duration of currently loaded track, if any
        /// </summary>
        TimeSpan? TrackDuration { get; }

        /// <summary>
        /// Gets the current playback state: stopped, playing or paused
        /// </summary>
        PlayState PlayState { get; }

        /// <summary>
        /// Gets or sets the currently relevant track
        /// </summary>
        Track Track { get; set; }

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
        void SeekTo(TimeSpan seekPoint);
    }

    public enum PlayState
    {
        Stopped,
        Playing,
        Paused
    }
}
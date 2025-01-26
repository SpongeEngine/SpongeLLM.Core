using SpongeEngine.SpongeLLM.Core.Models;

namespace SpongeEngine.SpongeLLM.Core.Interfaces
{
    /// <summary>
    /// Interface for tracking operation progress
    /// </summary>
    public interface IProgressTracker
    {
        /// <summary>
        /// Event fired when progress is updated
        /// </summary>
        event EventHandler<ProgressUpdateEventArgs> ProgressUpdated;

        /// <summary>
        /// Current state of the operation
        /// </summary>
        ProgressState State { get; }

        /// <summary>
        /// Current progress message
        /// </summary>
        string? CurrentMessage { get; }

        /// <summary>
        /// Progress percentage if available (0-100)
        /// </summary>
        double? PercentComplete { get; }

        /// <summary>
        /// Time elapsed since operation start
        /// </summary>
        TimeSpan ElapsedTime { get; }

        /// <summary>
        /// Reports a progress update
        /// </summary>
        void ReportProgress(ProgressUpdate update);

        /// <summary>
        /// Resets progress tracking state
        /// </summary>
        void Reset();
    }

    /// <summary>
    /// Event args for progress updates
    /// </summary>
    public class ProgressUpdateEventArgs : EventArgs
    {
        public ProgressUpdate Update { get; }

        public ProgressUpdateEventArgs(ProgressUpdate update)
        {
            Update = update;
        }
    }
}
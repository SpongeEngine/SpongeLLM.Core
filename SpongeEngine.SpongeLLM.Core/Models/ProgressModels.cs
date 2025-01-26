namespace SpongeEngine.SpongeLLM.Core.Models
{
    public class ProgressUpdate
    {
        public ProgressState State { get; set; }
        public string Message { get; set; } = string.Empty;
        public double? PercentComplete { get; set; }
        public TimeSpan ElapsedTime { get; set; }
        public IDictionary<string, object>? ProgressData { get; set; }
    }

    public enum ProgressState
    {
        NotStarted,
        Starting,
        LoadingModel,
        TokenizingInput,
        Generating,
        Streaming,
        PostProcessing,
        Complete,
        Failed,
        Cancelled
    }
}
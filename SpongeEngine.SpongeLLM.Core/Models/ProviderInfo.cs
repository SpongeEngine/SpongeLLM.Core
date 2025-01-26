namespace SpongeEngine.LLMSharp.Core.Models
{
    public class ProviderInfo
    {
        public string Name { get; init; } = string.Empty;
        public string? Version { get; init; }
        public bool SupportsStreaming { get; init; }
        public bool SupportsChat { get; init; }
        public bool SupportsEmbeddings { get; init; }
        public string BaseUrl { get; init; } = string.Empty;
        public ProviderCapabilities Capabilities { get; init; } = new();
    }

    public class ProviderCapabilities
    {
        public int MaxContextLength { get; init; }
        public float MinTemperature { get; init; }
        public float MaxTemperature { get; init; }
        public bool SupportsModelManagement { get; init; }
        public IDictionary<string, object> ExtraCapabilities { get; init; } = new Dictionary<string, object>();
    }
}
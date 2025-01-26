namespace SpongeEngine.LLMSharp.Core.Models
{
    public class ModelInfo
    {
        public string Id { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string Provider { get; set; } = string.Empty;
        public string Family { get; set; } = string.Empty;
        public ModelType Type { get; set; }
        public ModelCapabilities Capabilities { get; set; } = new();
        public IDictionary<string, object> Metadata { get; set; } = new Dictionary<string, object>();
    }

    public class ModelCapabilities
    {
        public bool SupportsStreaming { get; set; }
        public bool SupportsChat { get; set; }
        public bool SupportsEmbedding { get; set; }
        public int MaxContextLength { get; set; }
        public int MaxGenerationLength { get; set; }
        public bool SupportsSamplingParams { get; set; } = true;
        public float? MinTemperature { get; set; }
        public float? MaxTemperature { get; set; }
        public float? MinTopP { get; set; }
        public float? MaxTopP { get; set; }
        public IDictionary<string, object> ProviderSpecificCapabilities { get; set; } 
            = new Dictionary<string, object>();
    }

    public enum ModelType
    {
        Text,
        Chat,
        Embedding,
        Multimodal
    }
}
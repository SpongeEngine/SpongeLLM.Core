namespace SpongeEngine.LLMSharp.Core.Models
{
    public class EmbeddingRequest
    {
        public string ModelId { get; set; } = string.Empty;
        public string Text { get; set; } = string.Empty;
        public IDictionary<string, object> ProviderParameters { get; set; } = new Dictionary<string, object>();
    }

    public class BatchEmbeddingRequest
    {
        public string ModelId { get; set; } = string.Empty;
        public IList<string> Texts { get; set; } = new List<string>();
        public IDictionary<string, object> ProviderParameters { get; set; } = new Dictionary<string, object>();
    }

    public class EmbeddingResponse
    {
        public float[] Vector { get; set; } = Array.Empty<float>();
        public string ModelId { get; set; } = string.Empty;
        public int TokenCount { get; set; }
        public IDictionary<string, object> Metadata { get; set; } = new Dictionary<string, object>();
    }

    public class BatchEmbeddingResponse
    {
        public IList<float[]> Vectors { get; set; } = new List<float[]>();
        public string ModelId { get; set; } = string.Empty;
        public int TotalTokenCount { get; set; }
        public IDictionary<string, object> Metadata { get; set; } = new Dictionary<string, object>();
    }

    public class EmbeddingModelInfo
    {
        public int VectorDimension { get; set; }
        public bool SupportsBatching { get; set; }
        public int? MaxBatchSize { get; set; }
        public int? MaxInputLength { get; set; }
        public bool IsNormalized { get; set; }
        public IDictionary<string, object> ProviderSpecificInfo { get; set; } = new Dictionary<string, object>();
    }
}
namespace SpongeEngine.SpongeLLM.Core.Models
{
    public class CompletionOptions
    {
        public string? ModelName { get; set; }
        public int? MaxTokens { get; set; }
        public float Temperature { get; set; } = 0.7f;
        public float TopP { get; set; } = 1.0f;
        public bool Stream { get; set; }
        public IList<string> StopSequences { get; set; } = new List<string>();
        public IDictionary<string, object> ProviderParams { get; set; } = new Dictionary<string, object>();
    }
}
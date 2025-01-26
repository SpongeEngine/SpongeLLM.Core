namespace SpongeEngine.LLMSharp.Core.Models
{
    public class TextCompletionRequest
    {
        public string ModelId { get; set; } = string.Empty;
        public string Prompt { get; set; } = string.Empty;
        public int? MaxTokens { get; set; }
        public float Temperature { get; set; } = 0.7f;
        public float TopP { get; set; } = 1.0f;
        public IList<string> StopSequences { get; set; } = new List<string>();
        public bool Stream { get; set; }
        public IDictionary<string, object> ProviderParameters { get; set; } = new Dictionary<string, object>();
    }

    public class TextCompletionResult
    {
        public string Text { get; set; } = string.Empty;
        public string ModelId { get; set; } = string.Empty;
        public TextCompletionTokenUsage TokenUsage { get; set; } = new();
        public string? FinishReason { get; set; }
        public TimeSpan GenerationTime { get; set; }
        public IDictionary<string, object> Metadata { get; set; } = new Dictionary<string, object>();
    }

    public class TextCompletionToken
    {
        public string Text { get; set; } = string.Empty;
        public string? FinishReason { get; set; }
        public int TokenCount { get; set; }
    }

    public class TextCompletionTokenUsage
    {
        public int PromptTokens { get; set; }
        public int CompletionTokens { get; set; }
        public int TotalTokens { get; set; }
    }
}
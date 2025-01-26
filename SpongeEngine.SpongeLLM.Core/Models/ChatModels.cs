namespace SpongeEngine.SpongeLLM.Core.Models
{
    public class ChatRequest
    {
        public string ModelId { get; set; } = string.Empty;
        public List<ChatMessage> Messages { get; set; } = new();
        public float Temperature { get; set; } = 0.7f;
        public float TopP { get; set; } = 1.0f;
        public int? MaxTokens { get; set; }
        public bool Stream { get; set; }
        public ChatSystemPrompt? SystemPrompt { get; set; }
        public IDictionary<string, object> ProviderParameters { get; set; }
            = new Dictionary<string, object>();
    }

    public class ChatMessage
    {
        public string Role { get; set; } = string.Empty;
        public string Content { get; set; } = string.Empty;
        public string? Name { get; set; }
        public IDictionary<string, object>? Metadata { get; set; }
    }

    public class ChatSystemPrompt
    {
        public string Content { get; set; } = string.Empty;
        public bool EnforceSystemPrompt { get; set; } = true;
    }

    public class ChatResponse
    {
        public ChatMessage Response { get; set; } = new();
        public string ModelId { get; set; } = string.Empty;
        public ChatTokenUsage TokenUsage { get; set; } = new();
        public string? FinishReason { get; set; }
        public TimeSpan GenerationTime { get; set; }
        public IDictionary<string, object> Metadata { get; set; }
            = new Dictionary<string, object>();
    }

    public class ChatToken
    {
        public string Text { get; set; } = string.Empty;
        public string? FinishReason { get; set; }
        public string Role { get; set; } = "assistant";
    }

    public class ChatTokenUsage
    {
        public int PromptTokens { get; set; }
        public int ResponseTokens { get; set; }
        public int TotalTokens { get; set; }
    }

    public class ChatModelConfig
    {
        public int MaxTotalTokens { get; set; }
        public int MaxPromptTokens { get; set; }
        public int MaxResponseTokens { get; set; }
        public IList<string> SupportedRoles { get; set; } = new List<string>();
        public bool SupportsSystemPrompt { get; set; }
        public IDictionary<string, object> ProviderSpecificConfig { get; set; }
            = new Dictionary<string, object>();
    }
}
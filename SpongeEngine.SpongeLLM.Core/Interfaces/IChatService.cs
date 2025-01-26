using SpongeEngine.SpongeLLM.Core.Models;

namespace SpongeEngine.SpongeLLM.Core.Interfaces
{
    /// <summary>
    /// Interface for chat-style interactions
    /// </summary>
    public interface IChatService
    {
        /// <summary>
        /// Performs chat completion with a list of messages
        /// </summary>
        Task<ChatResponse> ChatCompleteAsync(ChatRequest request, CancellationToken cancellationToken = default);

        /// <summary>
        /// Streams chat response tokens as they're generated
        /// </summary>
        IAsyncEnumerable<ChatToken> StreamChatAsync(ChatRequest request, CancellationToken cancellationToken = default);

        /// <summary>
        /// Gets chat model configuration and limitations
        /// </summary>
        Task<ChatModelConfig> GetModelConfigAsync(string modelId, CancellationToken cancellationToken = default);
    }
}
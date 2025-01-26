using SpongeEngine.SpongeLLM.Core.Models;

namespace SpongeEngine.SpongeLLM.Core.Interfaces
{
    public interface ITextCompletion {
        Task<TextCompletionResult> CompleteTextAsync(TextCompletionRequest request, CancellationToken cancellationToken = default);
    }
}
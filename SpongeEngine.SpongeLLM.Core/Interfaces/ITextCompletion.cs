using SpongeEngine.LLMSharp.Core.Models;

namespace SpongeEngine.LLMSharp.Core.Interfaces
{
    public interface ITextCompletion {
        Task<TextCompletionResult> CompleteTextAsync(TextCompletionRequest request, CancellationToken cancellationToken = default);
    }
}
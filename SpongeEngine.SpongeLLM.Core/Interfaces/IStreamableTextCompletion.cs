using SpongeEngine.LLMSharp.Core.Models;

namespace SpongeEngine.LLMSharp.Core.Interfaces
{
    public interface IStreamableTextCompletion {
        IAsyncEnumerable<TextCompletionToken> CompleteTextStreamAsync(TextCompletionRequest request, CancellationToken cancellationToken = default);
    }
}
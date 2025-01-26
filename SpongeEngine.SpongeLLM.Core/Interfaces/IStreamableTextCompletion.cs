using SpongeEngine.SpongeLLM.Core.Models;

namespace SpongeEngine.SpongeLLM.Core.Interfaces
{
    public interface IStreamableTextCompletion {
        IAsyncEnumerable<TextCompletionToken> CompleteTextStreamAsync(TextCompletionRequest request, CancellationToken cancellationToken = default);
    }
}
using Microsoft.Extensions.Logging;
using SpongeEngine.LLMSharp.Core.Exceptions;

namespace SpongeEngine.LLMSharp.Core.Utils
{
    public class RetryPolicy
    {
        private readonly int _maxRetriesAttempts;
        private readonly TimeSpan _delay;
        private readonly ILogger? _logger;

        public RetryPolicy(LLMClientBaseOptions clientBaseOptions)
        {
            _maxRetriesAttempts = clientBaseOptions.MaxRetryAttempts;
            _delay = clientBaseOptions.RetryDelay;
            _logger = clientBaseOptions.Logger;
        }

        public async Task<T> ExecuteAsync<T>(Func<Task<T>> operation, CancellationToken cancellationToken = default)
        {
            Exception? lastException = null;

            for (int attempt = 1; attempt <= _maxRetriesAttempts; attempt++)
            {
                try
                {
                    return await operation();
                }
                catch (Exception ex) when (ShouldRetry(ex))
                {
                    lastException = ex;
                    _logger?.LogWarning(ex, 
                        "Attempt {Attempt}/{MaxRetries} failed",
                        attempt, _maxRetriesAttempts);

                    if (attempt < _maxRetriesAttempts)
                    {
                        await Task.Delay(_delay, cancellationToken);
                    }
                }
            }

            throw new LlmSharpException("Operation failed after retries", innerException: lastException);
        }

        private bool ShouldRetry(Exception ex)
        {
            return ex is HttpRequestException || ex is TimeoutException || (ex is LlmSharpException llmEx && llmEx.StatusCode >= 500);
        }
    }
}
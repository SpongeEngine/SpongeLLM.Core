using System.Text.Json;
using System.Text.Json.Serialization;
using Microsoft.Extensions.Logging;
using Polly;
using Polly.CircuitBreaker;
using Polly.Retry;
using SpongeEngine.SpongeLLM.Core.Exceptions;

namespace SpongeEngine.SpongeLLM.Core
{
    public class LLMClientBaseOptions
    {
        public LLMClientBaseOptions(HttpClient? httpClient = null, ILogger? logger = null)
        {
            HttpClient = httpClient ?? new HttpClient();
            Logger = logger;

            // Initialize retry policy
            RetryPolicy = Policy
                .Handle<HttpRequestException>()
                .Or<TimeoutException>()
                .WaitAndRetryAsync(
                    MaxRetryAttempts,
                    retryAttempt => TimeSpan.FromSeconds(Math.Pow(2, retryAttempt)), // Exponential backoff
                    (exception, timeSpan, retryCount, context) =>
                    {
                        Logger?.LogWarning(
                            exception,
                            "Attempt {RetryCount} failed, waiting {TimeSpan}s before retry",
                            retryCount,
                            timeSpan.TotalSeconds);
                    });

            // Initialize circuit breaker
            CircuitBreaker = Policy
                .Handle<Exception>()
                .CircuitBreakerAsync(
                    CircuitBreakerThreshold,
                    CircuitBreakerDuration,
                    onBreak: (exception, duration) =>
                    {
                        Logger?.LogError(
                            exception,
                            "Circuit breaker opened for {Duration}s",
                            duration.TotalSeconds);
                    },
                    onReset: () =>
                    {
                        Logger?.LogInformation("Circuit breaker reset");
                    });
        }
        
        public HttpClient HttpClient { get; set; }
        public AsyncRetryPolicy RetryPolicy { get; set; }
        public AsyncCircuitBreakerPolicy CircuitBreaker { get; set; }
        
        // Basic Configuration
        public virtual string? ApiKey { get; set; }
        public virtual ILogger? Logger { get; set; }
        
        // HTTP Configuration
        public TimeSpan Timeout { get; set; } = TimeSpan.FromSeconds(30);
        public IDictionary<string, string> DefaultHeaders { get; set; } = new Dictionary<string, string>();
        public bool AllowAutoRedirect { get; set; } = true;
        
        // Resilience Configuration
        public int MaxRetryAttempts { get; set; } = 3;
        public TimeSpan RetryDelay { get; set; } = TimeSpan.FromSeconds(2);
        public int CircuitBreakerThreshold { get; set; } = 5;
        public TimeSpan CircuitBreakerDuration { get; set; } = TimeSpan.FromSeconds(30);
        
        public JsonSerializerOptions JsonSerializerOptions { get; set; } = new JsonSerializerOptions
        {
            DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
        };

        public virtual void Validate()
        {
            var errors = new Dictionary<string, string>();

            if (Timeout <= TimeSpan.Zero)
            {
                errors.Add(nameof(Timeout), "Timeout must be positive");
            }

            if (MaxRetryAttempts < 0)
            {
                errors.Add(nameof(MaxRetryAttempts), "Max retry attempts cannot be negative");
            }

            if (RetryDelay <= TimeSpan.Zero)
            {
                errors.Add(nameof(RetryDelay), "Retry delay must be positive");
            }

            if (CircuitBreakerThreshold <= 0)
            {
                errors.Add(nameof(CircuitBreakerThreshold), "Circuit breaker threshold must be positive");
            }

            if (CircuitBreakerDuration <= TimeSpan.Zero)
            {
                errors.Add(nameof(CircuitBreakerDuration), "Circuit breaker duration must be positive");
            }

            if (errors.Any())
            {
                throw new ValidationException(errors, "Configuration");
            }
        }
    }
}
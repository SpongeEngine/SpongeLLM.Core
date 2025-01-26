using Microsoft.Extensions.Logging;
using Polly;
using Polly.CircuitBreaker;
using Polly.Retry;

namespace SpongeEngine.LLMSharp.Core
{
    public abstract class LLMClientBase
    {
        public virtual LLMClientBaseOptions Options { get; }
        
        protected LLMClientBase(LLMClientBaseOptions options)
        {
            Options = options;
        }
    }
}
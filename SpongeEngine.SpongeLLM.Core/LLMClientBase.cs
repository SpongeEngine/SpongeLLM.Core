namespace SpongeEngine.SpongeLLM.Core
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
namespace SpongeEngine.LLMSharp.Core.Exceptions
{
    public class ProviderException : LlmSharpException
    {
        public ProviderException(
            string message,
            string provider,
            Exception? innerException = null)
            : base(message, innerException: innerException)
        {
        }
    }
}
namespace SpongeEngine.SpongeLLM.Core.Exceptions
{
    public class SpongeLLMException : Exception
    {
        public int? StatusCode { get; }
        public string? ResponseContent { get; }

        public SpongeLLMException(
            string message,
            int? statusCode = null,
            string? responseContent = null,
            Exception? innerException = null)
            : base(message, innerException)
        {
            StatusCode = statusCode;
            ResponseContent = responseContent;
        }
    }
}
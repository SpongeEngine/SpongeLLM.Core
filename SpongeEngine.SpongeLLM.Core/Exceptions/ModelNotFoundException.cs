namespace SpongeEngine.LLMSharp.Core.Exceptions
{
    public class ModelNotFoundException : LlmSharpException
    {
        public string ModelId { get; }

        public ModelNotFoundException(
            string modelId,
            string provider,
            string? message = null)
            : base(message ?? $"Model {modelId} not found")
        {
            ModelId = modelId;
        }
    }
}
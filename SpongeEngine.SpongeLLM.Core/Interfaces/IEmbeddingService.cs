using SpongeEngine.LLMSharp.Core.Models;

namespace SpongeEngine.LLMSharp.Core.Interfaces
{
    /// <summary>
    /// Interface for generating text embeddings
    /// </summary>
    public interface IEmbeddingService
    {
        /// <summary>
        /// Generates embeddings for the input text
        /// </summary>
        Task<EmbeddingResponse> CreateEmbeddingAsync(EmbeddingRequest request, CancellationToken cancellationToken = default);

        /// <summary>
        /// Creates embeddings for multiple texts in batch
        /// </summary>
        Task<BatchEmbeddingResponse> CreateEmbeddingsAsync(BatchEmbeddingRequest request, CancellationToken cancellationToken = default);

        /// <summary>
        /// Gets embedding model information including vector dimensions
        /// </summary>
        Task<EmbeddingModelInfo> GetModelInfoAsync(string modelId, CancellationToken cancellationToken = default);
    }
}
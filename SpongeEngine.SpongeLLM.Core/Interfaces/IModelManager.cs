using SpongeEngine.SpongeLLM.Core.Models;

namespace SpongeEngine.SpongeLLM.Core.Interfaces
{
    /// <summary>
    /// Interface for managing LLM models
    /// </summary>
    public interface IModelManager
    {
        /// <summary>
        /// Gets all available models from the provider
        /// </summary>
        Task<IReadOnlyList<ModelInfo>> GetAvailableModelsAsync(CancellationToken cancellationToken = default);

        /// <summary>
        /// Gets detailed information about a specific model
        /// </summary>
        Task<ModelInfo> GetModelInfoAsync(string modelId, CancellationToken cancellationToken = default);

        /// <summary>
        /// Gets currently loaded/active model if applicable
        /// </summary>
        Task<ModelInfo?> GetLoadedModelAsync(CancellationToken cancellationToken = default);

        /// <summary>
        /// Loads a specific model (if provider supports model loading)
        /// </summary>
        Task LoadModelAsync(string modelId, CancellationToken cancellationToken = default);

        /// <summary>
        /// Unloads the current model if one is loaded
        /// </summary>
        Task UnloadModelAsync(CancellationToken cancellationToken = default);
    }
}
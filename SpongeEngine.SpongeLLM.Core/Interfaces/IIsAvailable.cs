namespace SpongeEngine.SpongeLLM.Core.Interfaces
{
    public interface IIsAvailable
    {
        public Task<bool> IsAvailableAsync(CancellationToken cancellationToken = default);
    }
}
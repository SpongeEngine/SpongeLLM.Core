namespace SpongeEngine.SpongeLLM.Core.Interfaces
{
    public interface IStopInference { 
        Task<bool> StopInference();
    }
}
using SpongeEngine.SpongeLLM.Core.Exceptions;
using SpongeEngine.SpongeLLM.Core.Models;

namespace SpongeEngine.SpongeLLM.Core.Utils
{
    public static class ValidationHelper
    {
        public static void ValidateCompletionRequest(TextCompletionRequest request)
        {
            var errors = new Dictionary<string, string>();

            if (string.IsNullOrEmpty(request.ModelId))
                errors.Add("ModelId", "Model ID must be specified");

            if (string.IsNullOrEmpty(request.Prompt))
                errors.Add("Prompt", "Prompt cannot be empty");

            if (request.Temperature < 0 || request.Temperature > 1)
                errors.Add("Temperature", "Temperature must be between 0 and 1");

            if (request.TopP < 0 || request.TopP > 1)
                errors.Add("TopP", "TopP must be between 0 and 1");

            if (errors.Any())
            {
                throw new ValidationException(errors, "Validation");
            }
        }

        public static void ValidateChatRequest(ChatRequest request)
        {
            var errors = new Dictionary<string, string>();

            if (string.IsNullOrEmpty(request.ModelId))
            {
                errors.Add("ModelId", "Model ID must be specified");
            }

            if (!request.Messages.Any())
            {
                errors.Add("Messages", "At least one message is required");
            }

            if (request.Messages.Any(m => string.IsNullOrEmpty(m.Role)))
            {
                errors.Add("Message.Role", "Message role cannot be empty");
            }

            if (errors.Any())
            {
                throw new ValidationException(errors, "Validation");
            }
        }
    }
}
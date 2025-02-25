﻿namespace SpongeEngine.SpongeLLM.Core.Exceptions
{
    public class ValidationException : SpongeLLMException
    {
        public IDictionary<string, string> ValidationErrors { get; }

        public ValidationException(
            IDictionary<string, string> errors,
            string provider)
            : base("Validation failed")
        {
            ValidationErrors = errors;
        }
    }
}
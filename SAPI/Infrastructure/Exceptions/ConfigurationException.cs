using Infrastructure.Constants;
namespace Infrastructure.Exceptions
{
    public class ConfigurationException : InvalidOperationException
    {
        public ConfigurationException(string key) : base(String.Format(InfrastructureErrorMessages.MissingConfigurationKey, key)) { }
    }
}

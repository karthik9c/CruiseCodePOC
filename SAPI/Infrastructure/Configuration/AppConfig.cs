using Infrastructure.Constants;
using Infrastructure.Exceptions;
using Microsoft.Extensions.Configuration;

namespace Infrastructure.Configuration
{
    public class AppConfig
    {
        private readonly IConfiguration _configuration;

        public AppConfig(IConfiguration configuration)
        {
            _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
        }

        public string IssuerSecretKey => GetConfigValue(ConfigKeys.IssuerSecretKey);

        private string GetConfigValue(string key)
        {
            return _configuration[key] ?? throw new ConfigurationException(key);
        }
    }

    
}

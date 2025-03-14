using Azure.Core;
using Azure.Identity;
using Microsoft.ApplicationInsights.Channel;
using Microsoft.ApplicationInsights.Extensibility;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Logging
{
    public class CustomTelemetryInitializer : ITelemetryInitializer
    {

        public void Initialize(ITelemetry telemetry)
        {
            // Implement any custom telemetry initialization if needed
        }
    }
}

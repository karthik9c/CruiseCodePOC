using Microsoft.ApplicationInsights.DataContracts;
using Microsoft.ApplicationInsights;
using System.Net;
using Newtonsoft.Json;
using Infrastructure.APIStandard.Models.Enum;
using Utlities;
using API.Helper;

namespace API.Middleware
{
    public class ErrorHandlingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly TelemetryClient _telemetryClient;

        public ErrorHandlingMiddleware(RequestDelegate next, TelemetryClient telemetryClient)
        {
            _next = next;
            _telemetryClient = telemetryClient;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
                // Check for 401 Unauthorized status code
                if (context.Response.StatusCode == (int)HttpStatusCode.Unauthorized)
                {
                    await ErrorHandlingHelper.HandleErrorAsync(context, ErrorCodes.UNAUTHORIZED);
                }
            }
            catch (Exception ex)
            {
                //_telemetryClient.TrackException(new ExceptionTelemetry(ex));

                await ErrorHandlingHelper.HandleErrorAsync(context, ErrorCodes.INTERNAL_SERVER_ERROR);
            }
        }

        private static Task HandleUnauthorizedAsync(HttpContext context)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
            var result = JsonConvert.SerializeObject(new
            {
                error = EnumHelper.GetEnumKey(ErrorCodes.UNAUTHORIZED),
                errorMessage = EnumHelper.GetDescription(ErrorCodes.UNAUTHORIZED)
            });
            return context.Response.WriteAsync(result);
        }

        private static Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
            var result = JsonConvert.SerializeObject(new
            {
                error = EnumHelper.GetEnumKey(ErrorCodes.INTERNAL_SERVER_ERROR),
                errorMessage = EnumHelper.GetDescription(ErrorCodes.INTERNAL_SERVER_ERROR)
            });
            return context.Response.WriteAsync(result);
        }

    }
}

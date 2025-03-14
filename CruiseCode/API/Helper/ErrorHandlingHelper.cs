using API.Constants;
using Infrastructure.APIStandard.Models.Enum;
using Newtonsoft.Json;
using System.Net;
using Utlities;

namespace API.Helper
{
    public static class ErrorHandlingHelper
    {
        public static Task HandleErrorAsync(HttpContext context, ErrorCodes errorCode)
        {
            context.Response.ContentType = ContentTypeConstant.APPLICATION_JSON;
            context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
            var result = JsonConvert.SerializeObject(new
            {
                error = EnumHelper.GetEnumKey(errorCode),
                errorMessage = EnumHelper.GetDescription(errorCode)
            });
            return context.Response.WriteAsync(result);
        }
    }
}

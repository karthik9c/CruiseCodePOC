using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.APIStandard.Models.Enum
{
    public enum ErrorCodes
    {
        [Description("Missing or invalid productId in the request")]
        INVALID_PRODUCT_ID = 1,

        [Description("Either Key is invalid or You didn't send the API Key in the Authorization header to an endpoint that requires authentication")]
        UNAUTHORIZED = 2,

        [Description("An unexpected error occurred on the server")]
        INTERNAL_SERVER_ERROR = 3
    }
}

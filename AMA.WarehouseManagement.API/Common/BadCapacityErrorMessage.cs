using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace AMA.WarehouseManagement.API.Common
{
    public class BadCapacityErrorMessage : BadRequestObjectResult
    {
        public BadCapacityErrorMessage():base(new {ErrorCode=StatusCodes.Status400BadRequest,Message= "Product capacity error !" })
        {
        }
    }
}


using Microsoft.AspNetCore.Mvc;

namespace AMA.WarehouseManagement.API.Common
{
    public class BadQuantityErrorMessage : BadRequestObjectResult 
    {
        public BadQuantityErrorMessage():base(new {ErrorCode=StatusCodes.Status400BadRequest,Message= "Product quantity error !" })
        {
        }
        
    }
}

using Microsoft.AspNetCore.Http.HttpResults;

namespace AMA.WarehouseManagement.API.Common
{
    public class BadCapacityErrorMessage : IStatusCodeHttpResult
    {
        public string Message { get; }
        public BadCapacityErrorMessage()
        {
            Message = "Product capacity error";
        }

        public int? StatusCode => StatusCodes.Status400BadRequest;
    }
}

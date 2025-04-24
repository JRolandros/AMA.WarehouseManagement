namespace AMA.WarehouseManagement.API.Common
{
    public class BadQuantityErrorMessage : IStatusCodeHttpResult
    {
        public string Message { get; } 
        public BadQuantityErrorMessage()
        {
            Message = "Product quantity error !";
        }
        public int? StatusCode => StatusCodes.Status400BadRequest;
    }
}

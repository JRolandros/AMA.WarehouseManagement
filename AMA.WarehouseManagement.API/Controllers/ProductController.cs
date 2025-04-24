using AMA.WarehouseManagement.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace AMA.WarehouseManagement.API.Controllers
{
    public class ProductController : ControllerBase
    {
        private readonly IProductService _service;
        public ProductController(IProductService productService)
        {
            _service = productService;
        }


        public object AddProductStock(int productId, int v)
        {
            throw new NotImplementedException();
        }

        public object DispatchProduct(int v1, int v2)
        {
            throw new NotImplementedException();
        }

        public object GetProducts(int v)
        {
            throw new NotImplementedException();
        }

        public object SetProductCapacity(int v1, int v2)
        {
            throw new NotImplementedException();
        }
    }
}

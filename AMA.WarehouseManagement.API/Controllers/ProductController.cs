using AMA.WarehouseManagement.API.Common;
using AMA.WarehouseManagement.Application.Models;
using AMA.WarehouseManagement.Application.Services;
using AMA.WarehouseManagement.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace AMA.WarehouseManagement.API.Controllers

{
    [ApiController]
    [Route("api/products")]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _service;
        public ProductController(IProductService productService)
        {
            _service = productService;
        }

        [HttpGet("getproducts")]
        public IActionResult GetProducts(int quantity)
        {
            if (quantity <= 0)
            {
                return new BadQuantityErrorMessage();
            }

            var products = _service.GetQuantityProducts(x => x.Quantity > quantity);
            var warehouseEntities= products.Select(x => new WarehouseEntity { ProductId = x.ProductId, Quantity = x.Quantity });

            return new OkObjectResult(warehouseEntities);
        }

        [HttpPost("addproductstock")]
        public IActionResult AddProductStock(int productId, int qty)
        {
            var qtyProduct=_service.GetQuantityProducts(x=>x.ProductId == productId).FirstOrDefault();
            var cptyProduct=_service.GetCapacityProducts(x=>x.ProductId==productId).FirstOrDefault();

            if(qtyProduct==null || cptyProduct==null || qty<=0 ||qtyProduct.Quantity+qty>cptyProduct.Capacity )
                return new BadQuantityErrorMessage();

            _service.SetProductQuantity(productId, qtyProduct.Quantity + qty);

            return new OkResult();

        }

        [HttpPost("dispatchproduct")]
        public IActionResult DispatchProduct(int productId, int qty)
        {
            var qtyProduct = _service.GetQuantityProducts(x => x.ProductId == productId).FirstOrDefault();

            if (qtyProduct == null || qty <= 0 || qtyProduct.Quantity<qty)
                return new BadQuantityErrorMessage();

            _service.SetProductQuantity(productId, qtyProduct.Quantity-qty);

            return new OkResult();
        }

        [HttpPost("setproductcapacity")]
        public IActionResult SetProductCapacity(int productId, int capacity)
        {
            var qtyProduct = _service.GetQuantityProducts(x => x.ProductId == productId).FirstOrDefault();

            if (qtyProduct == null || capacity <= 0)
                return new BadQuantityErrorMessage();

            if (qtyProduct.Quantity > capacity)
                return new BadCapacityErrorMessage();

            _service.SetProductCapacity(productId, capacity);

            return new OkResult();
        }


        [HttpGet("getpage")]
        public IActionResult GetPage(int offset, int limit)
        {
            IEnumerable<Product> products = _service.GetProductRange(0, 0); // Normally filtring function should execute in the repository side and send to data base via ORM for performance purpose.

            // But I will do it here for the example because the focus is on the web page not on the backend.
            if (limit> 0) //Get all data
               products= products.Skip(offset).Take(limit);
            var dtos = products.Select(x => new ProductDto
            {
                ProductId = x.ProductId,
                Price = x.Price,
                ProductCategory = x.ProductCategory,
                ProductName = x.ProductName,
                ProductDescription = x.ProductDescription,

            });

            return new OkObjectResult(dtos);

        }
    }
}

using AMA.WarehouseManagement.API.Common;
using AMA.WarehouseManagement.Application.Models;
using AMA.WarehouseManagement.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace AMA.WarehouseManagement.API.Controllers

{
    [Route("api/Product")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _service;
        public ProductController(IProductService productService)
        {
            _service = productService;
        }

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

        public IActionResult AddProductStock(int productId, int qty)
        {
            var qtyProduct=_service.GetQuantityProducts(x=>x.ProductId == productId).FirstOrDefault();
            var cptyProduct=_service.GetCapacityProducts(x=>x.ProductId==productId).FirstOrDefault();

            if(qtyProduct==null || cptyProduct==null || qty<=0 ||qtyProduct.Quantity+qty>cptyProduct.Capacity )
                return new BadQuantityErrorMessage();

            _service.SetProductQuantity(productId, qtyProduct.Quantity + qty);

            return new OkResult();

        }

        public IActionResult DispatchProduct(int productId, int qty)
        {
            var qtyProduct = _service.GetQuantityProducts(x => x.ProductId == productId).FirstOrDefault();

            if (qtyProduct == null || qty <= 0 || qtyProduct.Quantity<qty)
                return new BadQuantityErrorMessage();

            _service.SetProductQuantity(productId, qtyProduct.Quantity-qty);

            return new OkResult();
        }

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
    }
}

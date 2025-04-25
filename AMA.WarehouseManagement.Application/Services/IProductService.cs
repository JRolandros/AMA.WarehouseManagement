using AMA.WarehouseManagement.Application.Models;
using AMA.WarehouseManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AMA.WarehouseManagement.Application.Services
{
    public interface IProductService
    {
        IEnumerable<CapacityProduct> GetCapacityProducts(Expression<Func<CapacityProduct, bool>> expression);
        IEnumerable<QuantityProduct> GetQuantityProducts(Expression<Func<QuantityProduct, bool>> expression);
        void SetProductQuantity(int productId, int qty);
        void SetProductCapacity(int productId, int capacity);
        IEnumerable<Product> GetProductRange(int offset, int limit);
    }
}

using AMA.WarehouseManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AMA.WarehouseManagement.Application.Services
{
    public class ProductService : IProductService
    {
        public IEnumerable<CapacityProduct> GetCapacityProducts(Expression<Func<CapacityProduct, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<QuantityProduct> GetQuantityProducts(Expression<Func<QuantityProduct, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public void SetProductCapacity(int productId, int capacity)
        {
            throw new NotImplementedException();
        }

        public void SetProductQuantity(int productId, int expectedQty)
        {
            throw new NotImplementedException();
        }
    }
}

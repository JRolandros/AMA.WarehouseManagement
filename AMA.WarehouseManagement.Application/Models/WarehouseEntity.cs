using AMA.WarehouseManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMA.WarehouseManagement.Application.Models
{
    public class WarehouseEntity
    {
        public WarehouseEntity()
        {
            
        }

        //public WarehouseEntity(QuantityProduct product) // If it is a large product, it could be interesting to use AutoMapper instead of this constructor
        //{
        //    Quantity=product.Quantity;
        //    ProductId=product.ProductId;
        //}
        public int Quantity { get; set; }
        public int ProductId { get; set; }

    }
}

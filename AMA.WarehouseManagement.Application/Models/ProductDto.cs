using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMA.WarehouseManagement.Application.Models
{
    public class ProductDto
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }=string.Empty;
        public string ProductDescription { get; set; } = string.Empty;
        public string ProductCategory { get; set; }=string.Empty ;
        public double Price { get; set; }
    }
}

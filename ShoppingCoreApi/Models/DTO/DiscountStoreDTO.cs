using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingCoreApi.Models.DTO
{
    public class DiscountStoreDTO
    {
        public int DiscountStoreId { get; set; }
        public string Sku { get; set; }
        public string Price { get; set; }
        public string Discount { get; set; }
    }
}

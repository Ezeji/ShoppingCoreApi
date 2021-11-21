using System;
using System.Collections.Generic;

#nullable disable

namespace ShoppingCoreData.Models
{
    public partial class DiscountStore
    {
        public int DiscountStoreId { get; set; }
        public string Sku { get; set; }
        public string Price { get; set; }
        public string Discount { get; set; }
    }
}

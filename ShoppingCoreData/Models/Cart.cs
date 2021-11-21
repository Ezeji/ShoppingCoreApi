using System;
using System.Collections.Generic;

#nullable disable

namespace ShoppingCoreData.Models
{
    public partial class Cart
    {
        public int CartId { get; set; }
        public string ItemsSelected { get; set; }
        public string ShoppingCode { get; set; }
    }
}

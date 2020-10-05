using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VendingMachine.Data;

namespace VendingMachine.Models
{
    public class ProductsViewModel
    {
        public List<Product> Products { get; set; }
        public int TotalCount { get; set; }
    }
}

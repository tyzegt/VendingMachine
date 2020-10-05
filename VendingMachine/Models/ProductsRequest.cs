using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VendingMachine.Models
{
    public class ProductsRequest
    {
        public int PageNumber { get; set; }
        public int ItemsPerPage { get; set; }
        public int CategoryId { get; set; }
    }
}

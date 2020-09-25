using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VendingMachine.Data
{
    public class ProductCategory
    {
        public int Id { get; set; }

        /// <summary>
        /// Наименование категории
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Вес категории (для сортировки)
        /// </summary>
        public int Weight { get; set; }
    }
}

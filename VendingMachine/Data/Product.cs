using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VendingMachine.Data
{
    public class Product
    {
        public int Id { get; set; }

        /// <summary>
        /// Наименование товара
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Описание товара
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Идентификатор категории товара
        /// </summary>
        public int CategoryId { get; set; }

        /// <summary>
        /// Ссылка на фото
        /// </summary>
        public string PhotoUrl { get; set; }

        /// <summary>
        /// Объект категории товара
        /// </summary>
        public ProductCategory Category { get; set; }

        /// <summary>
        /// Цена товара
        /// </summary>
        public int Price { get; set; }

        /// <summary>
        /// Количество товара
        /// </summary>
        public int Count { get; set; }

        /// <summary>
        /// Доступность товара
        /// </summary>
        public bool IsAvailable { get; set; }

        /// <summary>
        /// Вес товара (для сортировки)
        /// </summary>
        public int Weight { get; set; } = 1000;
    }
}

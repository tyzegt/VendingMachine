using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace VendingMachine.Data
{
    public class Coin
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        /// <summary>
        /// Номинал монеты
        /// </summary>
        public int Value { get; set; }

        /// <summary>
        /// Количество монет в автомате
        /// </summary>
        public int Count { get; set; }

        /// <summary>
        /// Доступность монеты для приёма автоматом
        /// </summary>
        public bool IsAvailable { get; set; }
    }
}

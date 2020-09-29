using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VendingMachine.Constants;
using VendingMachine.Data;
using VendingMachine.Services;

namespace VendingMachine.Controllers
{
    [Route("[controller]/[action]")]
    public class CoinsController : ControllerBase
    {
        private readonly ICoinService _coinService;

        public CoinsController(ICoinService coinService)
        {
            _coinService = coinService;
        }

        /// <summary>
        /// Возвращает все возможные виды монет
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public List<Coin> GetCoins()
        {
            return _coinService.GetCoins();
        }

        /// <summary>
        /// Внести монету в автомат
        /// </summary>
        /// <param name="coinId">Id монеты</param>
        [HttpPost]
        public int DepositCoin(int coinId)
        {
            return _coinService.DepositCoin(coinId);
        }

        /// <summary>
        /// Возвращает текущую сумму внесённых монет
        /// </summary>
        [HttpGet]
        public int GetSum()
        {
            return _coinService.GetSum();
        }

        /// <summary>
        /// Вернуть сдачу
        /// </summary>
        [HttpPost]
        public List<Coin> ReturnChange()
        {
            return _coinService.ReturnChange();
        }
    }
}

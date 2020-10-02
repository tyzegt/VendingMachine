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

        /// <summary>
        /// Редактирование монеты
        /// </summary>
        [HttpPost]
        public IActionResult EditCoin([FromBody] Coin editedCoin)
        {
            var result = _coinService.EditCoin(editedCoin);
            if (result) return Ok();
            else return BadRequest();
        }

        /// <summary>
        /// Удаление монеты
        /// </summary>
        [HttpPost]
        public IActionResult DeleteCoin([FromBody] Coin coin)
        {
            var result = _coinService.DeleteCoin(coin);
            if (result) return Ok();
            else return BadRequest();
        }


        /// <summary>
        /// Добавление монеты
        /// </summary>
        [HttpPost]
        public IActionResult AddCoin([FromBody] Coin coin)
        {
            var result = _coinService.AddCoin(coin);
            if (result) return Ok();
            else return BadRequest();
        }
    }
}

﻿using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VendingMachine.Data;

namespace VendingMachine.Services
{
    public class CoinService : ICoinService
    {
        private readonly ApplicationDbContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public CoinService(ApplicationDbContext context, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor;
        }

        public void ClearSum()
        {
            _httpContextAccessor.HttpContext.Session.SetInt32("StoredSum", 0);
        }

        public bool DeleteCoin(Coin coinToDelete)
        {
            var coin = _context.Coins.FirstOrDefault(x => x.Id == coinToDelete.Id);
            if (coin == null) return false;
            _context.Remove(coin);
            _context.SaveChanges();
            return true;
        }
        public bool AddCoin(Coin coin)
        {
            var sameCoin = _context.Coins.FirstOrDefault(x => x.Value == coin.Value);
            if (sameCoin != null || coin.Value <= 0) return false;
            _context.Add(new Coin() 
            { 
                Count = coin.Count, IsAvailable = coin.IsAvailable, Value = coin.Value 
            });
            _context.SaveChanges();
            return true;
        }

        public int DepositCoin(int coinId)
        {
            var coin = _context.Coins.FirstOrDefault(x => x.Id == coinId);
            if (coin != null && coin.IsAvailable)
            {
                coin.Count++;
                _context.SaveChanges();
                IncreaseSum(coin.Value);
            }
            return GetSum();
        }

        public bool EditCoin(Coin editedCoin)
        {
            var coin = _context.Coins.FirstOrDefault(x => x.Id == editedCoin.Id);
            if (coin == null) return false;
            coin.IsAvailable = editedCoin.IsAvailable;
            coin.Value = editedCoin.Value;
            coin.Count = editedCoin.Count;
            _context.SaveChanges();
            return true;
        }

        public List<Coin> GetCoins()
        {
            return _context.Coins.OrderBy(x => x.Value).ToList();
        }

        public int GetSum()
        {
            return _httpContextAccessor.HttpContext.Session.GetInt32("StoredSum") ?? 0;
        }

        public void IncreaseSum(int value)
        {
            _httpContextAccessor.HttpContext.Session.SetInt32("StoredSum", GetSum() + value);
        }

        public void Purchase(int sum)
        {
            _httpContextAccessor.HttpContext.Session.SetInt32("StoredSum", GetSum() - sum);
        }

        public List<Coin> ReturnChange()
        {
            var sum = GetSum();
            var change = new List<Coin>();
            var coins = GetCoins().OrderByDescending(x => x.Value);

            foreach (var coin in coins)
            {
                var resultCoin = new Coin() { Count = 0, Value = coin.Value };
                while (sum - coin.Value >= 0 && coin.Count > 0)
                {
                    resultCoin.Count++;
                    coin.Count--;
                    sum -= coin.Value;
                }
                change.Add(resultCoin);
            }
            _context.SaveChanges();
            ClearSum();

            return change;
        }
    }
}

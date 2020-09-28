using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VendingMachine.Data;

namespace VendingMachine.Services
{
    public interface ICoinService
    {
        int DepositCoin(int coinId);
        int GetSum();
        List<Coin> ReturnChange();
        void IncreaseSum(int value);
        void ClearSum();
        List<Coin> GetCoins();
        void Purchase(int sum);
    }
}

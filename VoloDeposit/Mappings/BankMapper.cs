using EntitiesServices.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VoloDeposit.ViewModel;

namespace VoloDeposit.Mappings
{
    public static class BankMapper
    {
        public static BankViewModel To_BankViewModel(this Bank bank)
        {
            BankViewModel VMBank = new BankViewModel()
            {
                Id = bank.BankID,
                Name = bank.BankName,
                Deleted = bank.Deleted
            };
            return VMBank;
        }
        public static IEnumerable<BankViewModel> To_BankViewModel(this IEnumerable<Bank> banks)
        {
            List<BankViewModel> bankVM = new List<BankViewModel>();
            foreach (var item in banks)
            {
                bankVM.Add(item.To_BankViewModel());
            }
            return bankVM;
        }
    }
}

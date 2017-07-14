using DepositTypeServices;
using EntitiesServices.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VoloDeposit.ViewModel.Deposit;

namespace VoloDeposit.Mappings
{
    public static class DepositMapper
    {
        public static Deposit To_Deposit_Create_ViewModel(this DepositCreateViewModel deposit)
        {
            Deposit depositVM = new Deposit()
            {
                DepositID = deposit.DepositID,
                BankID=deposit.BankID,
                DepositorID=deposit.DepositorID,
                DepositType=deposit.DepositType,
                Amount=deposit.Amount,
                DepositDated=deposit.DepositDated,
                DepositYear=deposit.DepositYear,     
            };
            return depositVM;
        }
        public static DepositIndexViewModel To_BankViewModel(this Deposit deposit)
        {
            ListDepositType ltd = new ListDepositType();
            DepositIndexViewModel VMDeposit = new DepositIndexViewModel()
            {
                Amount = deposit.Amount,
                BankID = deposit.BankID,
                DepositID = deposit.DepositID,
                DepositDated = deposit.DepositDated,
                DepositorID = deposit.DepositorID,
                DepositYear = deposit.DepositYear,
                Bank = deposit.Bank,
                Person = deposit.Person,
                DepositType = ltd.GetType(deposit.DepositType)
          };
            return VMDeposit;
        }

        public static IEnumerable<DepositIndexViewModel> To_Deposit_Index_ViewModel(this IEnumerable<Deposit> deposit)
        {
            List<DepositIndexViewModel> depoVM = new List<DepositIndexViewModel>();
            foreach (var item in deposit)
            {
                depoVM.Add(item.To_BankViewModel());
            }
            return depoVM;
        }
    }
}
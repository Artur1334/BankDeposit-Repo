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
        public static Deposit To_Deposit_Create_ViewModel(this DepositViewModel deposit)
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

        internal static Deposit To_Deposit_Create_ViewModel(Deposit deposit)
        {
            throw new NotImplementedException();
        }
    }
}
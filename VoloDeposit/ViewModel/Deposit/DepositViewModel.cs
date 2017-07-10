using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VoloDeposit.ViewModel.Deposit
{
    public class DepositViewModel
    {
        public int DepositID { get; set; }
        public int BankID { get; set; }
        public int DepositorID { get; set; }
        public byte DepositType { get; set; }
        public decimal Amount { get; set; }
        public Nullable<System.DateTime> DepositDated { get; set; }
        public Nullable<byte> DepositYear { get; set; }
    }
}
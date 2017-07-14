using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace VoloDeposit.ViewModel.Deposit
{
    public class DepositCreateViewModel
    {

        public int DepositID { get; set; }
        public int BankID { get; set; }
        public int DepositorID { get; set; }
        [Required(ErrorMessage = "You must choose a deposit type"),]
        public byte DepositType { get; set; }
        [Required(ErrorMessage = "You must specify the amount"),]
        public decimal Amount { get; set; }
        public Nullable<System.DateTime> DepositDated { get; set; }
        [Required(ErrorMessage = "How many years do you want to deposit"),]
        public Nullable<byte> DepositYear { get; set; }
    }
}
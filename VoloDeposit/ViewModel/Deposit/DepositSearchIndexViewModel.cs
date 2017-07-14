using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VoloDeposit.ViewModel.Deposit
{
    public class DepositSearchIndexViewModel
    {

        public string DepositType { get; set; }

        public decimal Amount { get; set; }

        public DateTime StartDate { get; set; }

        public string BankName { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }

    }
}
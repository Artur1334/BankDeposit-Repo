using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VoloDeposit.ViewModel;
using VoloDeposit.ViewModel.Depositors;

namespace VoloDeposit.Areas.Admin.ViewModel
{
    public class SearchViewModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string BankName { get; set; }
        public string DepositType { get; set; }
        public decimal? MinAmount { get; set; }
        public decimal? MaxAmount { get; set; }
        public DateTime? MinStartDate { get; set; }
        public DateTime? MaxStartDate { get; set; }
        public virtual IEnumerable<BankViewModel> Banks { get; set; }

        public virtual IEnumerable<Depositor_Create_ViewModel> Depositors { get; set; }

    }
}
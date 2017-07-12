using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VoloDeposit.Areas.Admin.ViewModel
{
    public class SearchResultsViewModel
    {
        public string FirstName { get; set; }
       
        public string LastName { get; set; }
        public string DepositType { get; set; }
        public string BankName { get; set; }
    }
}
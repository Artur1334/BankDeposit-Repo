using DepositTypeServices;
using EntitiesServices.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VoloDeposit.Areas.Admin.ViewModel
{
    public class Deposit_IndexViewModel
    {
        public int DepositID { get; set; }
        public int BankID { get; set; }
        public int DepositorID { get; set; }
        public string DepoType { get; set; }
        public decimal Amount { get; set; }
        public Nullable<System.DateTime> DepositDated { get; set; }
        public Nullable<byte> DepositYear { get; set; }
        public virtual Bank Bank { get; set; }
        public virtual Person Person { get; set; }
      
    }
}
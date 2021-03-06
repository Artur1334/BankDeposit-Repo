//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace EntitiesServices.Entities
{
    using System;
    using System.Collections.Generic;
    
    public partial class Deposit
    {
        public int DepositID { get; set; }
        public int BankID { get; set; }
        public int DepositorID { get; set; }
        public byte DepositType { get; set; }
        public decimal Amount { get; set; }
        public Nullable<System.DateTime> DepositDated { get; set; }
        public Nullable<byte> DepositYear { get; set; }
    
        public virtual Bank Bank { get; set; }
        public virtual Person Person { get; set; }
    }
}

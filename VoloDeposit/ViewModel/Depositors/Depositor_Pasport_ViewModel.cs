using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace VoloDeposit.ViewModel.Depositors
{
    public class Depositor_Pasport_ViewModel
    {
       
        [Required(ErrorMessage = "Bank name is REQUIRED fild"),]
        [RegularExpression(@"[a-zA-Z]{2}\d{7}", ErrorMessage = "Must be under 2 characters and 7 digits`Like(Ak1234567)")]
        public string Pasport { get; set; }
    }
}
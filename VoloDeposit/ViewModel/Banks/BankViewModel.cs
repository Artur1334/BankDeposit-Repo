using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace VoloDeposit.ViewModel
{
  
        public class BankViewModel
        {
            public int Id { get; set; }
            [Required(ErrorMessage = "Bank name is REQUIRED fild")]
            [MaxLength(50,ErrorMessage = "Must be under 50 characters")]
            [Display(Name = "Bank name")]
            public string Name { get; set; }
        //public string  Icon { get; set; }

        //  public Nullable<bool> Deleted { get; set; }

    }
    }

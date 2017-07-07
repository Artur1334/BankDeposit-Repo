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
            [MaxLength(50)]
            [Display(Name = "Bank name")]
            public string Name { get; set; }
            //public Nullable<bool> Deleted { get; set; }
        }
    }

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
        [MinLength(9, ErrorMessage = "Минимальная длина пароля 5 символов")]
        [MaxLength(9, ErrorMessage = "Максимальная длина пароля 20 символов")]
        public string Pasport { get; set; }
    }
}
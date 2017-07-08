using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace VoloDeposit.ViewModel.Depositors
{
    public class Depositor_Create_ViewModel
    {
       
        public int PersonId { get; set; }
        [Required(ErrorMessage = "Bank name is required fild"),]
        [MaxLength(50)]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Bank name is required fild"),]
        [MaxLength(50)]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Bank name is required fild"),]
        public System.DateTime BirthDay { get; set; }
        [Required(ErrorMessage = "Bank name is required fild"),]
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Pasport { get; set; }
    }
}
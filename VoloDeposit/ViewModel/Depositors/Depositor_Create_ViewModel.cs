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
        [Required(ErrorMessage = "FirstName is required fild"),]
        [MaxLength(50,ErrorMessage = "Must be under 50 characters")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "LastName is required fild"),]
        [MaxLength(50, ErrorMessage = "Must be under 50 characters")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "BirthDay is required fild"),]
        public System.DateTime BirthDay { get; set; }
        [Required(ErrorMessage = "Email  is required fild"),]
        [RegularExpression(@"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}", ErrorMessage = "Invalid Email address")]
        public string Email { get; set; }
        [RegularExpression(@"^[0-9]{9}$", ErrorMessage = "Phone number must be 9 digits")]
        public string Phone { get; set; }
        public string Pasport { get; set; }
    }
}
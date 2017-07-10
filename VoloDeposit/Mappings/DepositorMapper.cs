using EntitiesServices.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VoloDeposit.ViewModel.Depositors;

namespace VoloDeposit.Mappings
{
    public static class DepositorMapper
    {
        public static Person To_Depositor_Create_ViewModel(this Depositor_Create_ViewModel depositor)
        {
           Person depositorVM = new Person()
            { PersonId= depositor.PersonId,
             FirstName=depositor.FirstName,
             LastName=depositor.LastName,
             BirthDay=depositor.BirthDay,
             Email=depositor.Email,
             Phone=depositor.Phone,
              Pasport=depositor.Pasport
            };
            return depositorVM;
        }
    }
}
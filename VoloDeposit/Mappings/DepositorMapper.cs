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
        //public static Depositor_Pasport_ViewModel To_BankViewModel(this Person person)
        //{
        //    Depositor_Pasport_ViewModel VMpasport = new Depositor_Pasport_ViewModel()
        //    {
        //        Pasport = person.Pasport
        //    };
        //    return VMpasport;
        //}
        //public static Person ComparePasport(this Depositor_Pasport_ViewModel pasport)
        //{

        //    return
        //}
        public static Depositor_Create_ViewModel To_Depositor_CreateEdit_ViewModel(this Person depositor)
        {
            Depositor_Create_ViewModel depositorVM = new Depositor_Create_ViewModel()
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
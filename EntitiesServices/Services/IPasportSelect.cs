using EntitiesServices.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntitiesServices.Services
{
   public interface IPasportSelect:IDisposable
    {
        Person SelectPasport(string pasport);
    }
}

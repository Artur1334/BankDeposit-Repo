using EntitiesServices.Entities;
using EntitiesServices.Services;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfrastructureData
{
    public class PasportSelect : IPasportSelect
    {
        private ArmDepositEntities DbEntitiesContext;
        private DbSet<Person> _dbset;
        public PasportSelect()
        {
            this.DbEntitiesContext = new ArmDepositEntities();
            this._dbset = DbEntitiesContext.Set<Person>();
        }
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

     

        public Person SelectPasport(string pasport)
        {
            try
            {
                return _dbset.Single((d => d.Pasport == pasport));
            }
            catch
            {
                return null;
            }
           
        }
    }
}

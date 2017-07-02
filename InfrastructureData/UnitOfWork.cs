using EntitiesServices.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfrastructureData
{
   public class UnitOfWork:IDisposable
    {
        private ArmDepositEntities DbEntitiesContext;
        private Dictionary<string, object> repositories;
        public UnitOfWork()
        {
            DbEntitiesContext = new ArmDepositEntities();
        }
        public int Save()
        {
            return DbEntitiesContext.SaveChanges();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        private void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (DbEntitiesContext != null)
                {
                    DbEntitiesContext.Dispose();
                    DbEntitiesContext = null;
                }
            }
        }
        public GenericRepository<T> GenericRepository<T>() where T : class
        {
            if (repositories == null)
            {
                repositories = new Dictionary<string, object>();
            }

            var type = typeof(T).Name;

            if (!repositories.ContainsKey(type))
            {
                var repositoryType = typeof(GenericRepository<T>);
                var repositoryInstance = Activator.CreateInstance(repositoryType.MakeGenericType(typeof(T)), DbEntitiesContext);
                repositories.Add(type, repositoryInstance);
            }
            return (GenericRepository<T>)repositories[type];
        }
    }
}

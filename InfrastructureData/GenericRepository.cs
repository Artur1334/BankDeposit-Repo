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
    public class GenericRepository<TModel> : IGenericRepository<TModel>  where TModel:class
    {
        private ArmDepositEntities DbEntities;
        private DbSet<TModel> _dbset;
        public GenericRepository()
        {
            this.DbEntities = new ArmDepositEntities();
            this._dbset = DbEntities.Set<TModel>();
        }

        public TModel Select(object id)
        {
            return _dbset.Find(id);
        }

        void IGenericRepository<TModel>.Create(TModel entity)
        {
            _dbset.Add(entity);
            DbEntities.SaveChanges();
        }

        void IGenericRepository<TModel>.Delete(int id)
        {
            TModel entityToDelete = _dbset.Find(id);
            _dbset.Remove(entityToDelete);
        }

        void IDisposable.Dispose()
        {
            throw new NotImplementedException();
        }

        void IGenericRepository<TModel>.Save()
        {
            try
            {
                DbEntities.SaveChanges();
            }
            catch (Exception exception)
            {
                throw exception;
            }

        }

        IEnumerable<TModel> IGenericRepository<TModel>.SelectAll()
        {
            return _dbset.ToList();
        }

        void IGenericRepository<TModel>.Update(TModel entity)
        {
            _dbset.Attach(entity);

            DbEntities.Entry(entity).State = EntityState.Modified;
        }
    }
}

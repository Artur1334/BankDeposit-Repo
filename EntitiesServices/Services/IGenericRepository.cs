using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntitiesServices.Services
{
    public interface IGenericRepository<TModel>:IDisposable where TModel : class
    {
        IEnumerable<TModel> SelectAll();
        TModel Select<Tmodel>(int? id);
        void Create(TModel item);
        void Update(TModel item);
        void Delete(int? id);
        void Save();
      
    }
}

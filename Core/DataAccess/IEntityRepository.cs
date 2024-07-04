using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.DataAccess
{
    //Generic constraint: where T:class, IEntity, new()
    // T: class olmalı
    // IEntity: T, IEntity'den implemente edilmeli
    // new(): new'lenebilir olmalı

    public interface IEntityRepository<T> where T:class, IEntity, new()
    {
        // Expression<Func<T,bool>> filter=null -> filtre vermek istemiyorsan null vermek zorundasın
        // Bu expression nesnesi, bir lambda ifadesini temsil eder. Bu ifade, bir parametre listesi ve bir ifade içerir
        List<T> GetAll(Expression<Func<T,bool>> filter=null);
        T Get(Expression<Func<T, bool>> filter);
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}

using Eventify.Data.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Service.Pattern
{
    public class MyServiceGeneric<T> : IMyServiceGeneric<T> where T : class
    {
        private IUnitOfWork itw;

        protected MyServiceGeneric(IUnitOfWork itw)
        {
            this.itw = itw;
        }
        public virtual void Add(T t)
        {
            itw.getRepository<T>().Add(t);
        }

        public virtual void Delete(T t)
        {
            itw.getRepository<T>().Delete(t);
        }

        public virtual void DeletebyCondition(Expression<Func<T, bool>> condition)
        {
            itw.getRepository<T>().DeleteByCondition(condition);
        }

        public virtual void Dispose()
        {
            itw.Dispose();
        }

        public virtual T GetById(string id)
        {
            return itw.getRepository<T>().GetById(id);
        }

        public virtual T GetById(int id)
        {
            return itw.getRepository<T>().GetById(id);
        }

        public virtual IEnumerable<T> GetMany(Expression<Func<T, bool>> condition = null, Expression<Func<T, bool>> orderBy = null)
        {
            return itw.getRepository<T>().GetMany(condition, orderBy);
        }

        public virtual void Update(T t)
        {
            itw.getRepository<T>().Update(t); 
        }

        public virtual void commit()
        {
            itw.commit();
        }
    }
}

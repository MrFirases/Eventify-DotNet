using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Eventify.Data.Infrastructure
{
   public interface IRepositoryBase<T> where T : class
    {

        void Add(T t);
        void Delete(T t);
        void Update(T t);
        T GetById(int id);
        T GetById(string id);
        /*
         * Define a Lambda Ecpression
         * GetMany(null) = GetAll(): donc atheka alech fasakhneha l get all amalna 2 en 1
         */
        IEnumerable<T> GetMany(Expression<Func<T, bool>> condition = null, Expression<Func<T, bool>> orderBy = null);
        void DeleteByCondition(Expression<Func<T, bool>> condition);


    }
}

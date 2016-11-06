using Eventify.Data.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Eventify.Data.Infrastructure
{
    class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {

        private eventifyContext context;
        private IDbSet<T> dbSet;
        public RepositoryBase(eventifyContext context)
        {
            this.context = context;
            dbSet = context.Set<T>();
        }
        public void commit()
        {
            context.SaveChanges();
        }

        public void Add(T t)
        {
            dbSet.Add(t);
        }

        public void Delete(T t)
        {
            dbSet.Remove(t);
        }

        public void DeleteByCondition(Expression<Func<T, bool>> condition)
        {
            IEnumerable<T> obj = dbSet.Where(condition);
            foreach (T a in obj)
            {
                dbSet.Remove(a);

            }
        }

        public T GetById(string id)
        {
            return dbSet.Find(id);
        }

        public T GetById(int id)
        {
            return dbSet.Find(id);
        }


        public IEnumerable<T> GetMany(Expression<Func<T, bool>> condition = null, Expression<Func<T, bool>> orderBy = null)
        {
            if (condition != null)
            {
                return dbSet.Where(condition);
            }

            if (orderBy != null)
            {
                return dbSet.OrderBy(orderBy);
            }

            if (condition != null && orderBy != null)
            {
                return dbSet.Where(condition).OrderBy(orderBy);

            }
            return dbSet;
        }

        public void Update(T t)
        {
            dbSet.Attach(t);
            context.Entry(t).State = EntityState.Modified;
        }

    }
}

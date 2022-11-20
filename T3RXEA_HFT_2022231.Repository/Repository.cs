using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace T3RXEA_HFT_2022231.Repository
{
    abstract public class Repository<T>: IRepository<T> where T: class
    {
        protected ShoeManamegementDBContext ctx;

        public Repository(ShoeManamegementDBContext ctx)
        {
            this.ctx = ctx;
        }

        public IQueryable<T> GetAll()
        {
            return ctx.Set<T>();
        }

        public void Create(T entity)
        {
            ctx.Set<T>().Add(entity);
            ctx.SaveChanges();
        }

        public void Delete(T entity)
        {
            ctx.Set<T>().Remove(entity);
            ctx.SaveChanges();
        }

        public abstract T GetOne(int Id);
    }
}

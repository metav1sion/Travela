using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Travela.DataAccessLayer.Abstract;
using Travela.DataAccessLayer.Context;

namespace Travela.DataAccessLayer.Repositories
{
    public class GenericRepository<T> : IGenericDal<T> where T : class
    {
        private readonly TravelaContext ctx;

        public GenericRepository(TravelaContext ctx)
        {
            this.ctx = ctx;
        }

        public void Insert(T entity)
        {
            ctx.Set<T>().Add(entity);
            ctx.SaveChanges();
        }

        public void Update(T entity)
        {
            ctx.Set<T>().Update(entity);
            ctx.SaveChanges();
        }

        public void Delete(int id)
        {
            ctx.Set<T>().Remove(ctx.Set<T>().Find(id));
            ctx.SaveChanges();
        }

        public T GetByID(int id)
        {
            return ctx.Set<T>().Find(id);
        }

        public List<T> GetListAll()
        {
            return ctx.Set<T>().ToList();
        }
    }
}

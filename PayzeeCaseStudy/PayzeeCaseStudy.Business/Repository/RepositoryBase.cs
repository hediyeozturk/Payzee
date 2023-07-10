using PayzeeCaseStudy.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;

namespace PayzeeCaseStudy.Business.Repository
{
    public class RepositoryBase<T, TId> where T : class
    {
        protected internal static PayzeeDBEntities dbContext;

        public RepositoryBase(PayzeeDBEntities _dbContext)
        {
            dbContext = _dbContext;
        }
        public virtual List<T> GetAll()
        {
            try
            {
                dbContext = new PayzeeDBEntities();
                return dbContext.Set<T>().ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public virtual T GetById(TId id)
        {
            try
            {
                dbContext = new PayzeeDBEntities();
                return dbContext.Set<T>().Find(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public virtual bool Insert(T entity)
        {
            try
            {
                if (dbContext==null)
                {
                    dbContext = new PayzeeDBEntities();
                }
                //dbContext = dbContext ?? new PayzeeDBEntities();
                dbContext.Set<T>().Add(entity);
                return dbContext.SaveChanges() > 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public virtual int Delete(T entity)
        {
            try
            {
                dbContext = dbContext ?? new PayzeeDBEntities();
                dbContext.Set<T>().Remove(entity);
                return dbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public virtual int Update()
        {
            try
            {
                dbContext = dbContext ?? new PayzeeDBEntities();
                return dbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

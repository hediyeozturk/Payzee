using PayzeeCaseStudy.Entity.Models;

namespace PayzeeCaseStudy.BL.Repository
{
    public class RepositoryBase<T, TId> where T : class
    {
        protected internal static PayzeeContext dbContext;

        public virtual List<T> GetAll()
        {
            try
            {
                dbContext = new PayzeeContext();
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
                dbContext = new PayzeeContext();
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
                dbContext = dbContext ?? new PayzeeContext();

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
                dbContext = dbContext ?? new PayzeeContext();
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
                dbContext = dbContext ?? new PayzeeContext();
                return dbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

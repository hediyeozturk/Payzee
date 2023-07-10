using PayzeeCaseStudy.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayzeeCaseStudy.Business.Repository
{
    public class CustomerRepository : RepositoryBase<Customer, int>
    {
        public CustomerRepository(PayzeeDBEntities _dbContext) : base(_dbContext)
        {
        }
    }
    public class TransactionRepository : RepositoryBase<Transaction, int>
    {
        public TransactionRepository(PayzeeDBEntities _dbContext) : base(_dbContext)
        {
        }
    }
    public class TransactionTypeRepository : RepositoryBase<TransactionType, int>
    {
        public TransactionTypeRepository(PayzeeDBEntities _dbContext) : base(_dbContext)
        {
        }
    }

}

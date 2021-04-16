using bemol.Business.Interfaces;
using bemol.Business.Models;
using bemol.Data.Context;

namespace bemol.Data.Repository
{
    public class CustomerRepository : Repository<Customer>, ICustomerRepository
    {
        public CustomerRepository(BemolDbContext context) : base (context){}
    }
}

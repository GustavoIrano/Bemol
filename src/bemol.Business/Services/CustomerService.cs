using bemol.Business.Interfaces;
using bemol.Business.Models;
using bemol.Business.Models.Validations;
using System.Threading.Tasks;

namespace bemol.Business.Services
{
    public class CustomerService : BaseService, ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomerService(INotificator notificator,
                               ICustomerRepository customerRepository) : base (notificator)
        {
            _customerRepository = customerRepository;
        }

        public async Task<bool> Add(Customer customer)
        {
            if (!ExecuteValidation(new CustomerValidation(), customer)) return false;

            await _customerRepository.Add(customer);
            return true;
        }

        public void Dispose()
        {
            _customerRepository?.Dispose();
        }
    }
}

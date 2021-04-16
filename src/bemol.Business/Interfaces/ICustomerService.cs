using bemol.Business.Models;
using System;
using System.Threading.Tasks;

namespace bemol.Business.Interfaces
{
    public interface ICustomerService : IDisposable
    {
        Task<bool> Add(Customer customer);
    }
}

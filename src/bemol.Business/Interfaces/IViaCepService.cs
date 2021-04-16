using bemol.Business.Models;
using System.Threading.Tasks;

namespace bemol.Business.Interfaces
{
    public interface IViaCepService
    {
        Task<Cep> GetDadosCep(string cep);
    }
}

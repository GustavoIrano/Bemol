using System.Collections.Generic;
using System.Threading.Tasks;

namespace bemol.WebMapNewCustomers.Service
{
    public interface IServiceList
    {
        Task<List<Coordenadas>> GetList();
        void SetItemList(Coordenadas addres);
    }
}

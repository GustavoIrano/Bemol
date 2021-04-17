using bemol.WebMapNewCustomers.Service;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace bemol.WebMapNewCustomers
{
    public class ServiceList : IServiceList
    {
        private List<Coordenadas> AddressList;

        public ServiceList()
        {
            AddressList = new List<Coordenadas>();
        }

        public async Task<List<Coordenadas>> GetList()
        {
            return AddressList;
        }

        public void SetItemList(Coordenadas addres)
        {
            AddressList.Add(addres);
        }
    }

    public class Coordenadas
    {
        public double lat { get; set; }
        public double lng { get; set; }
    }
}

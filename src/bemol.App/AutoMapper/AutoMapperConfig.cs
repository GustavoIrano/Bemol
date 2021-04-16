using AutoMapper;
using bemol.App.Models;
using bemol.Business.Models;

namespace bemol.App.AutoMapper
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<Customer, CustomerViewModel>()
                .ForMember(c => c.AddressViewModel, a => a.MapFrom(ad => ad.Address)).ReverseMap();
            CreateMap<Address, AddressViewModel>().ReverseMap();
            CreateMap<Cep, CepViewModel>().ReverseMap();
        }
    }
}

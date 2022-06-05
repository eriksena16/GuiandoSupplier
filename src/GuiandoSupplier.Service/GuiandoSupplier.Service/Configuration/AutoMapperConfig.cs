using AutoMapper;
using GuiandoSupplier.Domain.Entities;

namespace GuiandoSupplier.Service.Configuration
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {

            CreateMap<Supplier, SupplierDTO>().ReverseMap();
            CreateMap<SupplierDTO, SupplierDTQ>().ReverseMap();

        }
    }
}

using AutoMapper;
using GuiandoSupplier.Domain.Entities;
using GuiandoSupplier.Domain.Util;

namespace GuiandoSupplier.Service.Configuration
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {

            CreateMap<SupplierDTO, Supplier>().ReverseMap()
                .ForMember(dest => dest.VerticalsName, org => org.MapFrom(src => src.Verticals.ToString())); ;
            CreateMap<SupplierDTO, SupplierDTQ>().ReverseMap();

        }
    }
}

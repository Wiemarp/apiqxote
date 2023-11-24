using apiqxote.DTOModels;
using apiqxote.Models;
using AutoMapper;

namespace apiqxote.Profiles
{
    public class ZoneProfile : Profile
    {
        public ZoneProfile()
        {
            CreateMap<Zone, ZoneDTO>().ReverseMap();
        }
    }
}

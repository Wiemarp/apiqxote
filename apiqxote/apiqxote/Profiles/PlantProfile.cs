using apiqxote.DTOModels;
using apiqxote.Models;
using AutoMapper;

namespace apiqxote.Profiles
{
    public class PlantProfile : Profile
    {
        public PlantProfile() 
        {
            CreateMap<Plant, PlantDTO>().ReverseMap();
        }
    }
}

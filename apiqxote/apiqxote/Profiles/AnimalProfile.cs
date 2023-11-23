using apiqxote.DTOModels;
using apiqxote.Models;
using AutoMapper;

namespace apiqxote.Profiles
{
    public class AnimalProfile : Profile
    {
        public AnimalProfile() 
        {
            CreateMap<Animal, AnimalDTO>().ReverseMap();
        }

    }
}

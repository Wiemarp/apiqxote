using apiqxote.DTOModels;
using apiqxote.Models;
using AutoMapper;

namespace apiqxote.Profiles
{
    public class TreeProfile : Profile
    {
        public TreeProfile() 
        {
            CreateMap<Tree, TreeDTO>().ReverseMap();
        }
    }
}

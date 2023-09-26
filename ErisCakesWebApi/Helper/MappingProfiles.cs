using AutoMapper;
using ErisCakesWebApi.Dto;
using ErisCakesWebApi.Models;

namespace ErisCakesWebApi.Helper
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles() 
        {
            CreateMap<Client, ClientDTO>();
            CreateMap<BakeryRequestRecipe, BakeryRequestRecipeDTO>();
            CreateMap<BakeryRecipe, BakeryRecipeDTO>();
            CreateMap<BakeryRequest, BakeryRequestDTO>();
        }
    }
}

using AutoMapper;
using Entities;
using Entities.DataTransferObject;
using Entities.Models;

namespace WebApi.Utilities.AutoMapper
{
    public class MappingProfile :Profile
    {
      public MappingProfile()
       {
            CreateMap<MealDtoForUpdate, Meal>();
            CreateMap<Meal, MealDto>();
            CreateMap<UserForRegistrationDto, User>();

        }
        
    }
}

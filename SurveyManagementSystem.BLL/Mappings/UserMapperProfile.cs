
using AutoMapper;
using SurveyManagementSystem.BLL.Entities;
using SurveyManagementSystem.BLL.DTOs; 

namespace SurveyManagementSystem.BLL.Mappings
{
    public class UserMapperProfile : Profile
    {
        public UserMapperProfile()
        {
           
            CreateMap<UserDTO, User>()
                .ReverseMap();

       
        }
    }
}


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
                .ForMember(dest=>dest.Roles,opt=>opt.Ignore())//ignoring "Roles" member of the request body for mapping since User entity does not have "Roles" column
                .ReverseMap();//for entity to dto mapping

       
        }
    }
}

using AutoMapper;
using SurveyManagementSystem.BLL.Entities;
using SurveyManagementSystem.BLL.DTOs;

namespace SurveyManagementSystem.BLL.Mappings
{
    public class RoleMapperProfile : Profile
    {
        public RoleMapperProfile() 
        {
            CreateMap<RoleDTO, Role>()
                .ReverseMap();
        }
    }
}

using SurveyManagementSystem.BLL.Entities;

namespace SurveyManagementSystem.BLL.DTOs
{
    public class UserDTO
    {
        public int Id { get; set; } //Missing Id in DTO caused EF to treat the entity as new, leading to INSERT instead of UPDATE—include the Id and update a tracked entity.
        public string? Name { get; set; }

        public string? Address { get; set; }

        public string? Phone { get; set; }

        public IList<int> Roles { get; set; } = [];

    }
}

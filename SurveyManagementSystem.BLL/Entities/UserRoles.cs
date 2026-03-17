using System.ComponentModel.DataAnnotations;
using ServiceStack.DataAnnotations;

namespace SurveyManagementSystem.BLL.Entities
{
    //[PrimaryKey(nameof(UserId), nameof(RoleId))]
    public class UserRoles
    {
       
        public int UserId { get; set; }
       
        public int RoleId { get; set; }
    }
}



namespace SurveyManagementSystem.BLL.Entities
{
    public class Permissions
    {
        public int Id { get; set; }
        public string? Name { get; set; }

        public IList<Role> Roles { get; } = []; //For N-M relationship between Role-Persmissions
    }
}

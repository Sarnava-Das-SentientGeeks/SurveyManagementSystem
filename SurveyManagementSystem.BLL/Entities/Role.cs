namespace SurveyManagementSystem.BLL.Entities
{
    public class Role
    {
        public int Id { get; set; }
        public string? Name { get; set; }

        public IList<User> Users { get; } = []; //For N-M relationship between Users-Roles


    }
}

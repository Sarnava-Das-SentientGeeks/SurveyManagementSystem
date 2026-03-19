namespace SurveyManagementSystem.BLL.Entities
{
    public class Role
    {
        public int Id { get; set; }
        public string? Name { get; set; }

        public string? Summary { get; set;  }
        public IList<User> Users { get; } = []; //For N-M relationship between Users-Roles

        public IList<Permissions> Permissions { get; } = []; //For N-M relationship between Role-Persmissions




    }
}

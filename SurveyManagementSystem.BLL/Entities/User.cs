namespace SurveyManagementSystem.BLL.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Address { get; set; }
        public int Phone { get; set; }
        public Role? Role { get; set; }
    }
}

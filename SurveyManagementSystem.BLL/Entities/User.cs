using System.ComponentModel.DataAnnotations;

namespace SurveyManagementSystem.BLL.Entities
{
    public class User
    {
        public int Id { get; set; }
        [Required]
        public string? Name { get; set; }  
        public string? Address { get; set; }
        public string? Phone { get; set; }

        [Required]
        public IList<Role> Roles { get; } = []; //For N-M relationship between User-Roles

        public IList<Survey> Surveys { get; } = []; //For N-M relationship between User-Surveys

        public ICollection<Response> Responses { get; } = new List<Response>(); //1-N relationship between User-Response

    }
}



namespace SurveyManagementSystem.BLL.Entities
{
    public class Survey
    {
        public int Id { get; set; }
        public string? Title { get; set; }

        public string? Description { get; set; }

        public IList<User> Users { get; } = [];//For N-M relationship between User-Surveys

        public ICollection<Response> Responses { get; }= new List<Response>();//For 1-N relationship between Survey-Response

        public ICollection<Questions> Questions { get; } = new List<Questions>(); //For 1-N relationship between Survey-Questions
    }
}

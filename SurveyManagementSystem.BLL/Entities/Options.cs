

namespace SurveyManagementSystem.BLL.Entities
{
    public class Options
    {
        public int Id { get; set; }

        public int QuestionId { get; set; } //Required foreign key since 

        public string? Text { get; set; }

        public Questions Questions { get; set; } = null!; // Required reference navigation to parent Questions since Options is the child table
    }
}

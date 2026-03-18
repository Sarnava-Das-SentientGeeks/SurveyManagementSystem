

namespace SurveyManagementSystem.BLL.Entities
{
    public class Answers
    {
        public int Id { get; set; }

        public int QuestionId { get; set; } //Foreign key 

        public int ResponseId { get; set; } //Foreign key 

        public string? Value { get; set; }

        public Questions Questions { get; set; } = null!; // Required reference navigation to principal table Questions since Answers is the child table

        public Response Response { get; set; } = null!; // Required reference navigation to principal table Response since Answers is the child table



    }
}

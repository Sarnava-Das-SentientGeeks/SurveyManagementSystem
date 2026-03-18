

namespace SurveyManagementSystem.BLL.Entities
{
    public class Questions
    {
        public int Id { get; set; }
        public int SurveyId { get; set; } //Required foreign key property
        public string? Text { get; set; }
        public string? Type { get; set; }
        public bool Required {  get; set; }

        public Survey Survey { get; set; } = null!; // Required reference navigation to principal table Survey since Questions is the child table


        public ICollection<Options> Options { get; } = new List<Options>(); //1-N relationship between Questions-Options

        public ICollection<Answers> Answers { get; }= new List<Answers>(); //1-N relationship between Questions-Answers

    }
}

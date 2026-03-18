namespace SurveyManagementSystem.BLL.Entities
{
    public class Response
    {
        public int Id { get; set; }
        public int SurveyId {  get; set; } //Required foreign key

        public int UserId { get; set; } //Required foreign key

        public User User { get; set; } = null!; // Required reference navigation to parent User since Response is the child table

        public Survey Survey { get; set; } = null!; // Required reference navigation to parent Survey since Response is the child table

        public ICollection<Answers> Answers { get; } = new List<Answers>();  //For 1-N relationship between Response-Answers
    }
}

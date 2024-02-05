namespace CandidateSoW.Models
{
    public class SecurityQuestionModel
    {
        public int QuestionId { get; set; } = 0;
        public string Question { get; set; } = "";
        public string Type { get; set; } = "";
    }

    public class SecurityAnswerModel
    {
        public int AnswerId { get; set; } = 0;
        public string EmailId { get; set; } = "";
        public int QuestionId1 { get; set; } = 0;
        public string Answer1 { get; set; } = "";
        public int QuestionId2 { get; set; } = 0;
        public string Answer2 { get; set; } = "";
        public int QuestionId3 { get; set; } = 0;
        public string Answer3 { get; set; } = "";
        public string Type { get; set; } = "";
    }
}

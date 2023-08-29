namespace OnlineExamProject_UsingCookies.Models
{
    public class QuestionModel
    {
        public string? QuestionText { get; set; }
        public List<string>? Options { get; set; }
        public string? SelectedOption { get; set; }
        public string? CorrectAnswer { get; set; }
    }
}

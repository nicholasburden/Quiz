using Newtonsoft.Json;
using Quiz.Models;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Linq;
using System.Web;

namespace Quiz.Data
{
    public class QuizGenerationService : IQuizGenerationService
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public QuizGenerationService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<Models.Quiz> GetQuizAsync(QuizOptions options)
        {
            var uri = $"https://opentdb.com/api.php?amount={options.NumQuestions}&category={options.Category.Item1}&difficulty={options.Difficulty}&type=multiple";
            var questions = await GetQuestionsFromApi(uri);
            return new Models.Quiz
            {
                Questions = questions
            };
        }

        private async Task<List<MultipleChoiceQuestion>> GetQuestionsFromApi(string uri)
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync(uri);
            var jsonString = await response.Content.ReadAsStringAsync();
            var quizApiResponse = JsonConvert.DeserializeObject<QuizApiResponse>(jsonString);
            List<MultipleChoiceQuestion> questions = new List<MultipleChoiceQuestion>();
            switch (quizApiResponse.ResponseCode) {
                case 0:
                    foreach (var question in quizApiResponse.Results)
                    {
                        var text = HttpUtility.HtmlDecode(question.Question);
                        var choices = question.Incorrect_Answers.Select(x => HttpUtility.HtmlDecode(x)).ToList();
                        var decodedCorrectAnswer = HttpUtility.HtmlDecode(question.Correct_Answer);
                        choices.Add(decodedCorrectAnswer);
                        var correctAnswerIndex = choices.IndexOf(decodedCorrectAnswer);
                        questions.Add(new MultipleChoiceQuestion
                        {
                            Text = text,
                            Choices = choices,
                            AnswerIndex = correctAnswerIndex
                        });
                    }
                    break;
            }
            return questions;
        }
    }
}

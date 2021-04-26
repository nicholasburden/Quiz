using Quiz.Models;
using System.Threading.Tasks;

namespace Quiz.Data
{
    public interface IQuizGenerationService
    {
        Task<Models.Quiz> GetQuizAsync(QuizOptions options);
    }
}

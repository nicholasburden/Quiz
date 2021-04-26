using Quiz.Data;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Quiz.Models
{
    public static class QuizState
    {
        private static ConcurrentDictionary<string, Quiz> _quizes = new ConcurrentDictionary<string, Quiz>();
        private static ConcurrentDictionary<string, List<Player>> _waitingPlayers = new ConcurrentDictionary<string, List<Player>>();

        public static Quiz GetExistingQuiz(Player player, string quizId)
        {
            if (_quizes.ContainsKey(quizId))
            {
                var quiz = _quizes[quizId];
                return quiz;
            }
            else
            {
                return null;
            }
        }

        public static void AddQuiz(Quiz quiz)
        {
            _quizes[quiz.Id] = quiz;
        }

        public static void RemoveQuiz(Quiz quiz)
        {
            _quizes.TryRemove(quiz.Id, out var foundQuiz);
        }

        public static void AddToWaiting(Player player, string quizId)
        {
            if (_waitingPlayers.ContainsKey(quizId))
            {
                _waitingPlayers[quizId].Add(player);
            }
            _waitingPlayers[quizId] = new List<Player>() { player };
        }

        public static List<Player> GetWaitingPlayers(string quizId)
        {
            return _waitingPlayers[quizId];
        }

        public static bool? IsUsernameTaken(string quizId, string username)
        {
            return _waitingPlayers[quizId]?.Any(player => player.Username == username);
        }
    }
}

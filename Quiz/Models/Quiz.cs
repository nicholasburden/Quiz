using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Quiz.Models
{
    public class Quiz
    {
        public string Id { get; set; }
        public IList<Player> Players { get; set; }
        public IList<MultipleChoiceQuestion> Questions { get; set; }

        public bool IsUsernameTaken(string username)
        {
            return Players.Any(player => player.Username == username);
        }
    }
}

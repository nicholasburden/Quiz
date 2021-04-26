using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Quiz.Models
{
    public class QuizOptions
    {
        public int NumQuestions { get; set; }
        public (int, string) Category { get; set; }
        public string Difficulty { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Quiz.Models
{
    public class MultipleChoiceQuestion
    {
        public string Text { get; set; }
        public IList<string> Choices { get; set; }
        public int AnswerIndex { get; set; }
    }
}

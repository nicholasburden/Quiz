using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Quiz.Models
{
    public class QuizApiResponse
    {
        public int ResponseCode { get; set; }
        public List<QuestionApiResponse> Results { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace AlgoMeterApp.Domain.Models
{
    public class DomainQuestions
    {
        public DomainQuestions() { }
        public DomainQuestions(string question)
        {
            QuestionId = 0;
            Question = question;
        }        
        public DomainQuestions(string question, string input, string output)
        {
            QuestionId = 0;
            Question = question;
            Input = input;
            Output = output;
        }
        public long QuestionId { get; set; }
        public string Question { get; set; }
        public string Input { get; set; }
        public string Output { get; set; }
    }

}

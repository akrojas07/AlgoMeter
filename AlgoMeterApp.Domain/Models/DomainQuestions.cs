using System;
using System.Collections.Generic;
using System.Text;

namespace AlgoMeterApp.Domain.Models
{
    public class DomainQuestions
    {
        public long QuestionId { get; }
        public string Question { get; }
        public string Examples { get; }
    }

    public class Examples 
    {
        public string Input { get; }
        public string Output { get; }
        public string Explanation { get; }
    }
}

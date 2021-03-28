using System;
using System.Collections.Generic;
using System.Text;

namespace AlgoMeterApp.Infrastructure.Persistence.Entities
{
    public class RepoQuestions
    {
        public long QuestionId { get; set; }
        public string Question { get; set; }
        public Examples Example { get; set; }
    }

    public class Examples
    {
        public string Input { get; set; }
        public string Output { get; set; }
        public string Explanation { get; set; }
    }
}

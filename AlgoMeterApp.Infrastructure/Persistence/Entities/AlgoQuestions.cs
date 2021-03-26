using System;
using System.Collections.Generic;
using System.Text;

namespace AlgoMeterApp.Infrastructure.Persistence.Entities
{
    public class AlgoQuestions
    {
        public long QuestionId { get; }
        public string Question { get; }
        public string Examples { get; }
    }
}

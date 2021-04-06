using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AlgoMeterApp.API.Models.QuestionModels
{
    public class BaseQuestionsRequest
    {
        public long QuestionId { get; set; }
        public string Question { get; set; }
        public string Input { get; set; }
        public string Output { get; set; }
    }


}

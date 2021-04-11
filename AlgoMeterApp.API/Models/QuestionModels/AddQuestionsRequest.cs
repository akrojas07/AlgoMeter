using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AlgoMeterApp.API.Models.QuestionModels
{
    public class AddQuestionsRequest 
    {
        public List<BaseQuestionsRequest> QuestionList { get; set; }
    }
}

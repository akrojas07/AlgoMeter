using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AlgoMeterApp.API.Models.UserModels
{
    public class UpdateExistingQLRequest : BaseUserRequest
    {
        public List<long> QuestionIds { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace AlgoMeterApp.Domain.Models
{
    public class User
    {
        public long Id { get; set;}
        public List<long> QuestionIds { get; set; }
    }
}

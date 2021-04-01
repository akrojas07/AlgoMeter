using System;
using System.Collections.Generic;
using System.Text;
using MongoDB.Bson;

namespace AlgoMeterApp.Domain.Models
{
    public class User
    {
        public string UserId { get; set;}
        public List<long> QuestionIds { get; set; }
    }
}

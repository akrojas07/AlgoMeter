using System;
using System.Collections.Generic;
using System.Text;
using MongoDB.Bson;

namespace AlgoMeterApp.Infrastructure.Persistence.Entities
{
    public class RepoQuestions
    {
        public BsonObjectId _id { get; set; }
        public long QuestionId { get; set; }
        public string Question { get; set; }
        public string Input { get; set; }
        public string Output { get; set; }
        
    }
}

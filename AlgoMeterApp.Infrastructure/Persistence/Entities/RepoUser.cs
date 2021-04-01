using System;
using System.Collections.Generic;
using System.Text;
using MongoDB.Bson;

namespace AlgoMeterApp.Infrastructure.Persistence.Entities
{
    public class RepoUser
    {
        public BsonObjectId _id { get; set; }
        public string UserId { get; set; }
        public List<long> QuestionIds { get; set; }
    }
}

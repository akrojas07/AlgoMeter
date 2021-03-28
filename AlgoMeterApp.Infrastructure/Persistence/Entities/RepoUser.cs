using System;
using System.Collections.Generic;
using System.Text;

namespace AlgoMeterApp.Infrastructure.Persistence.Entities
{
    public class RepoUser
    {
        public Guid Id { get; set; }
        public List<long> QuestionIds { get; set; }
    }
}

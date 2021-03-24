using AlgoMeterApp.Infrastructure.Persistence.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;


using AlgoMeterApp.Infrastructure.Persistence.Entities;

namespace AlgoMeterApp.Infrastructure.Persistence.Repositories
{
    public class AlgoRandomizingRepository : IAlgoRandomizingRepository
    {
        public AlgoRandomizingRepository() { }

        public async Task<int> GetQuestionBankSize()
        {
            throw new NotImplementedException();
        }

        public async Task<AlgoQuestions> GetRandomizedQuestion(int questionNumber)
        {
            throw new NotImplementedException();
        }
    }
}

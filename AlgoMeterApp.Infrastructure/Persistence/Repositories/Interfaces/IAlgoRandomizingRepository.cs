using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

using AlgoMeterApp.Infrastructure.Persistence.Entities;

namespace AlgoMeterApp.Infrastructure.Persistence.Repositories.Interfaces
{
    public interface IAlgoRandomizingRepository
    {
        Task<AlgoQuestions> GetRandomizedQuestion(int questionNumber);
        Task<int> GetQuestionBankSize();
    }
}

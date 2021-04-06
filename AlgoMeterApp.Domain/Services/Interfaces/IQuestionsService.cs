using AlgoMeterApp.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AlgoMeterApp.Domain.Services.Interfaces
{
    public interface IQuestionsService
    {
        Task AddQuestions(List<DomainQuestions> questionList);
        Task<DomainQuestions> GetRandomizedQuestion(string userId);
    }
}

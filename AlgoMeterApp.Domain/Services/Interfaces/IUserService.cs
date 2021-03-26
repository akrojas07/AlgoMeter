using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AlgoMeterApp.Domain.Services.Interfaces
{
    public interface IUserService
    {
        Task CreateNewUser();
        Task UpdateExistingUserQuestionList();
        Task DeleteExistingUser(); 
    }
}

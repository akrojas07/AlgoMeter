using AlgoMeterApp.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AlgoMeterApp.Domain.Services.Interfaces
{
    public interface IUserService
    {
        Task<string> CreateNewUser();
        Task UpdateExistingUserQuestionList(User existingUser);
        Task DeleteExistingUser(string userId); 
    }
}

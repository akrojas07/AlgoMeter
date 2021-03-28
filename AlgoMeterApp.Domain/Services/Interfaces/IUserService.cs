using AlgoMeterApp.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AlgoMeterApp.Domain.Services.Interfaces
{
    public interface IUserService
    {
        Task CreateNewUser(User newUser);
        Task UpdateExistingUserQuestionList(User existingUser);
        Task DeleteExistingUser(Guid userId); 
    }
}

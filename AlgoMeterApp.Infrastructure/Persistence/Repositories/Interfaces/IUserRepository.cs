using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AlgoMeterApp.Infrastructure.Persistence.Repositories.Interfaces
{
    public interface IUserRepository
    {
        Task CreateNewUser();
        Task UpdateExistingUserQuestionList();
        Task DeleteExistingUser();
    }
}

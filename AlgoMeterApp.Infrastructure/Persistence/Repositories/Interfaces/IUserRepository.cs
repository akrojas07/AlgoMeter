using AlgoMeterApp.Infrastructure.Persistence.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AlgoMeterApp.Infrastructure.Persistence.Repositories.Interfaces
{
    public interface IUserRepository
    {
        Task CreateNewUser(RepoUser repoUser);
        Task UpdateExistingUserQuestionList(RepoUser repoUser);
        Task DeleteExistingUser(Guid userId);
    }
}

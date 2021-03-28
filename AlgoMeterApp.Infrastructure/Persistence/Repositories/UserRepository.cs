using AlgoMeterApp.Infrastructure.Persistence.Repositories.Interfaces;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AlgoMeterApp.Infrastructure.Persistence.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly IMongoDatabase _mongoDatabase;

        public UserRepository(IMongoDatabase mongoDatabase)
        {
            _mongoDatabase = mongoDatabase;
        }
        public Task CreateNewUser()
        {
            throw new NotImplementedException();
        }

        public Task DeleteExistingUser()
        {
            throw new NotImplementedException();
        }

        public Task UpdateExistingUserQuestionList()
        {
            throw new NotImplementedException();
        }
    }
}

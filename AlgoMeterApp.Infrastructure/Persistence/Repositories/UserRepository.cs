using AlgoMeterApp.Infrastructure.Persistence.Entities;
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
        public async Task CreateNewUser(RepoUser newUser)
        {
            //pull user collection from db
            var userCollection = _mongoDatabase.GetCollection<RepoUser>("AlgoUserToQuestions");

            //add new user to collection
            await userCollection.InsertOneAsync(newUser);
        }

        public async Task DeleteExistingUser(string userId)
        {
            //pull user collection from db
            var userCollection = _mongoDatabase.GetCollection<RepoUser>("AlgoUserToQuestions");

            //define a filter for which user document to delete
            var deleteFilter = Builders<RepoUser>.Filter.Eq("UserId", userId);

            //pass the delete filter into the Delete One method
            await userCollection.DeleteOneAsync(deleteFilter);
        }

        public async Task<RepoUser> GetUserDetails(string userId)
        {
            //pull collection of users from db
            var userCollection = _mongoDatabase.GetCollection<RepoUser>("AlgoUserToQuestions");

            //filter data down to the sepcific user document
            var filter = Builders<RepoUser>.Filter.Eq("UserId", userId);

            //filter collection down to document that matches filter
            var userDocument = await userCollection.Find(filter).FirstOrDefaultAsync();

            return userDocument; 
        }

        public async Task UpdateExistingUserQuestionList(RepoUser repoUser)
        {
            //pull collection of users from db
            var userCollection = _mongoDatabase.GetCollection<RepoUser>("AlgoUserToQuestions");

            //filter data down to specific document where userid is equal to argument
            var filter = Builders<RepoUser>.Filter.Eq("UserId", repoUser.UserId);

            //set data to be changed 
            var update = Builders<RepoUser>.Update.Set("QuestionIds", repoUser.QuestionIds);

            //update selected data
            await userCollection.UpdateOneAsync(filter, update);

        }
    }
}

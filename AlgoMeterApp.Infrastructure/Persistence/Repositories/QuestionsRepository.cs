using AlgoMeterApp.Infrastructure.Persistence.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;


using AlgoMeterApp.Infrastructure.Persistence.Entities;
using MongoDB.Driver;
using MongoDB.Bson;

namespace AlgoMeterApp.Infrastructure.Persistence.Repositories
{
    public class QuestionsRepository : IQuestionsRepository
    {
        private readonly IMongoDatabase _mongoDatabase;
        public QuestionsRepository(IMongoDatabase mongoDatabase) 
        {
            _mongoDatabase = mongoDatabase;
        }

        public async Task AddQuestions(List<RepoQuestions> questionList)
        {
            //pull list of questions from db
            var questionCollection = _mongoDatabase.GetCollection<RepoQuestions>("AlgoQuestions");

            //add new questions to collection
            await questionCollection.InsertManyAsync(questionList);
        }

        public async Task<long> GetQuestionBankSize()
        {
            //pull list of questions from db
            var questionCollection = _mongoDatabase.GetCollection<RepoQuestions>("AlgoQuestions");

            //return count of questions
            return await questionCollection.CountAsync(new BsonDocument());
        }

        public async Task<RepoQuestions> GetRandomizedQuestion(long questionNumber)
        {
            //pull collection of questions from db
            var questionCollection = _mongoDatabase.GetCollection<RepoQuestions>("AlgoQuestions");

            //filter questions collection by question id  
            var filter = Builders<RepoQuestions>.Filter.Eq("QuestionId", questionNumber);

            //set questionDocument to the first instance of question_id = question number
            var questionDocument = await questionCollection.Find(filter).FirstOrDefaultAsync();

            return questionDocument;
        }
    }
}

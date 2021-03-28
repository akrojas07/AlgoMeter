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
    public class AlgoRandomizingRepository : IAlgoRandomizingRepository
    {
        private readonly IMongoDatabase _mongoDatabase;
        public AlgoRandomizingRepository(IMongoDatabase mongoDatabase) 
        {
            _mongoDatabase = mongoDatabase;
        }

        public async Task<long> GetQuestionBankSize()
        {
            //pull list of questions from db
            var questionList = _mongoDatabase.GetCollection<AlgoQuestions>("AlgoQuestions");

            //return count of questions
            return await questionList.CountDocumentsAsync(new BsonDocument());
        }

        public async Task<AlgoQuestions> GetRandomizedQuestion(long questionNumber)
        {
            //pull collection of questions from db
            var questionCollection = _mongoDatabase.GetCollection<AlgoQuestions>("AlgoQuestions");

            //filter questions collection by question id  
            var filter = Builders<AlgoQuestions>.Filter.Eq("question_id", questionNumber);

            //set questionDocument to the first instance of question_id = question number
            var questionDocument = await questionCollection.Find(filter).FirstOrDefaultAsync();

            return questionDocument;
        }
    }
}

using AlgoMeterApp.Domain.Models;
using AlgoMeterApp.Domain.Services.Interfaces;
using AlgoMeterApp.Infrastructure.Persistence.Entities;
using AlgoMeterApp.Infrastructure.Persistence.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AlgoMeterApp.Domain.Services
{
    public class QuestionsService : IQuestionsService
    {
        private readonly IQuestionsRepository _algoRepo;
        private readonly IUserRepository _userRepository;
        private static long _randomQuestionNumber; 
        public QuestionsService(IQuestionsRepository algoRepo, IUserRepository userRepository) 
        {
            _algoRepo = algoRepo;
            _randomQuestionNumber = 0;
            _userRepository = userRepository;
        }


        /// <summary>
        /// Service method to randomize the selection of a question
        /// Loops through numbers 1 to n (equivalent to the number of questions available in the question bank)
        /// </summary>
        /// <returns>randomized question number</returns>
        private void RandomizeQuestion(List<long> seenQuestions, long questionBankSize)
        {
            //select random number from the questionBank size
            Random rand = new Random();

            do
            {
                _randomQuestionNumber = rand.Next(1, (int)questionBankSize + 1);
            } 
            while (seenQuestions.Contains(_randomQuestionNumber));
        }

        /// <summary>
        /// Service method to pull randomized question from repository
        /// Uses randomized number returned by RandomizeQuestion Method
        /// </summary>
        /// <returns>Task of type Question</returns>
        public async Task<DomainQuestions> GetRandomizedQuestion(string userId)
        {
            //validate input
            if(string.IsNullOrEmpty(userId))
            {
                throw new ArgumentException(); 
            }

            //pull question bank size information
            var questionBankSize = await _algoRepo.GetQuestionBankSize();

            //validate data from db
            if (questionBankSize <= 0)
            {
                throw new Exception();
            }

            //call user service to pull list of seen questions 
            var userDetails = await _userRepository.GetUserDetails(userId);
            var seenQuestions = userDetails.QuestionIds;

            //return if seen question list == length of question bank size
            if(seenQuestions.Count >= questionBankSize)
            {
                throw new Exception("Reached end of question set");
            }

            //pass them into randomize question 
            RandomizeQuestion(seenQuestions, questionBankSize);

            //call service to pull question based on question id
            var randomizedQuestion = await _algoRepo.GetRandomizedQuestion(_randomQuestionNumber);

            //map to domain question
            DomainQuestions domainRandomizedQuestion = Mapper.QuestionMapper.RepoToDomainQuestion(randomizedQuestion);

            //return domain question
            return domainRandomizedQuestion;
        }

        /// <summary>
        /// Service method to add questions to the database
        /// </summary>
        /// <param name="questionList"></param>
        /// <returns></returns>
        public async Task AddQuestions(List<DomainQuestions> questionList)
        {
            //validate input
            if(questionList == null)
            {
                throw new ArgumentException();
            }

            //map domain question list to db question list 
            var dbQuestionList = new List<RepoQuestions>();

            foreach(var q in questionList)
            {
                dbQuestionList.Add(Mapper.QuestionMapper.DomainToRepoQuestion(q));
            }

            await _algoRepo.AddQuestions(dbQuestionList); 

        }
    }
}

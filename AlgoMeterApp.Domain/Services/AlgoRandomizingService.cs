using AlgoMeterApp.Domain.Models;
using AlgoMeterApp.Domain.Services.Interfaces;
using AlgoMeterApp.Infrastructure.Persistence.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AlgoMeterApp.Domain.Services
{
    public class AlgoRandomizingService : IAlgoRandomizingService
    {
        private readonly IAlgoRandomizingRepository _algoRepo;
        private static long _randomQuestionNumber; 
        public AlgoRandomizingService(IAlgoRandomizingRepository algoRepo) 
        {
            _algoRepo = algoRepo;
            _randomQuestionNumber = 0;
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
                _randomQuestionNumber = rand.Next(1, (int)questionBankSize);
            } 
            while (!seenQuestions.Contains(_randomQuestionNumber));

        }

        /// <summary>
        /// Service method to pull randomized question from repository
        /// Uses randomized number returned by RandomizeQuestion Method
        /// </summary>
        /// <returns>Task of type Question</returns>
        public async Task<DomainQuestions> GetRandomizedQuestion(long userId)
        {
            //pull question bank size information
            var questionBankSize = await _algoRepo.GetQuestionBankSize();

            //validate data from db
            if (questionBankSize <= 0)
            {
                return null;
            }

            //call user service to pull questions 

            //return if seen question list == length of question bank size
            List<long> seenQuestions = new List<long>();

            //pass them into randomize question 
            RandomizeQuestion(seenQuestions, questionBankSize);

            //call service to pull question based on question id
            var randomizedQuestion = await _algoRepo.GetRandomizedQuestion(_randomQuestionNumber);

            //map to domain question
            DomainQuestions domainRandomizedQuestion = Mapper.QuestionMapper.RepoToDomainQuestion(randomizedQuestion);

            //return domain question
            return domainRandomizedQuestion;
        }


    }
}

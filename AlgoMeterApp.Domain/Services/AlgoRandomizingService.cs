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
        private static int _randomQuestionNumber; 
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
        public async Task RandomizeQuestion()
        {
            //pull question bank size information
            var questionBankSize = await _algoRepo.GetQuestionBankSize(); 

            //validate data from db
            if(questionBankSize <= 0)
            {
                return;
            }

            //select random number from the questionBank size
            Random rand = new Random();

            _randomQuestionNumber = rand.Next(1, questionBankSize);

        }

        /// <summary>
        /// Service method to pull randomized question from repository
        /// Uses randomized number returned by RandomizeQuestion Method
        /// </summary>
        /// <returns>Task of type Question</returns>
        public Task GetRandomizedQuestion()
        {
            throw new NotImplementedException();
        }


    }
}

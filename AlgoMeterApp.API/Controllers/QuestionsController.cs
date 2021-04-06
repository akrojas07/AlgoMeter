using AlgoMeterApp.API.Models;
using AlgoMeterApp.API.Models.QuestionModels;
using AlgoMeterApp.Domain.Models;
using AlgoMeterApp.Domain.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AlgoMeterApp.API.Controllers
{
    [ApiController]
    [Route("api/questions")]
    public class QuestionsController : ControllerBase
    {
        private readonly IQuestionsService _questionService;

        public QuestionsController(IQuestionsService questionService)
        {
            _questionService = questionService;
        }

        [HttpPost]
        public async Task<IActionResult> AddQuestions([FromBody] AddQuestionsRequest questionRequest) 
        {
            //validate input
            if(questionRequest == null)
            {
                return StatusCode(400);
            }

            try
            {
                //convert request list to domain questions
                List<DomainQuestions> domainQuestionsList = new List<DomainQuestions>();

                foreach(var q in questionRequest.QuestionList)
                {
                    var domainQuestion = new DomainQuestions()
                    {
                        QuestionId = q.QuestionId,
                        Question = q.Question,
                        Input = q.Input,
                        Output = q.Output
                    };

                    domainQuestionsList.Add(domainQuestion);
                }

                await _questionService.AddQuestions(domainQuestionsList);

                return Ok();

            }
            catch(Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
            
        }

        [HttpGet]

        public async Task<IActionResult> GetRandomizedQuestion([FromQuery]string userId)
        {
            if(userId == null)
            {
                return StatusCode(400);
            }

            try
            {
                var randomQuestion = await _questionService.GetRandomizedQuestion(userId);
                return Ok(randomQuestion);
            }
            catch(Exception e)
            {
                return StatusCode(500, e.Message);
            }

        }
    }
}

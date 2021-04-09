using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using AlgoMeterApp.API.Controllers;
using AlgoMeterApp.API.Models.QuestionModels;
using AlgoMeterApp.Domain.Models;
using AlgoMeterApp.Domain.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;

namespace AlgoMeterApp.Tests.APITests
{
    [TestFixture]
    public class QuestionsControllerTests
    {
        private Mock<IQuestionsService> _questionService;

        [SetUp]
        public void Setup()
        {
            _questionService = new Mock<IQuestionsService>();
        }

        [Test]
        public async Task AddQuestions_Controller_Test_Fail_ArgumentException()
        {
            var controller = new QuestionsController(_questionService.Object);
            var response = await controller.AddQuestions(null);

            Assert.IsNotNull(response);
            Assert.AreEqual(400, ((StatusCodeResult)response).StatusCode);
        }

        [Test]
        public async Task AddQuestions_Controller_Test_Fail_InternalError()
        {
            _questionService.Setup(q => q.AddQuestions(It.IsAny<List<DomainQuestions>>()))
                .ThrowsAsync(new Exception());

            var controller = new QuestionsController(_questionService.Object);
            var response = await controller.AddQuestions(new AddQuestionsRequest() 
            { 
                QuestionList = new List<BaseQuestionsRequest>() 
                {
                    new BaseQuestionsRequest()
                    { 
                        QuestionId = 1,
                        Question = "Sample Question",
                        Input = "Sample input",
                        Output = "Sample output"
                    }
                } 
            });

            Assert.IsNotNull(response);
            Assert.AreEqual(500, ((ObjectResult)response).StatusCode);
        }

        [Test]
        public async Task AddQuestions_Controller_Test_Success()
        {
            _questionService.Setup(q => q.AddQuestions(It.IsAny<List<DomainQuestions>>()))
                .Returns(Task.CompletedTask);

            var controller = new QuestionsController(_questionService.Object);
            var response = await controller.AddQuestions(new AddQuestionsRequest()
            {
                QuestionList = new List<BaseQuestionsRequest>()
                {
                    new BaseQuestionsRequest()
                    {
                        QuestionId = 1,
                        Question = "Sample Question",
                        Input = "Sample input",
                        Output = "Sample output"
                    }
                }
            });

            Assert.IsNotNull(response);
            Assert.AreEqual(200, ((OkResult)response).StatusCode);
        }
       
        [Test]
        public async Task GetRandomizedQuestion_Controller_Test_Fail_ArgumentException()
        {
            var controller = new QuestionsController(_questionService.Object);
            var response = await controller.GetRandomizedQuestion(null);

            Assert.IsNotNull(response);
            Assert.AreEqual(400, ((StatusCodeResult)response).StatusCode);
        }

        [Test]
        public async Task GetRandomizedQuestion_Controller_Test_Fail_InternalError()
        {
            _questionService.Setup(q => q.GetRandomizedQuestion(It.IsAny<string>()))
                .ThrowsAsync(new Exception());

            var controller = new QuestionsController(_questionService.Object);
            var response = await controller.GetRandomizedQuestion("string");

            Assert.IsNotNull(response);
            Assert.AreEqual(500, ((ObjectResult)response).StatusCode);
        }

        [Test]
        public async Task GetRandomizedQuestion_Controller_Test_Success()
        {
            _questionService.Setup(q => q.GetRandomizedQuestion(It.IsAny<string>()))
                .ReturnsAsync(new DomainQuestions() 
                {
                    QuestionId = 1,
                    Question = "Sample Question",
                    Input = "Sample input",
                    Output = "Sample output"
                });

            var controller = new QuestionsController(_questionService.Object);
            var response = await controller.GetRandomizedQuestion("string");

            Assert.IsNotNull(response);
            Assert.AreEqual(200, ((OkObjectResult)response).StatusCode);
        }

        /*
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
         */

    }
}

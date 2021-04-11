using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using AlgoMeterApp.Domain.Models;
using AlgoMeterApp.Domain.Services;
using AlgoMeterApp.Domain.Services.Interfaces;
using AlgoMeterApp.Infrastructure.Persistence.Entities;
using AlgoMeterApp.Infrastructure.Persistence.Repositories.Interfaces;
using MongoDB.Bson;
using Moq;
using NUnit.Framework;

namespace AlgoMeterApp.Tests.DomainTests
{
    [TestFixture]
    public class QuestionsServiceTests
    {
        private Mock<IQuestionsRepository> _questionRepository;
        private Mock<IUserRepository> _userRepository;

        [SetUp]
        public void Setup()
        {
            _questionRepository = new Mock<IQuestionsRepository>();
            _userRepository = new Mock<IUserRepository>();
        }

        [Test]
        public async Task AddQuestions_Test_Success()
        {
            _questionRepository.Setup(q => q.AddQuestions(It.IsAny<List<RepoQuestions>>()))
                .Returns(Task.CompletedTask);

            var questionService = new QuestionsService(_questionRepository.Object, _userRepository.Object);

            await questionService.AddQuestions(new List<DomainQuestions>()
            {
                new DomainQuestions{ Question = "Sample Question", Input = "Sample Input", Output = "Sample Output" }
            });

            _questionRepository.Verify(q => q.AddQuestions(It.IsAny<List<RepoQuestions>>()), Times.Once);
        }

        [Test]
        public void AddQuestions_Test_Fail_EmptyList()
        {
            var questionService = new QuestionsService(_questionRepository.Object, _userRepository.Object);
            Assert.ThrowsAsync<ArgumentException>(() => questionService.AddQuestions(null));

            _questionRepository.Verify(q => q.AddQuestions(It.IsAny<List<RepoQuestions>>()), Times.Never);
        }

        [Test]
        public async Task GetRandomizedQuestion_Test_Success()
        {
            _questionRepository.Setup(q => q.GetQuestionBankSize())
                .ReturnsAsync(2);

            _userRepository.Setup(u => u.GetUserDetails(It.IsAny<string>()))
                .ReturnsAsync(new RepoUser()
                {
                    UserId = "1",
                    QuestionIds = new List<long> { 1 }
                });
            _questionRepository.Setup(q => q.GetRandomizedQuestion(It.IsAny<long>()))
                .ReturnsAsync(new RepoQuestions()
                {
                    Question = "This is a sample question",
                    QuestionId = 5,
                    Input = "sample string",
                    Output = "sample output"
                });

            var questionService = new QuestionsService(_questionRepository.Object, _userRepository.Object);

            await questionService.GetRandomizedQuestion("1");

            _questionRepository.Verify(q => q.GetQuestionBankSize(), Times.Once);
            _userRepository.Verify(u => u.GetUserDetails(It.IsAny<string>()), Times.Once);
            _questionRepository.Verify(q => q.GetRandomizedQuestion(It.IsAny<long>()), Times.Once);
        }

        [Test]
        public void GetRandomizedQuestion_Test_Fail_EmptyUserId()
        {
            var questionService = new QuestionsService(_questionRepository.Object, _userRepository.Object);

            Assert.ThrowsAsync<ArgumentException>(() => questionService.GetRandomizedQuestion(null));

            _questionRepository.Verify(q => q.GetQuestionBankSize(), Times.Never);
            _userRepository.Verify(u => u.GetUserDetails(It.IsAny<string>()), Times.Never);
            _questionRepository.Verify(q => q.GetRandomizedQuestion(It.IsAny<long>()), Times.Never);
        }

        [Test]
        public void GetRandomizedQuestion_Test_Fail_EmptyQuestionBank()
        {
            _userRepository.Setup(u => u.GetUserDetails(It.IsAny<string>()))
                .ReturnsAsync(new RepoUser()
                {
                    UserId = "1",
                    QuestionIds = new List<long> { 1 }
                });

            var questionService = new QuestionsService(_questionRepository.Object, _userRepository.Object);
            Assert.ThrowsAsync<Exception>(() => questionService.GetRandomizedQuestion("1"));

            _questionRepository.Verify(q => q.GetQuestionBankSize(), Times.Once);
            _userRepository.Verify(u => u.GetUserDetails(It.IsAny<string>()), Times.Never);
            _questionRepository.Verify(q => q.GetRandomizedQuestion(It.IsAny<long>()), Times.Never);
        }

        [Test]
        public void GetRandomizedQuestion_Test_Fail_AllQuestionsSeen()
        {
            _questionRepository.Setup(q => q.GetQuestionBankSize())
                .ReturnsAsync(2);

            _userRepository.Setup(u => u.GetUserDetails(It.IsAny<string>()))
                .ReturnsAsync(new RepoUser()
                {
                    UserId = "1",
                    QuestionIds = new List<long> { 1, 2 }
                });
            var questionService = new QuestionsService(_questionRepository.Object, _userRepository.Object);
            Assert.ThrowsAsync<Exception>(() => questionService.GetRandomizedQuestion("1"));

            _questionRepository.Verify(q => q.GetQuestionBankSize(), Times.Once);
            _userRepository.Verify(u => u.GetUserDetails(It.IsAny<string>()), Times.Once);
            _questionRepository.Verify(q => q.GetRandomizedQuestion(It.IsAny<long>()), Times.Never);
        }
    }
}

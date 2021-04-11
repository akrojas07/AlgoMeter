using NUnit.Framework;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using AlgoMeterApp.Infrastructure.Persistence.Repositories.Interfaces;
using System.Threading.Tasks;
using AlgoMeterApp.Infrastructure.Persistence.Entities;
using AlgoMeterApp.Domain.Services;
using AlgoMeterApp.Domain.Models;

namespace AlgoMeterApp.Tests.DomainTests
{
    [TestFixture]
    public class UserServiceTests
    {
        private Mock<IUserRepository> _userRepository;

        [SetUp]
        public void Setup()
        {
            _userRepository = new Mock<IUserRepository>();
        }

        [Test]
        public async Task CreateNewUser_Test_Success()
        {
            _userRepository.Setup(u => u.CreateNewUser(It.IsAny<RepoUser>()))
                .Returns(Task.CompletedTask);

            var userService = new UserService(_userRepository.Object);
            await userService.CreateNewUser();

            _userRepository.Verify(u => u.CreateNewUser(It.IsAny<RepoUser>()), Times.Once);
        }


        [Test]
        public async Task DeleteExistingUser_Test_Success()
        {
            _userRepository.Setup(u => u.DeleteExistingUser(It.IsAny<string>()))
                .Returns(Task.CompletedTask);

            var userService = new UserService(_userRepository.Object);
            await userService.DeleteExistingUser("1");

            _userRepository.Verify(u => u.DeleteExistingUser(It.IsAny<string>()), Times.Once);
        }
        
        [Test]
        public void DeleteExistingUser_Test_Fail_EmptyUserId()
        {
            var userService = new UserService(_userRepository.Object);
            Assert.ThrowsAsync<ArgumentException>(() => userService.DeleteExistingUser(null));
            _userRepository.Verify(u => u.DeleteExistingUser(It.IsAny<string>()), Times.Never);
        }

        [Test]
        public async Task UpdateExistingUserQuestionList_Test_Success()
        {
            _userRepository.Setup(u => u.UpdateExistingUserQuestionList(It.IsAny<RepoUser>()))
                .Returns(Task.CompletedTask);

            var userService = new UserService(_userRepository.Object);
            await userService.UpdateExistingUserQuestionList(new User() { UserId = "UserId", QuestionIds = new List<long> {1, 2, 3} });

            _userRepository.Verify(u => u.UpdateExistingUserQuestionList(It.IsAny<RepoUser>()), Times.Once);
        }

        [Test]
        public void UpdateExistingUserQuestionList_Test_Fail_InvalidInput()
        {
            var userService = new UserService(_userRepository.Object);
            Assert.ThrowsAsync<ArgumentException>(() => userService.UpdateExistingUserQuestionList(null));

            _userRepository.Verify(u => u.UpdateExistingUserQuestionList(It.IsAny<RepoUser>()), Times.Never);
        }
    }
}

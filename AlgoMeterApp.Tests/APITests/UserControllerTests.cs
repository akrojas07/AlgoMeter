using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using AlgoMeterApp.API.Controllers;
using AlgoMeterApp.API.Models.UserModels;
using AlgoMeterApp.Domain.Models;
using AlgoMeterApp.Domain.Services;
using AlgoMeterApp.Domain.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;

namespace AlgoMeterApp.Tests.APITests
{
    [TestFixture]
    public class UserControllerTests
    {
        private Mock<IUserService> _userService;
        
        [SetUp]
        public void Setup()
        {
            _userService = new Mock<IUserService>();
        }

        [Test]
        public async Task CreateNewUser_Controller_Test_Success()
        {
            _userService.Setup(u => u.CreateNewUser())
                .ReturnsAsync("1");

            var userController = new UserController(_userService.Object);
            var response = await userController.CreateNewUser();

            Assert.IsNotNull(response);
            Assert.AreEqual(201, ((ObjectResult)response).StatusCode);
        }

        [Test]
        public async Task CreateNewUser_Controller_Test_Fail_InternalError()
        {
            _userService.Setup(u => u.CreateNewUser())
                .ThrowsAsync(new Exception());

            var userController = new UserController(_userService.Object);
            var response = await userController.CreateNewUser();

            Assert.IsNotNull(response);
            Assert.AreEqual(500, ((ObjectResult)response).StatusCode);
        }

        [Test]
        public async Task UpdateExistingUserQuestionList_Controller_Test_Fail_ArgumentException()
        {
            var controller = new UserController(_userService.Object);
            var response = await controller.UpdateExistingUserQuestionList(It.IsAny<UpdateExistingQLRequest>());

            Assert.IsNotNull(response);
            Assert.AreEqual(400, ((StatusCodeResult)response).StatusCode);
        }

        [Test]
        public async Task UpdateExistingUserQuestionList_Controller_Test_Fail_InternalError()
        {
            _userService.Setup(u => u.UpdateExistingUserQuestionList(It.IsAny<User>()))
                .ThrowsAsync(new Exception());

            var controller = new UserController(_userService.Object);
            var response = await controller.UpdateExistingUserQuestionList(new UpdateExistingQLRequest() 
            { 
                UserId = "123", 
                QuestionIds = new List<long>() {1,2,3 } 
            });

            Assert.IsNotNull(response);
            Assert.AreEqual(500, ((ObjectResult)response).StatusCode);
        }
        
        [Test]
        public async Task UpdateExistingUserQuestionList_Controller_Test_Success()
        {
            _userService.Setup(u => u.UpdateExistingUserQuestionList(It.IsAny<User>()))
                .Returns(Task.CompletedTask);

            var controller = new UserController(_userService.Object);
            var response = await controller.UpdateExistingUserQuestionList(new UpdateExistingQLRequest()
            {
                UserId = "123",
                QuestionIds = new List<long>() { 1, 2, 3 }
            });

            Assert.IsNotNull(response);
            Assert.AreEqual(200, ((OkResult)response).StatusCode);
        }

        [Test]
        public async Task DeleteExistingUser_Controller_Test_Fail_ArgumentException()
        {
            var controller = new UserController(_userService.Object);
            var response = await controller.DeleteExistingUser(null);

            Assert.IsNotNull(response);
            Assert.AreEqual(400, ((StatusCodeResult)response).StatusCode);
        }
        
        [Test]
        public async Task DeleteExistingUser_Controller_Test_Fail_InternalError()
        {
            _userService.Setup(u => u.DeleteExistingUser(It.IsAny<string>()))
                .ThrowsAsync(new Exception());
            var controller = new UserController(_userService.Object);
            var response = await controller.DeleteExistingUser(new DeleteUserRequest() { UserId = "123"});

            Assert.IsNotNull(response);
            Assert.AreEqual(500, ((ObjectResult)response).StatusCode);
        }

        [Test]
        public async Task DeleteExistingUser_Controller_Test_Success()
        {
            _userService.Setup(u => u.DeleteExistingUser(It.IsAny<string>()))
                .Returns(Task.CompletedTask);

            var controller = new UserController(_userService.Object);
            var response = await controller.DeleteExistingUser(new DeleteUserRequest() { UserId = "123" });

            Assert.IsNotNull(response);
            Assert.AreEqual(200, ((OkResult)response).StatusCode);
        }

    }
}

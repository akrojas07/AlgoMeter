using AlgoMeterApp.API.Models.UserModels;
using AlgoMeterApp.Domain.Models;
using AlgoMeterApp.Domain.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AlgoMeterApp.API.Controllers
{
    [ApiController]
    [Route("api/user")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateNewUser()
        {
            try
            {
                var newUserId = await _userService.CreateNewUser();
                
                return StatusCode(201, new { userId = newUserId });
            }
            catch(Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPut]
        public async Task<IActionResult> UpdateExistingUserQuestionList([FromBody] UpdateExistingQLRequest updateExistingQLRequest)
        {
            if(updateExistingQLRequest == null)
            {
                return StatusCode(400);
            }

            try
            {
                //convert to domain 
                User domainUser = new User()
                {
                    UserId = updateExistingQLRequest.UserId,
                    QuestionIds = updateExistingQLRequest.QuestionIds
                };
                
                await _userService.UpdateExistingUserQuestionList(domainUser);

                return Ok();
            }
            catch(Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteExistingUser([FromBody] DeleteUserRequest deleteUserRequest)
        {
            if(deleteUserRequest == null)
            {
                return StatusCode(400);
            }

            try
            {
                await _userService.DeleteExistingUser(deleteUserRequest.UserId);

                return Ok();
            }
            catch(Exception ex)
            {
                return StatusCode(500, ex.Message);
            }

        }
    }
}

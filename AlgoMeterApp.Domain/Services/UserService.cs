using AlgoMeterApp.Domain.Models;
using AlgoMeterApp.Domain.Services.Interfaces;
using AlgoMeterApp.Infrastructure.Persistence.Repositories.Interfaces;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AlgoMeterApp.Domain.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task CreateNewUser(User newUser)
        {
            if(newUser == null)
            {
                return;
            }
            //map domain user to db user
            var dbUser = Mapper.UserMapper.DomainToDbUser(newUser);

            await _userRepository.CreateNewUser(dbUser);

        }

        public async Task DeleteExistingUser(Guid userId)
        {
            if(userId == null)
            {
                return;
            }
            await _userRepository.DeleteExistingUser(userId);
        }

        public async Task UpdateExistingUserQuestionList(User existingUser)
        {
            if(existingUser == null)
            {
                return;
            }
            //map domain user and question list to repo user and question list
            var dbUser = Mapper.UserMapper.DomainToDbUser(existingUser);

            await _userRepository.UpdateExistingUserQuestionList(dbUser);

        }
    }
}

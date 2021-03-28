using System;
using System.Collections.Generic;
using System.Text;
using DomainUser = AlgoMeterApp.Domain.Models.User;
using DbUser = AlgoMeterApp.Infrastructure.Persistence.Entities.RepoUser;

namespace AlgoMeterApp.Domain.Mapper
{
    public static class UserMapper
    {
        public static DomainUser DbToDomainUser(DbUser dbUser)
        {
            DomainUser domainUser = new DomainUser();
            domainUser.Id = dbUser.Id;

            domainUser.QuestionIds = dbUser.QuestionIds;

            return domainUser;
        }

        public static DbUser DomainToDbUser(DomainUser domainUser)
        {
            DbUser dbUser = new DbUser();

            dbUser.Id = domainUser.Id;
            dbUser.QuestionIds = dbUser.QuestionIds;

            return dbUser;

        }
    }
}

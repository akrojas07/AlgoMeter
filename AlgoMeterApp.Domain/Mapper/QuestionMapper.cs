using System;
using System.Collections.Generic;
using System.Text;

using AlgoMeterApp.Domain.Models;
using AlgoMeterApp.Infrastructure.Persistence.Entities;

namespace AlgoMeterApp.Domain.Mapper
{
    public static class QuestionMapper
    {
        public static DomainQuestions RepoToDomainQuestion(RepoQuestions repoQuestion)
        {
            DomainQuestions domainQuestion = new DomainQuestions();

            domainQuestion.QuestionId = repoQuestion.QuestionId;
            domainQuestion.Question = repoQuestion.Question;
            domainQuestion.Input = repoQuestion.Input;
            domainQuestion.Output = repoQuestion.Output;


            return domainQuestion;
        }

        public static RepoQuestions DomainToRepoQuestion(DomainQuestions domainQuestion)
        {
            RepoQuestions repoQuestion = new RepoQuestions();
            
            repoQuestion.QuestionId = domainQuestion.QuestionId;
            repoQuestion.Question = domainQuestion.Question;
            repoQuestion.Input = domainQuestion.Input;
            repoQuestion.Output = domainQuestion.Output;

            return repoQuestion;
        }
    }
}

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
            domainQuestion.Example.Input = repoQuestion.Example.Input;
            domainQuestion.Example.Output = repoQuestion.Example.Output;
            domainQuestion.Example.Explanation = repoQuestion.Example.Explanation;

            return domainQuestion;
        }

        public static RepoQuestions DomainToRepoQuestion(DomainQuestions domainQuestion)
        {
            RepoQuestions repoQuestion = new RepoQuestions();
            
            repoQuestion.QuestionId = domainQuestion.QuestionId;
            repoQuestion.Question = domainQuestion.Question;
            repoQuestion.Example.Input = domainQuestion.Example.Input;
            repoQuestion.Example.Output = domainQuestion.Example.Output;
            repoQuestion.Example.Explanation = domainQuestion.Example.Explanation;

            return repoQuestion;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static Question.domain4.PostedQuestionWorkflow.PostedQuestionResult;

namespace Question.domain4.PostedQuestionWorkflow
{
    class UpdateVotes
    {
        public QuestionPosted Update(QuestionPosted question, VoteEnum voteEnum)
        {
            var newVotes = new VoteEnum();
            return null;
            //return new QuestionPosted(questionId, voteEnum);
        }
    }
}

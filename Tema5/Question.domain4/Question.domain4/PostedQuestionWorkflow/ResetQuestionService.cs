using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using static Question.domain4.PostedQuestionWorkflow.BodyQuestion;

namespace Question.domain4.PostedQuestionWorkflow
{
    public class ResetQuestionService
    {
        public Task SendResetQuestionLink(PostedQuestion body)
        {
            return Task.CompletedTask;
        }
    }
}

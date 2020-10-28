using LanguageExt.Common;
using System;
using System.Collections.Generic;
using System.Text;
using static Question.domain4.PostedQuestionWorkflow.BodyQuestion;

namespace Question.domain4.PostedQuestionWorkflow
{
    public class PostedQuestionService
    {
        public Result<PostedQuestion> PostQuestion(UnpostedQuestion body)
        {
            return new PostedQuestion(body.Body);
        }
    }
}
